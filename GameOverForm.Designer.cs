using System.Windows.Forms;

namespace MealyMachineCoinGame
{
    partial class GameOverForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblGameOverMessage;
        private Button btnRestart;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblGameOverMessage = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGameOverMessage
            // 
            this.lblGameOverMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblGameOverMessage.Font = new System.Drawing.Font("Cooper Black", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameOverMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblGameOverMessage.Location = new System.Drawing.Point(244, 142);
            this.lblGameOverMessage.Name = "lblGameOverMessage";
            this.lblGameOverMessage.Size = new System.Drawing.Size(776, 178);
            this.lblGameOverMessage.TabIndex = 1;
            this.lblGameOverMessage.Text = "Game Over Message";
            this.lblGameOverMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblGameOverMessage.Click += new System.EventHandler(this.lblGameOverMessage_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.Transparent;
            this.btnRestart.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestart.Location = new System.Drawing.Point(519, 523);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(211, 65);
            this.btnRestart.TabIndex = 0;
            this.btnRestart.Text = "Continue";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // GameOverForm
            // 
            this.BackgroundImage = global::MealyMachineCoinGame.Properties.Resources.Screenshot_2025_05_14_012251;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1287, 647);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.lblGameOverMessage);
            this.DoubleBuffered = true;
            this.Name = "GameOverForm";
            this.ResumeLayout(false);

        }
    }
}
