using Fall2020_CSC403_Project.code;
using Fall2020_CSC403_Project.Properties;
using System;
using System.Drawing;
using System.Media;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project
{
    public partial class FrmBattle : Form
    {
        public static FrmBattle instance = null;
        private Enemy enemy;
        private Player player;
        private WinScreen winScreen;
        private LoseScreen loseScreen;
        bool bossFightStarted = false;
        int dresscode = 1;
        private FrmBattle()
        {
            InitializeComponent();
            player = Game.player;
        }

        public void Setup()
        {
            playerdress();
            // update for this enemy
            picEnemy.BackgroundImage = enemy.Img;
            picEnemy.Refresh();
            BackColor = enemy.Color;
            picBossBattle.Visible = false;

            // Observer pattern
            enemy.AttackEvent += PlayerDamage;
            player.AttackEvent += EnemyDamage;

            // show health
            UpdateHealthBars();
        }

        public void SetupForBossBattle()
        {
            picBossBattle.Location = Point.Empty;
            picBossBattle.Size = ClientSize;
            picBossBattle.Visible = true;

            SoundPlayer simpleSound = new SoundPlayer(Resources.final_battle);
            simpleSound.Play();

            tmrFinalBattle.Enabled = true;
            bossFightStarted = true;
        }

        public static FrmBattle GetInstance(Enemy enemy, int dresscode)
        {
            if (instance == null)
            {

                instance = new FrmBattle();
                instance.enemy = enemy;
                instance.dresscode = dresscode;
                instance.Setup();
            }
            return instance;
        }


        private void playerdress()
        {
            if (dresscode == 1)
            {
                picPlayer.BackgroundImage = Properties.Resources.newchar1;
            }
            else if (dresscode == 2)
            {
                picPlayer.BackgroundImage = Properties.Resources.newchar2;
            }
            else if (dresscode == 3)
            {
                picPlayer.BackgroundImage = Properties.Resources.player;
            }

        }


        private void UpdateHealthBars()
        {
            float playerHealthPer = player.Health / (float)player.MaxHealth;
            float enemyHealthPer = enemy.Health / (float)enemy.MaxHealth;

            const int MAX_HEALTHBAR_WIDTH = 226;
            lblPlayerHealthFull.Width = (int)(MAX_HEALTHBAR_WIDTH * playerHealthPer);
            lblEnemyHealthFull.Width = (int)(MAX_HEALTHBAR_WIDTH * enemyHealthPer);

            lblPlayerHealthFull.Text = player.Health.ToString();
            lblEnemyHealthFull.Text = enemy.Health.ToString();
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            player.OnAttack(-4);
            if (enemy.Health > 0)
            {
                enemy.OnAttack(-2);
            }

            UpdateHealthBars();
            if (bossFightStarted == true)
            {
                if (enemy.Health <= 0)
                {
                    instance = null;
                    Close();
                    winScreen = new WinScreen();
                    winScreen.Show();
                }
            }

            if (enemy.Health <= 0)
            {
                instance = null;
                Close();
            }

            else if (player.Health <= 0)
            {
                instance = null;
                Close();
                loseScreen = new LoseScreen();
                loseScreen.Show();
            }

        }

        private void EnemyDamage(int amount)
        {
            enemy.AlterHealth(amount);
        }

        private void PlayerDamage(int amount)
        {
            player.AlterHealth(amount);
        }

        private void tmrFinalBattle_Tick(object sender, EventArgs e)
        {
            picBossBattle.Visible = false;
            tmrFinalBattle.Enabled = false;
        }
    }
}
