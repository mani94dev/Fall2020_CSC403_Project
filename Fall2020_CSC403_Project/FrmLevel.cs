using Fall2020_CSC403_Project.code;
using Fall2020_CSC403_Project.Properties;
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project
{
    public partial class FrmLevel : Form
    {
        private Player player;

        private Enemy enemyPoisonPacket;
        private Enemy bossKoolaid;
        private Enemy enemyCheeto;
        private Character[] walls;
        private Character boostChar;

        private DateTime timeBegin;
        private FrmBattle frmBattle;
        Panel panelBox;
        Label labelBox;
        PictureBox boostBox;
        public FrmLevel()
        {
            InitializeComponent();
        }

        private void FrmLevel_Load(object sender, EventArgs e)
        {
            const int PADDING = 7;
            const int NUM_WALLS = 13;

            player = new Player(CreatePosition(picPlayer), CreateCollider(picPlayer, PADDING));
            bossKoolaid = new Enemy(CreatePosition(picBossKoolAid), CreateCollider(picBossKoolAid, PADDING));
            enemyPoisonPacket = new Enemy(CreatePosition(picEnemyPoisonPacket), CreateCollider(picEnemyPoisonPacket, PADDING));
            enemyCheeto = new Enemy(CreatePosition(picEnemyCheeto), CreateCollider(picEnemyCheeto, PADDING));
            bossKoolaid.Img = picBossKoolAid.BackgroundImage;
            enemyPoisonPacket.Img = picEnemyPoisonPacket.BackgroundImage;
            enemyCheeto.Img = picEnemyCheeto.BackgroundImage;

            bossKoolaid.Color = Color.Red;
            enemyPoisonPacket.Color = Color.Green;
            enemyCheeto.Color = Color.FromArgb(255, 245, 161);

            walls = new Character[NUM_WALLS];
            for (int w = 0; w < NUM_WALLS; w++)
            {
                PictureBox pic = Controls.Find("picWall" + w.ToString(), true)[0] as PictureBox;
                walls[w] = new Character(CreatePosition(pic), CreateCollider(pic, PADDING));
            }

            boostBox = Controls.Find("boost", true)[0] as PictureBox;
            boostChar = new Character(CreatePosition(boostBox), CreateCollider(boostBox, 7));
            panelBox = Controls.Find("panel1",true)[0] as Panel;
            labelBox = Controls.Find("label1", true)[0] as Label;

            Game.player = player;
            timeBegin = DateTime.Now;
        }

        private Vector2 CreatePosition(PictureBox pic)
        {
            return new Vector2(pic.Location.X, pic.Location.Y);
        }

        private Collider CreateCollider(PictureBox pic, int padding)
        {
            Rectangle rect = new Rectangle(pic.Location, new Size(pic.Size.Width - padding, pic.Size.Height - padding));
            return new Collider(rect);
        }

        private void FrmLevel_KeyUp(object sender, KeyEventArgs e)
        {
            player.ResetMoveSpeed();
        }

        private void tmrUpdateInGameTime_Tick(object sender, EventArgs e)
        {
            TimeSpan span = DateTime.Now - timeBegin;
            string time = span.ToString(@"hh\:mm\:ss");
            lblInGameTime.Text = "Time: " + time.ToString();
        }

        private void tmrPlayerMove_Tick(object sender, EventArgs e)
        {

            // move player
            player.Move();

            // check collision with walls
            if (HitAWall(player))
            {
                player.MoveBack();
            }



            // check collision with enemies
            if (HitAChar(player, enemyPoisonPacket) && !picEnemyPoisonPacket.IsDisposed)
            {
                Fight(enemyPoisonPacket);
            }
            if (HitAChar(player, enemyCheeto) && !picEnemyCheeto.IsDisposed)
            {
                Fight(enemyCheeto);
            }
            if (HitAChar(player, bossKoolaid) && !picBossKoolAid.IsDisposed)
            {
                Fight(bossKoolaid);
            }
            if (boostChar != null && HitBoost(player, boost) && !boost.IsDisposed) {
                SoundPlayer simpleSound = new SoundPlayer(Resources.health_consume);
                simpleSound.Play();
                UpdatePlayerHealth(player);
                boost.Dispose();
            }
            if (player.Health <= 0 && !picPlayer.IsDisposed)
            {
                picPlayer.Visible = false;
                picPlayer.Enabled = false;
                picPlayer.Dispose();
            }
            else {
                picPlayer.Location = new Point((int)player.Position.x, (int)player.Position.y);
            }
            if (enemyPoisonPacket.Health <= 0 && !picEnemyPoisonPacket.IsDisposed)
            {
                picEnemyPoisonPacket.Visible = false;
                picEnemyPoisonPacket.Enabled = false;
                picEnemyPoisonPacket.Dispose();
            }
            if (enemyCheeto.Health <= 0 && !picEnemyCheeto.IsDisposed)
            {
                picEnemyCheeto.Visible = false;
                picEnemyCheeto.Enabled = false;
                picEnemyCheeto.Dispose();
            }
            if (bossKoolaid.Health <= 0 && !picBossKoolAid.IsDisposed) {
                picBossKoolAid.Visible = false;
                picBossKoolAid.Enabled = false;
                picBossKoolAid.Dispose();
            }


        }

        private void UpdatePlayerHealth(Player player)
        {
            player.AlterHealth(12);
        }

        private bool HitBoost(Player player, PictureBox boost)
        {
            return player.Collider.Intersects(boostChar.Collider);
        }

        private bool HitAWall(Character c)
        {
            bool hitAWall = false;
            for (int w = 0; w < walls.Length; w++)
            {
                if (c.Collider.Intersects(walls[w].Collider))
                {
                    hitAWall = true;
                    break;
                }
            }
            return hitAWall;
        }

        private bool HitAChar(Character you, Character other)
        {
            return you.Collider.Intersects(other.Collider);
        }

        private void Fight(Enemy enemy)
        {
            player.ResetMoveSpeed();
            player.MoveBack();
            frmBattle = FrmBattle.GetInstance(enemy);
            frmBattle.Show();

            if (enemy == bossKoolaid)
            {
                frmBattle.SetupForBossBattle();
            }

            
        }

        private void FrmLevel_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    player.GoLeft();
                    break;

                case Keys.Right:
                    player.GoRight();
                    break;

                case Keys.Up:
                    player.GoUp();
                    break;

                case Keys.Down:
                    player.GoDown();
                    break;

                default:
                    player.ResetMoveSpeed();
                    break;
            }
        }

        private void lblInGameTime_Click(object sender, EventArgs e)
        {

        }

        private void boost_Click(object sender, EventArgs e)
        {

        }
    }
}
