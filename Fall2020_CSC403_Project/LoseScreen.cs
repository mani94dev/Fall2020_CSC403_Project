using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project
{
    public partial class LoseScreen : Form
    {
        public LoseScreen()
        {
            this.ControlBox = false;
            this.BackgroundImage = Properties.Resources.GameOverPicture;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            InitializeComponent();
        }

        // exit button
        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        // main menu button
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void LoseScreen_Load(object sender, EventArgs e)
        {

        }
    }
}