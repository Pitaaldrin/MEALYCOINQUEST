using System;
using System.Drawing;
using System.Windows.Forms;

namespace MealyMachineCoinGame
{
    public partial class GameOverForm : Form
    {
        public GameOverForm(string message)
        {
            InitializeComponent();
            lblGameOverMessage.Text = message;
            this.FormBorderStyle = FormBorderStyle.None; // Remove the border and title bar
            this.WindowState = FormWindowState.Maximized; // Make the form full screen
            this.StartPosition = FormStartPosition.CenterScreen; // Center it on the screen

            // Optional: Set background color for the full screen
            this.BackColor = Color.Black;
            lblGameOverMessage.ForeColor = Color.White;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            // Close the GameOverForm and return to the main form
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void lblGameOverMessage_Click(object sender, EventArgs e)
        {

        }
    }
}
