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
        public static FrmLevel instance = null;
        private Player player;

        private Enemy enemyPoisonPacket;
        private Enemy bossKoolaid;
        private Enemy enemyCheeto;
        private Character[] walls;
        private Character boostChar;
        private Character boostChar2;

        private DateTime timeBegin;
        private FrmBattle frmBattle;
        Panel panelBox;
        Label labelBox;
        PictureBox boostBox;
        PictureBox boostBox2;
        String defText = "Recent Updates are : \n";

        bool displayRestart = true;
        bool displayMenuDifficult = false;
        public String theme;
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
                if (theme == "theme1")
                {
                    pic.BackgroundImage = Resources.brick_Wall_2;
                }
                else if (theme == "theme2")
                {
                    pic.BackgroundImage = Resources.brick_wall_1;
                }
                else
                {
                    pic.BackgroundImage = Resources.wall;
                }
                walls[w] = new Character(CreatePosition(pic), CreateCollider(pic, PADDING));
            }

            boostBox = Controls.Find("boost", true)[0] as PictureBox;
            boostBox2 = Controls.Find("pictureBox4", true)[0] as PictureBox;
            boostChar = new Character(CreatePosition(boostBox), CreateCollider(boostBox, 7));
            boostChar2 = new Character(CreatePosition(boostBox2), CreateCollider(boostBox2, 7));
            panelBox = Controls.Find("panel1", true)[0] as Panel;
            labelBox = Controls.Find("label1", true)[0] as Label;
            Game.player = player;
            timeBegin = DateTime.Now;
        }

        private void FrmLevel_Load()
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
                if (theme == "theme1")
                {
                    pic.BackgroundImage = Resources.brick_Wall_2;
                }
                else if (theme == "theme2")
                {
                    pic.BackgroundImage = Resources.brick_wall_1;
                }
                else
                {
                    pic.BackgroundImage = Resources.wall;
                }
                walls[w] = new Character(CreatePosition(pic), CreateCollider(pic, PADDING));
            }

            boostBox = Controls.Find("boost", true)[0] as PictureBox;
            boostBox2 = Controls.Find("pictureBox4", true)[0] as PictureBox;
            boostChar = new Character(CreatePosition(boostBox), CreateCollider(boostBox, 7));
            boostChar2 = new Character(CreatePosition(boostBox2), CreateCollider(boostBox2, 7));
            panelBox = Controls.Find("panel1", true)[0] as Panel;
            labelBox = Controls.Find("label1", true)[0] as Label;
            Game.player = player;
            timeBegin = DateTime.Now;
        }

        public static FrmLevel GetInstance()
        {
            if (instance == null)
            {
                instance = new FrmLevel();
                instance.FrmLevel_Load();
            }
            return instance;
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
            if (displayMenuDifficult)
            {
                // move player
                player.Move();

                // check collision with walls
                if (HitAWall(player))
                {
                    labelBox.Text = defText + "Wall Collision";
                    player.MoveBack();
                }



                // check collision with enemies
                if (HitAChar(player, enemyPoisonPacket) && !picEnemyPoisonPacket.IsDisposed)
                {
                    labelBox.Text = defText + "Fight Against Poison";
                    Fight(enemyPoisonPacket);
                }
                if (HitAChar(player, enemyCheeto) && !picEnemyCheeto.IsDisposed)
                {
                    labelBox.Text = defText + "Fight Against Cheeto";
                    Fight(enemyCheeto);
                }
                if (HitAChar(player, bossKoolaid) && !picBossKoolAid.IsDisposed)
                {
                    labelBox.Text = defText + "Fight Against Boss";
                    Fight(bossKoolaid);
                }
                if (!boost.IsDisposed && picEnemyPoisonPacket.IsDisposed) {
                    boostBox.Visible = true;
                    boostBox.Enabled = true;
                }
                if (HitBoost(player) && !boost.IsDisposed && picEnemyPoisonPacket.IsDisposed)
                {
                    labelBox.Text = defText + "Health increased by 6";
                    UpdatePlayerHealth(player);
                    boost.Dispose();
                }
                if (!pictureBox4.IsDisposed && picEnemyCheeto.IsDisposed)
                {
                    boostBox2.Visible = true;
                    boostBox2.Enabled = true;
                }
                if (HitBoost2(player) && !pictureBox4.IsDisposed && picEnemyCheeto.IsDisposed)
                {
                    labelBox.Text = defText + "Health increased by 6";
                    UpdatePlayerHealth(player);
                    pictureBox4.Dispose();
                }
                if (player.Health <= 0 && !picPlayer.IsDisposed)
                {
                    picPlayer.Visible = false;
                    picPlayer.Enabled = false;
                    picPlayer.Dispose();
                }
                else
                {
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
                if (bossKoolaid.Health <= 0 && !picBossKoolAid.IsDisposed)
                {
                    picBossKoolAid.Visible = false;
                    picBossKoolAid.Enabled = false;
                    picBossKoolAid.Dispose();
                }



                //if ((enemyPoisonPacket.Health <= 0 && enemyCheeto.Health <= 0 && bossKoolaid.Health <= 0) || player.Health <= 0)
                //{
                //    displayRestart = false;
                //    pictureBox1.Visible = true;
                //    pictureBox1.Enabled = true;
                //    pictureBox3.Visible = true;
                //    pictureBox3.Enabled = true;
                //}

            }
         


        }

        private void UpdatePlayerHealth(Player player)
        {
            player.AlterHealth(12);
        }

        private bool HitBoost(Player player)
        {
            return player.Collider.Intersects(boostChar.Collider);
        }

        private bool HitBoost2(Player player)
        {
            return player.Collider.Intersects(boostChar2.Collider);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label1.Text = defText + " Restarting the Game";
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            Console.WriteLine(coordinates.X + "   " + coordinates.Y);
            if (coordinates.X > 45 && coordinates.X < 90 && coordinates.Y > 50 && coordinates.Y <= 90)
            {
                Application.Restart();
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            Console.WriteLine(coordinates.X + "   " + coordinates.Y);
            if ( coordinates.X > 62 && coordinates.X < 111 && coordinates.Y > 56 && coordinates.Y < 67)
            {
                // nothing to do normal gameplay using defaults
            }
            else if ( coordinates.X > 62 && coordinates.X < 111 && coordinates.Y > 75 && coordinates.Y < 89)
            {
                increaseDifficultyMedium(10);
            }
            else if (coordinates.X > 62 && coordinates.X < 111 &&  coordinates.Y > 97 && coordinates.Y < 111)
            {

                increaseDifficultyHard(15);
            }

            pictureBox2.Enabled = false;
            pictureBox2.Visible = false;
            pictureBox2.Dispose();
            displayMenuDifficult = true;




        }

        private void increaseDifficultyHard(int health)
        {
            //bossKoolaid.MaxHealth =+ health;
            //enemyCheeto.MaxHealth =+ health;
            //enemyCheeto.MaxHealth =+ health;
            //bossKoolaid.Health = +health;
            //enemyCheeto.Health = +health;
            //enemyCheeto.Health = +health;
            bossKoolaid.strength = 3;
            player.GO_INC = 2;

        }

        private void increaseDifficultyMedium(int health)
        {
            //bossKoolaid.MaxHealth =+ health;
            //enemyCheeto.MaxHealth =+ health;
            //enemyCheeto.MaxHealth =+ health;
            //bossKoolaid.Health = +health;
            //enemyCheeto.Health = +health;
            //enemyCheeto.Health = +health;
            bossKoolaid.strength = 2.5f;
            player.GO_INC = 3;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            label1.Text = defText + " Closing the Game";
            Close();
            

        }
    }
}
