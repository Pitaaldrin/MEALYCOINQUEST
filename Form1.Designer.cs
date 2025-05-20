namespace MealyMachineCoinGame
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnStartRestart;
        private System.Windows.Forms.Panel pnlCoinsBox;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnStartRestart = new System.Windows.Forms.Button();
            this.pnlCoinsBox = new System.Windows.Forms.Panel();
            this.lblTimer = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartRestart
            // 
            this.btnStartRestart.BackColor = System.Drawing.Color.Transparent;
            this.btnStartRestart.BackgroundImage = global::MealyMachineCoinGame.Properties.Resources.Screenshot_2025_05_14_012251;
            this.btnStartRestart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnStartRestart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(131)))), ((int)(((byte)(210)))));
            this.btnStartRestart.FlatAppearance.BorderSize = 2;
            this.btnStartRestart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStartRestart.Font = new System.Drawing.Font("Cooper Black", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartRestart.ForeColor = System.Drawing.Color.White;
            this.btnStartRestart.Location = new System.Drawing.Point(110, 127);
            this.btnStartRestart.Name = "btnStartRestart";
            this.btnStartRestart.Size = new System.Drawing.Size(200, 50);
            this.btnStartRestart.TabIndex = 1;
            this.btnStartRestart.Text = "Start Game";
            this.btnStartRestart.UseVisualStyleBackColor = false;
            this.btnStartRestart.Click += new System.EventHandler(this.btnStartRestart_Click);
            // 
            // pnlCoinsBox
            // 
            this.pnlCoinsBox.BackColor = System.Drawing.Color.LightGray;
            this.pnlCoinsBox.BackgroundImage = global::MealyMachineCoinGame.Properties.Resources.Screenshot_2025_05_13_121413;
            this.pnlCoinsBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlCoinsBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlCoinsBox.Location = new System.Drawing.Point(2, 185);
            this.pnlCoinsBox.Name = "pnlCoinsBox";
            this.pnlCoinsBox.Size = new System.Drawing.Size(1273, 450);
            this.pnlCoinsBox.TabIndex = 8;
            this.pnlCoinsBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCoinsBox_Paint);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.BackColor = System.Drawing.Color.Transparent;
            this.lblTimer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblTimer.Font = new System.Drawing.Font("Cooper Black", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTimer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTimer.Location = new System.Drawing.Point(874, 83);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(274, 60);
            this.lblTimer.TabIndex = 6;
            this.lblTimer.Text = "Time: 40s";
            this.lblTimer.Click += new System.EventHandler(this.lblTimer_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::MealyMachineCoinGame.Properties.Resources.Screenshot_2025_05_14_0122511;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnStartRestart);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 180);
            this.panel1.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Cooper Black", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Gold;
            this.label12.Location = new System.Drawing.Point(442, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(163, 48);
            this.label12.TabIndex = 11;
            this.label12.Text = "State: -";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Cooper Black", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label9.Location = new System.Drawing.Point(442, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(492, 36);
            this.label9.TabIndex = 10;
            this.label9.Text = "Game message appears here...";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Cooper Black", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Gold;
            this.label10.Location = new System.Drawing.Point(442, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(175, 48);
            this.label10.TabIndex = 9;
            this.label10.Text = "Level: 1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Cooper Black", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Gold;
            this.label11.Location = new System.Drawing.Point(442, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(181, 48);
            this.label11.TabIndex = 8;
            this.label11.Text = "Coins: 0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::MealyMachineCoinGame.Properties.Resources.Screenshot_2025_05_13_120400;
            this.pictureBox1.Location = new System.Drawing.Point(1069, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 171);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::MealyMachineCoinGame.Properties.Resources.Screenshot_2025_05_14_012251;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1287, 647);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.pnlCoinsBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Mealy Machine Coin Game";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
