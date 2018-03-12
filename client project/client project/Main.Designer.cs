namespace client
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.ListBox_Rooms = new System.Windows.Forms.ListBox();
            this.ListBox_Players = new System.Windows.Forms.ListBox();
            this.btn_create = new System.Windows.Forms.Button();
            this.btn_join = new System.Windows.Forms.Button();
            this.btn_watch = new System.Windows.Forms.Button();
            this.ListBox_ID = new System.Windows.Forms.ListBox();
            this.room_name_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListBox_Rooms
            // 
            this.ListBox_Rooms.FormattingEnabled = true;
            this.ListBox_Rooms.Location = new System.Drawing.Point(97, 137);
            this.ListBox_Rooms.Name = "ListBox_Rooms";
            this.ListBox_Rooms.Size = new System.Drawing.Size(155, 225);
            this.ListBox_Rooms.TabIndex = 0;
            this.ListBox_Rooms.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            // 
            // ListBox_Players
            // 
            this.ListBox_Players.FormattingEnabled = true;
            this.ListBox_Players.Location = new System.Drawing.Point(272, 137);
            this.ListBox_Players.Name = "ListBox_Players";
            this.ListBox_Players.Size = new System.Drawing.Size(168, 225);
            this.ListBox_Players.TabIndex = 1;
            this.ListBox_Players.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            // 
            // btn_create
            // 
            this.btn_create.BackColor = System.Drawing.Color.Black;
            this.btn_create.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_create.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.btn_create.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_create.Location = new System.Drawing.Point(494, 212);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(172, 37);
            this.btn_create.TabIndex = 2;
            this.btn_create.Text = "Create Room";
            this.btn_create.UseVisualStyleBackColor = false;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // btn_join
            // 
            this.btn_join.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_join.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_join.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_join.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.btn_join.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_join.Location = new System.Drawing.Point(494, 268);
            this.btn_join.Name = "btn_join";
            this.btn_join.Size = new System.Drawing.Size(172, 36);
            this.btn_join.TabIndex = 3;
            this.btn_join.Text = "Join Room";
            this.btn_join.UseVisualStyleBackColor = false;
            this.btn_join.Click += new System.EventHandler(this.btn_join_Click);
            // 
            // btn_watch
            // 
            this.btn_watch.AutoEllipsis = true;
            this.btn_watch.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_watch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_watch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_watch.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.btn_watch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_watch.Location = new System.Drawing.Point(494, 326);
            this.btn_watch.Name = "btn_watch";
            this.btn_watch.Size = new System.Drawing.Size(172, 36);
            this.btn_watch.TabIndex = 4;
            this.btn_watch.Text = "Watch Room";
            this.btn_watch.UseVisualStyleBackColor = false;
            this.btn_watch.Click += new System.EventHandler(this.btn_watch_Click);
            // 
            // ListBox_ID
            // 
            this.ListBox_ID.FormattingEnabled = true;
            this.ListBox_ID.Location = new System.Drawing.Point(3, 137);
            this.ListBox_ID.Name = "ListBox_ID";
            this.ListBox_ID.Size = new System.Drawing.Size(78, 225);
            this.ListBox_ID.TabIndex = 5;
            this.ListBox_ID.Visible = false;
            this.ListBox_ID.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            // 
            // room_name_txt
            // 
            this.room_name_txt.Location = new System.Drawing.Point(494, 169);
            this.room_name_txt.Name = "room_name_txt";
            this.room_name_txt.Size = new System.Drawing.Size(172, 20);
            this.room_name_txt.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Room ID";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(140, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Room Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(269, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "number of players per Room ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(511, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "enter Room Name";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(237, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(235, 51);
            this.panel1.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Trajan Pro 3", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(494, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 39);
            this.button1.TabIndex = 12;
            this.button1.Text = "choose color";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(721, 404);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.room_name_txt);
            this.Controls.Add(this.ListBox_ID);
            this.Controls.Add(this.btn_watch);
            this.Controls.Add(this.btn_join);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.ListBox_Players);
            this.Controls.Add(this.ListBox_Rooms);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListBox_Rooms;
        private System.Windows.Forms.ListBox ListBox_Players;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.Button btn_join;
        private System.Windows.Forms.Button btn_watch;
        private System.Windows.Forms.ListBox ListBox_ID;
        private System.Windows.Forms.TextBox room_name_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button1;
    }
}