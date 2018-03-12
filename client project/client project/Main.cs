using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace client
{
    public partial class Main : Form
    {
        private Color change_col;
        private string Username;
        private int endpoint;
        private NetworkStream nStream;
        private BinaryReader breader;
        private BinaryWriter bwriter;
        private Thread thread;
        private string palyer1_name;
        private string w_room_token = null;
        private client_project.myGame game; //object from mygame form 
        private int temp_room_id = -1;
        bool flag;
        public Main(NetworkStream nStream, String Username)
        {
            InitializeComponent();
            this.nStream = nStream;
            this.Username = Username;
            this.Text = Username;// name el form 
            bwriter = new BinaryWriter(nStream);
            breader = new BinaryReader(nStream);
            bwriter.Write(Username);
            endpoint = int.Parse(breader.ReadString());
            thread = new Thread(recieve_data);
            thread.IsBackground = true;
            thread.Start();
            btn_create.Enabled = false;
            btn_join.Enabled = false;
            btn_watch.Enabled = false;

        }

        ~Main() { thread.Abort(); }


        private void btn_create_Click(object sender, EventArgs e)
        {
            bwriter.Write("new room&" + endpoint + "&" + room_name_txt.Text);//send to server create room and client port num and room name
            while (temp_room_id == -1) ;
            game = new client_project.myGame(temp_room_id, endpoint, "Player 1: " + Username, bwriter,change_col);
            temp_room_id = -1;
            game.btn1 = false;
            game.btn2 = false;
            game.btn3 = false;
            game.btn4 = false;
            game.btn5 = false;
            game.btn6 = false;
            game.btn7 = false;
            DialogResult DR1 = game.ShowDialog();
            
           

        }


        private void btn_join_Click(object sender, EventArgs e)
        {

            if (ListBox_ID.SelectedIndex != -1)
            {
                bwriter.Write("join room confirm&" + ListBox_ID.SelectedItem.ToString() + "&" + endpoint);//send to server room id and player 2 id (prot number)
               while (temp_room_id == -1) ;
                game = new client_project.myGame(temp_room_id, endpoint, "Player 2: " + Username, bwriter, change_col);
                temp_room_id = -1;
                game.other_player_name = "player 1 : " + palyer1_name;
                game.Change_Label = "";
                
                DialogResult DR2 = game.ShowDialog();
            }
        }


        private void btn_watch_Click(object sender, EventArgs e)
        {
            if (ListBox_ID.SelectedIndex != -1)
            {
                int room_id = int.Parse(ListBox_ID.SelectedItem.ToString());
                bwriter.Write("watch room&" + endpoint + "&" + room_id);

                while (w_room_token == null) ;
                game = new client_project.myGame(room_id, endpoint, "Watcher: " + Username, bwriter, change_col);
                w_room_token = null;
                game.ShowDialog();
            }
        }
        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            int index = ((ListBox)sender).SelectedIndex;
            if (index != -1)
            {
                ListBox_ID.SelectedIndex = index;
                ListBox_Rooms.SelectedIndex = index;
                ListBox_Players.SelectedIndex = index;
                btn_watch.Enabled = true;
                if (ListBox_Players.SelectedItem.ToString() == "2/2")
                    btn_join.Enabled = false;
                else
                    btn_join.Enabled = true;
            }
            else
            {
                btn_watch.Enabled = false;
                btn_join.Enabled = false;
            }


        }

        private void recieve_data()// read data from server
        {
            try
            {
                while (true)
                {
                    string[] response = breader.ReadString().Split('&');
                    string type = response[0];
                    switch (type)
                    {
                        case "room":  // add room id ,name, num of player per room to listboxs of all clients except room creator
                            ListBox_ID.Items.Add(response[1]);
                            ListBox_Rooms.Items.Add(response[2]);
                            ListBox_Players.Items.Add(response[3] + "/2");
                            break;
                        case "room token": // room id from server to make creator to open mygame form 
                            temp_room_id = int.Parse(response[1]);
                            break;


                        case "new player": // server send room id and player 2 id and name 
                            DialogResult result = MessageBox.Show(response[3] + " wants to join your room", "Join Confirmation", 
                                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (result == DialogResult.OK)
                            {
                                game.Change_Label = "";
                                game.btn1 = false;
                                game.btn2 = false;
                                game.btn3 = false;
                                game.btn4 = false;
                                game.btn5 = false;
                                game.btn6 = false;
                                game.btn7 = false;
                                game.other_player_name = "Player 2 : " + response[3];
                                bwriter.Write("join room reply&" + response[1] + "&" + response[2]);// send to server player2 id and room id 
                                
                            }
                            break;

                        case "join room accepted":

                            temp_room_id = int.Parse(response[1]);
                            palyer1_name = response[2];

                            break;

                        case "BButton":
                            while (game == null) ;
                                game.x_cord = int.Parse(response[1]);
                                game.y_cord = int.Parse(response[2]);
                                game.c_cord = int.Parse(response[3]);
                                flag = bool.Parse(response[4]);
                                game.color_= Color.FromArgb(int.Parse(response[5]));
                           
                                game.btn1 = flag;
                                game.btn2 = flag;
                                game.btn3 = flag;
                                game.btn4 = flag;
                                game.btn5 = flag;
                                game.btn6 = flag;
                                game.btn7 = flag;
                            

                            
                            break;

                        case "Change Room Capacity":
                            int index = ListBox_ID.FindStringExact(response[1]);
                            ListBox_Players.Items[index] = "2/2";
                            break;
                        case "watch room token":
                            w_room_token = response[1];
                            break;

                        default:
                            MessageBox.Show(response[0]);
                            break;
                        

                    }
                   
                }
            }
            catch (EndOfStreamException)
            {
                DialogResult result = MessageBox.Show("Error :Server is Down");
                if (result == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }


        private void Main_Load(object sender, EventArgs e)
        {

        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            thread.Abort();
            breader.Close();
            bwriter.Close();
            nStream.Close();
            Application.ExitThread();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            change_col = colorDialog1.Color;
            btn_create.Enabled = true;
            btn_join.Enabled = true;
            btn_watch.Enabled = true;
        }
    }
}
