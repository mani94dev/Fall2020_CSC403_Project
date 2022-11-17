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
    public partial class FrmPause : Form
    {
        public FrmLevel getGameLevel;

        public FrmPause()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmPause_Load(object sender, EventArgs e)
        {

        }

        //quit to main menu
        private void button2_Click(object sender, EventArgs e)
        {
            MainMenu newMainMenu = new MainMenu();

            getGameLevel.Close();

            newMainMenu.Show();

            Close();
        }
    }
}
