using Fall2020_CSC403_Project.code;
using Fall2020_CSC403_Project.Properties;
using System;
using System.Drawing;
using System.Media;
using System.Reflection.Emit;
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
        bool bossFightStarted = false;
        int dresscode = 1;
        public bool battleMusicOn;
        private SoundPlayer music;
        public FrmLevel level;
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
                picPlayer.BackgroundImage = Resources.hero1;
            }
            else if (dresscode == 2)
            {
                picPlayer.BackgroundImage = Resources.hero2;
            }
            else if (dresscode == 3)
            {
                picPlayer.BackgroundImage = Resources.hero3;
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
                if (battleMusicOn)
                {
                    music.Stop();
                }
                Close();
                winScreen = new WinScreen();
                winScreen.Show();
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

        private void PlayNonBossMusic()
        {
            music = new SoundPlayer(Resources.NonBossTheme);
            music.PlayLooping();
        }

        private void PlayBossMusic()
        {
            music = new SoundPlayer(Resources.FinalBattleTheme);
            music.PlayLooping();
        }



        public void UpdateSettings(bool musicIsOn, bool enemyIsBoss)
        {
            if (musicIsOn && enemyIsBoss)
            {
                PlayBossMusic();
            }
            else if (musicIsOn)
            {
                PlayNonBossMusic();
            }
        }

        private void FrmBattle_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (level.lvlMusicOn)
            {
                music.Stop(); //stop any music playing
            }
        }
    }
}
