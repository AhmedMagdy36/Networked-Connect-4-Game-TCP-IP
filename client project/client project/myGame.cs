using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client_project
{
    public partial class myGame : Form
    {
        
        private BinaryWriter bWriter;
        private int room_id;
        private int player_id;
        private string player_type;
        private Color mycolor;
        private Color mycolor1;
        private Color mycolor2;
        private string player_no;
        int x;
        int y;
        int c;
        bool flag = false;
        SolidBrush Ellipse_brush;
        Color Ellipse_Color;
        int[] ys;
        int[,] colors;
        int[] row;
        List<saved_data> data;
        public myGame()
        {
            InitializeComponent();
        }

        public string Change_Label { set { current_player_txt.Text = value; } }
        public bool btn1 { set { button1.Enabled = value; } }
        public bool btn2 { set { button2.Enabled = value; } }
        public bool btn3 { set { button3.Enabled = value; } }
        public bool btn4 { set { button4.Enabled = value; } }
        public bool btn5 { set { button5.Enabled = value; } }
        public bool btn6 { set { button6.Enabled = value; } }
        public bool btn7 { set { button7.Enabled = value; } }
        public string other_player_name { set { other_player_txt.Text = value; } }

        public int x_cord
        {
            set
            {
                x = value;
             
            }
        }

        public int y_cord
        {
            set
            {
               
                y = value;

          
            }
        }


        public int c_cord
        {
            set
            {

                c = value;


            }
        }
        public Color color_
        {
            set
            {

                mycolor = value;

                draw_click(x, y, c,mycolor);

            }
        }


        public myGame(int Room_id, int Player_id, string Player_Type, BinaryWriter bWriter,Color mycolor)
        {
            InitializeComponent();

            this.room_id = Room_id;
            this.player_id = Player_id;
            this.bWriter = bWriter;
          
            this.player_type = Player_Type;
            player1_txt.Text = player_type;
            row = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            Ellipse_Color = Color.White;
            ys = new int[] { 650, 650, 650, 650, 650, 650, 650 };

            data = new List<saved_data>();


            if (player_type.Contains("Player 1:"))
            {
                this.mycolor1 = mycolor;
            }
            if (player_type.Contains("Player 2:"))
            {
                mycolor2 = mycolor;
            }

                colors = new int[6, 7];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    colors[i, j] = 0;

                }

            }
          

            if (player_type.Contains("Watcher:"))
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                other_player_txt.Text = "";
                current_player_txt.Text = "";

                
            }
            
            
        }
        public void reset()
        {
            row = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            ys = new int[] { 650, 650, 650, 650, 650, 650, 650 };
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    colors[i, j] = 0;

                }

            }
            Graphics g = this.CreateGraphics();
            Ellipse_brush = new SolidBrush(Color.White);
            // Application.Restart();
            redraw();
            ys = new int[] { 650, 650, 650, 650, 650, 650, 650 };
            flag = false;
        }
        public void redraw()
        {
            Graphics g = this.CreateGraphics();
            Ellipse_brush = new SolidBrush(Color.White);
            // Application.Restart();
            data.Clear();

            for (int y = 0; y < 7; y++)
            {
                for (int x = 0; x < 6; x++)
                {


                    for (int i = 10; i <= 670; i = i + 110)
                    {
                        g.FillEllipse(new SolidBrush(Color.White), i, ys[x], 80, 80);
                    }
                    if (ys[y] > 100)
                    {
                        ys[y] = ys[y] - 110;
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Ellipse_brush = new SolidBrush(Ellipse_Color);
            Pen blackPen = new Pen(Color.Black, 3);
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            Ellipse_brush = new SolidBrush(Ellipse_Color);
            e.Graphics.FillRectangle(blueBrush, 5, 95, 750, 650);
            int x = 10;
            int y = 100;
            int width = 80;
            int height = 80;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {

                    e.Graphics.FillEllipse(new SolidBrush(Color.White), x, y, width, height);
                    y += width + 30;
                }
                y = 100;
                x += height + 30;

            }
            foreach (var item in data)
            {
                draw(item.xx, item.yy, item.color);
                

            }

        }

        public void draw_player()
        {
            int c = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (colors[i, j] == 0) { c++; }

                }

            }
            if (c == 0)
            {
                MessageBox.Show("Draw");
               reset();
            }

        }

        private void myGame_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.Beep();
            x = 0;
            y = 10;
            c = 0;
            player_no = player_type.Split(':')[0];
            if (player_type.Contains("Player 2:"))
            {

                draw_click(x, y, c, mycolor2);
                

                bWriter.Write("Button Clicked&" + room_id + "&" + player_type + "&" + x + "&" + y + "&" + c + "&" + mycolor2.ToArgb());
            }
            if (player_type.Contains("Player 1:"))
            {
                draw_click(x, y, c, mycolor1);


                bWriter.Write("Button Clicked&" + room_id + "&" + player_type + "&" + x + "&" + y + "&" + c + "&" + mycolor1.ToArgb());
            }
            disable();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Console.Beep();
            x = 1;
            y = 120;
            c = 1;
            disable();
            player_no = player_type.Split(':')[0];
            if (player_type.Contains("Player 2:"))
            {
                draw_click(x, y, c, mycolor2);                
                bWriter.Write("Button Clicked&" + room_id + "&" + player_type + "&" + x + "&" + y + "&" + c + "&" + mycolor2.ToArgb());
            }
            if (player_type.Contains("Player 1:"))
            {
                draw_click(x, y, c, mycolor1);                
                bWriter.Write("Button Clicked&" + room_id + "&" + player_type + "&" + x + "&" + y + "&" + c + "&" + mycolor1.ToArgb());
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Console.Beep();
            x = 2;
            y = 230;
            c = 2;
            disable();
            player_no = player_type.Split(':')[0];
            if (player_type.Contains("Player 2:"))
            {


                
                draw_click(x, y, c, mycolor2);
               
                bWriter.Write("Button Clicked&" + room_id + "&" + player_type + "&" + x + "&" + y + "&" + c + "&" + mycolor2.ToArgb());
            }
            if (player_type.Contains("Player 1:"))
            {
                
                draw_click(x, y, c, mycolor1);

                bWriter.Write("Button Clicked&" + room_id + "&" + player_type + "&" + x + "&" + y + "&" + c + "&" + mycolor1.ToArgb());
            }
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Console.Beep();
            x = 3;
            y = 340;
            c = 3;
            disable();
            player_no = player_type.Split(':')[0];

            if (player_type.Contains("Player 2:"))
            {
                draw_click(x, y, c, mycolor2);
                bWriter.Write("Button Clicked&" + room_id + "&" + player_type + "&" + x + "&" + y + "&" + c + "&" + mycolor2.ToArgb());
            }
            if (player_type.Contains("Player 1:"))
            {
                draw_click(x, y, c, mycolor1);
                bWriter.Write("Button Clicked&" + room_id + "&" + player_type + "&" + x + "&" + y + "&" + c + "&" + mycolor1.ToArgb());
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Console.Beep();
            x = 4;
            y = 450;
            c = 4;
            disable();
            player_no = player_type.Split(':')[0];

            if (player_type.Contains("Player 2:"))
            {
                draw_click(x, y, c, mycolor2);

                bWriter.Write("Button Clicked&" + room_id + "&" + player_type + "&" + x + "&" + y + "&" + c + "&" + mycolor2.ToArgb());
            }
            if (player_type.Contains("Player 1:"))
            {
                draw_click(x, y, c, mycolor1);

                bWriter.Write("Button Clicked&" + room_id + "&" + player_type + "&" + x + "&" + y + "&" + c + "&" + mycolor1.ToArgb());
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Console.Beep();
            x = 5;
            y = 560;
            c = 5;
            disable();
            player_no = player_type.Split(':')[0];

            if (player_type.Contains("Player 2:"))
            {
                draw_click(x, y, c, mycolor2);
                bWriter.Write("Button Clicked&" + room_id + "&" + player_type + "&" + x + "&" + y + "&" + c + "&" + mycolor2.ToArgb());
            }
            if (player_type.Contains("Player 1:"))
            {
                draw_click(x, y, c, mycolor1);
                bWriter.Write("Button Clicked&" + room_id + "&" + player_type + "&" + x + "&" + y + "&" + c + "&" + mycolor1.ToArgb());
            }
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Console.Beep();
            x = 6;
            y = 670;
            c = 6;
            disable();
            player_no = player_type.Split(':')[0];

            
            if (player_type.Contains("Player 2:"))
            {
                draw_click(x, y, c, mycolor2);
                bWriter.Write("Button Clicked&" + room_id + "&" + player_type + "&" + x + "&" + y + "&" + c + "&" + mycolor2.ToArgb());
            }
            if (player_type.Contains("Player 1:"))
            {
                draw_click(x, y, c, mycolor1);
                bWriter.Write("Button Clicked&" + room_id + "&" + player_type + "&" + x + "&" + y + "&" + c + "&" + mycolor1.ToArgb());
            }
            
        }

        public void draw_click(int n, int x, int col ,Color mycolor_)
        {


            Graphics g = this.CreateGraphics();
            if (ys[n] >= 100)
            {
                if (flag == false)
                {
                    Ellipse_Color = mycolor_;
                    flag = true;
                    colors[row[col], col] = 1;
                    row[col]++;

                }
                else
                {
                    Ellipse_Color = mycolor_;
                    flag = false;
                    colors[row[col], col] = 2;
                    row[col]++;
                    Invalidate();
                }
                saved_data dd = new saved_data()

                {
                    xx = ys[n],
                    yy = x,
                    color = Ellipse_Color,
                };
                data.Add(dd);
                Invalidate();
                
              

                ys[n] = ys[n] - 110;
            }
            Invalidate();
            checK_win();
            draw_player();


        }

        public void disable()
        {

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
        }

        public void checK_win()
        {
            int start = 0;

            //Horizontal Win
            for (int i = 0; i < 6; i++)
            {
                for (start = 0; start <= 3; start++)
                {
                    if ((colors[i, start] == colors[i, start + 1] && colors[i, start + 1] == colors[i, start + 2] && colors[i, start + 2] == colors[i, start + 3]) && (colors[i, start] == 1))
                    {

                        bWriter.Write("Win Game&" + room_id + "&" + player_type);
                        MessageBox.Show("Player 2 win Congratulation !!!!");
                        reset();
                        disable();


                    }
                    else if ((colors[i, start] == colors[i, start + 1] && colors[i, start + 1] == colors[i, start + 2] && colors[i, start + 2] == colors[i, start + 3]) && (colors[i, start] == 2))
                    {
                        bWriter.Write("Win Game&" + room_id + "&" + player_type);
                        MessageBox.Show("Player 1 win Congratulation !!!!");
                        reset();
                        disable();
                    }
                }
            }
            for (int i = 0; i < 7; i++)
            {
                for (start = 0; start <= 2; start++)
                {
                    if ((colors[start, i] == colors[start + 1, i] && colors[start + 1, i] == colors[start + 2, i] && colors[start + 2, i] == colors[start + 3, i]) && (colors[start, i] == 1))
                    {
                        bWriter.Write("Win Game&" + room_id + "&" + player_type);
                        MessageBox.Show("Player 2 win Congratulation !!!!");
                        reset();
                        disable();
                        //break;
                    }
                    else if ((colors[start, i] == colors[start + 1, i] && colors[start + 1, i] == colors[start + 2, i] && colors[start + 2, i] == colors[start + 3, i]) && (colors[start, i] == 2))
                    {
                        bWriter.Write("Win Game&" + room_id + "&" + player_type);
                        MessageBox.Show("Player 1 win Congratulation !!!!");
                        reset();
                        disable();
                    }
                }
            }

            //Diagonal Win - "/"
            for (int i = 3; i < 6; i++)
            {
                for (start = 0; start <= 3; start++)
                {
                    if ((colors[i, start] == colors[i - 1, start + 1] && colors[i - 1, start + 1] == colors[i - 2, start + 2] && colors[i - 2, start + 2] == colors[i - 3, start + 3]) && (colors[i, start] == 1))
                    {
                        bWriter.Write("Win Game&" + room_id + "&" + player_type);
                        MessageBox.Show("Player 2 win Congratulation !!!!");
                        reset();
                        disable();
                        //  break;
                    }
                    else if ((colors[i, start] == colors[i - 1, start + 1] && colors[i - 1, start + 1] == colors[i - 2, start + 2] && colors[i - 2, start + 2] == colors[i - 3, start + 3]) && (colors[i, start] == 2))
                    {
                        bWriter.Write("Win Game&" + room_id + "&" + player_type);
                        MessageBox.Show("Player 1 win Congratulation !!!!");
                        reset();
                        disable();
                    }
                }
            }

            //Diagonal Win -"\"
            for (int i = 0; i < 3; i++)
            {
                for (start = 0; start < 4; start++)
                {
                    if ((colors[i, start] == colors[i + 1, start + 1] && colors[i + 1, start + 1] == colors[i + 2, start + 2] && colors[i + 2, start + 2] == colors[i + 3, start + 3]) && (colors[i, start] == 1))
                    {
                        bWriter.Write("Win Game&" + room_id + "&" + player_type);
                        MessageBox.Show("Player 2 win Congratulation !!!!");
                        reset();
                        disable();
                        // break;
                    }
                    else if ((colors[i, start] == colors[i + 1, start + 1] && colors[i + 1, start + 1] == colors[i + 2, start + 2] && colors[i + 2, start + 2] == colors[i + 3, start + 3]) && (colors[i, start] == 2))
                    {
                        bWriter.Write("Win Game&" + room_id + "&" + player_type);
                        MessageBox.Show("Player 1 win Congratulation !!!!");
                        reset();
                        disable();
                    }
                }
            }

        }
        public void draw(int x, int y, Color col)
        {
            Graphics g = this.CreateGraphics();

            Ellipse_Color = col;
            Ellipse_brush = new SolidBrush(Ellipse_Color);
            g.FillEllipse(Ellipse_brush, y, x, 80, 80);
            //  flag = true;
        }

      

    }
    public class saved_data
    {
        public int xx;
        public int yy;
        public Color color;
       
    }
}
