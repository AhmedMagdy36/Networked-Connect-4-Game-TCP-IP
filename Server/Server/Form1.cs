using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {

        private Dictionary<int, Clients> clients;
        private Thread thread1;
        private Thread thread2;
        TcpListener listener;
        private Dictionary<int, Room> rooms;
        private int rooms_id = 100;

        ~Form1() { thread1.Abort();
            thread2.Abort();
        }
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();
            
           
            clients = new Dictionary<int, Clients>();
            rooms = new Dictionary<int, Room>();

            listener = new TcpListener(IPAddress.Any, 5000);
            
        }

        private void Button_Start_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "Start")
            {
                thread1 = new Thread(Client_accept);
                thread1.Priority = ThreadPriority.BelowNormal;
                thread2 = new Thread(recieve_data);
                thread2.Priority = ThreadPriority.Highest;
                thread1.IsBackground = true;
                thread2.IsBackground = true;
                thread1.Start();
                thread2.Start();
                ((Button)sender).Text = "Stop";
            }
            else
                ((Button)sender).Text = "Start";
        }

        private void Client_accept()
        {
            listener.Start();
            while (true)
            {
                Socket socket = listener.AcceptSocket();
                if (socket.Connected)
                {
                    Clients client_obj = new Clients(socket);//value

                    clients.Add(client_obj.Endpoint, client_obj);//add to dictionary

                    connect_client_port_num.Items.Add(client_obj.Endpoint);//add port number to list box

                    connect_client_name.Items.Add(client_obj.Name);// add client name to list box

                    foreach (int index in rooms.Keys.ToList())
                    {
                        client_obj.bWriter = "room&" + index + "&" + rooms[index].Name + "&" + rooms[index].num_of_players();
                    }

                }

            }
        }



        private void recieve_data()
        {

           
            while (true)// to make server read data all time
            {
                try
                {
                    foreach (int port in clients.Keys.ToList()) // scan all clients  by port num in Dictionary
                    {
                        foreach (string msg in clients[port].Msgs.ToList())  //scan all mes of each client to check if any client send message
                        {
                            string[] response = msg.Split('&');
                            string type = response[0];

                            switch (type)
                            {

                                case "new room": // if user sent new room  then server send room id to creator to open myGame form and notify other clients room created 
                                     int creator = int.Parse(response[1]);
                                    string room_name = response[2];

                                    clients[creator].bWriter = "room token&" + rooms_id;//room id
                                    Room room_obj = new Room(creator, room_name);
                                    rooms.Add(rooms_id, room_obj);

                                    foreach (int index in clients.Keys.ToList())
                                    {
                                        clients[index].bWriter = "room&" + rooms_id + "&" + room_obj.Name + "&"+ room_obj.num_of_players();
                                    }
                                    rooms_id++;
                                    break;

                                case "join room confirm":
                                    int roomid = int.Parse(response[1]);//room id
                                    int player2_id = int.Parse(response[2]);//player2 id
                                    int owner_id = rooms[roomid].Owner;//player1 id
                                    clients[owner_id].bWriter = "new player&" + roomid + "&" + player2_id + "&" + clients[player2_id].Name; //send to player 1 room id and player2 id and name 
                                    break;

                                case "join room reply":
                                    int _roomid = int.Parse(response[1]);//room id 
                                    int player2 = int.Parse(response[2]);
                                    rooms[_roomid].AddPlayer(player2);// add player2 to room dichnary
                                    clients[player2].bWriter = "join room accepted&" + _roomid + "&"+clients[rooms[_roomid].Player1].Name; // send to player 2 room id to open myGame from
                                    
                                    foreach (int index in clients.Keys.ToList())// send to all client thats room is full 2/2
                                    {
                                        clients[index].bWriter = "Change Room Capacity&" + _roomid;//room id
                                    }
                                    break;

                                case "Button Clicked":
                                    int room_id_btn_clck = int.Parse(response[1]);
                                    string player_clck_type = response[2];
                                    int x = int.Parse(response[3]);
                                    int y = int.Parse(response[4]);
                                    
                                    int c = int.Parse(response[5]);
                                    string mycolor = response[6];
                                    if (player_clck_type.Contains("Player 1"))
                                    {
                                        clients[rooms[room_id_btn_clck].Player2].bWriter = "BButton&" +x+"&"+y+"&" + c+"&true"+"&"+mycolor;
                                      rooms[room_id_btn_clck].Addmove("BButton&" + x + "&" + y + "&" + c + "&false" + "&" + mycolor);
                                    }
                                    else if (player_clck_type.Contains("Player 2"))
                                    {
                                        clients[rooms[room_id_btn_clck].Player1].bWriter = "BButton&" + x + "&" + y + "&" + c + "&true" + "&" + mycolor;
                                        rooms[room_id_btn_clck].Addmove("BButton&" + x + "&" + y + "&" + c + "&false" + "&" + mycolor);
                                    }
                                    foreach (int index in rooms[room_id_btn_clck].Watchers)
                                    {
                                        clients[index].bWriter = "BButton&" + x + "&" + y + "&" + c + "&true" + "&" + mycolor;
                                    }


                                    break;

                                case "watch room":
                                    int watcherid = int.Parse(response[1]);
                                    int watchroomid = int.Parse(response[2]);
                                    rooms[watchroomid].AddWatcher(watcherid);
                                    
                                    clients[watcherid].bWriter = "watch room token&" + "##";
                                    foreach (var item in rooms[watchroomid].Moves)
                                    {
                                        clients[watcherid].bWriter = item;
                                    }
                                    break;
                                case "Win Game":
                                    int winroomid = int.Parse(response[1]);
                                    string winplayer = response[2];
                                    
                                    break;

                                default:
                                    MessageBox.Show(response[0]);
                                    break;

                            }

                            clients[port].RemoveMsg(msg);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There is error happened while reading data.\n" + ex.Message, "Error msg!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.ExitThread();
                }
            }
        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }//end of partial class

   
}
