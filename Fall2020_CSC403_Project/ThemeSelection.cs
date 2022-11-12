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
    public partial class ThemeSelection : Form
    {
        public FrmLevel frmLevel;
        public ThemeSelection()
        {
            InitializeComponent();
        }
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
            frmLevel = FrmLevel.GetInstance();
            frmLevel.theme = "theme1";
            frmLevel.Show();

        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
            frmLevel = FrmLevel.GetInstance();
            frmLevel.theme = "theme2";
            frmLevel.Show();
        }


        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
            frmLevel = FrmLevel.GetInstance();
            frmLevel.theme = "theme3";
            frmLevel.Show();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            StartMenu start = new StartMenu();
            start.Show();
            this.Hide();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLevel = FrmLevel.GetInstance();
            frmLevel.theme = "theme1";
            frmLevel.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLevel = FrmLevel.GetInstance();
            frmLevel.theme = "theme2";
            frmLevel.Show();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLevel = FrmLevel.GetInstance();
            frmLevel.theme = "theme3";
            frmLevel.Show();
        }
    }
}