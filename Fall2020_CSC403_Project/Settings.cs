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
    public partial class Settings : Form
    {
        public bool maxWindow = false;
        public bool musicOn = true;
        public Settings()
        {
            InitializeComponent();
        }

        public MainMenu Menu { get; set; }

        //go back
        private void startButton_Click(object sender, EventArgs e)
        {
            Menu.Show();
            Hide();
        }

        //maximize window
        public void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                maxWindow = true;
                maximizeWindow(this);
                maximizeWindow(Menu);
            }
            else
            {
                maxWindow = false;
                minimizeWindow(this);
                maximizeWindow(Menu);
            }
        }

        public void maximizeWindow(Form f)
        {
            f.WindowState = FormWindowState.Maximized;
        }

        public void minimizeWindow(Form f)
        {
            f.WindowState = FormWindowState.Normal;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox2.Checked)
            {
                musicOn = false;
                Menu.menuMusic.Stop();
            }
            else
            {
                musicOn = true;
                Menu.menuMusic.PlayLooping();
            }
        }

    }
}
