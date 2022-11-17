using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using Fall2020_CSC403_Project.Properties;

namespace Fall2020_CSC403_Project
{
    public partial class MainMenu : Form
    {
        public SoundPlayer menuMusic = new SoundPlayer(Resources.mainMenuMusic);
        public Settings changeSettings = new Settings();

        public MainMenu()
        {
            InitializeComponent();

            menuMusic.PlayLooping();

        }

        //Start
        private void button1_Click(object sender, EventArgs e)
        {
            FrmLevel newGame = new FrmLevel();

            newGame.UpdateSettings(changeSettings);
            newGame.Show();
            newGame.getMainMenu = this;


            menuMusic.Stop();

            Hide(); //can't Close(), will shut down entire application
        }

        //Quit
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Open Settings
        public void button2_Click(object sender, EventArgs e)
        {
            changeSettings.Menu = this;

            changeSettings.Show();

            Hide();
        }
    }
}
