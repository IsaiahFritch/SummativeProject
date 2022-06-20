using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SummativeProject
{
    public partial class Form1 : Form
    {
        ////Shared Variables


        public static int TopHeartSetting = 3;
        public static int MiddleHeartSetting = 3;
        public static int BottomHeartSetting = 3;



        ////Lists
        //player parts
        Rectangle player = new Rectangle(700 - 10, 700, 8, 8);
        List<Rectangle> playerProjectiles = new List<Rectangle>();
        List<int> playerProjectilesSpeedsX = new List<int>();
        List<int> playerProjectilesSpeedsY = new List<int>();
        List<int> playerProjectilesLifespan = new List<int>();
        List<int> playerProjectileSize = new List<int>();
        //boss parts
        Rectangle Ronald = new Rectangle(700 - 40, 100 + 40, 80, 80);
        List<Rectangle> enemyProjectiles = new List<Rectangle>();
        List<int> enemyProjectilesSpeedsX = new List<int>();
        List<int> enemyProjectilesSpeedsY = new List<int>();
        List<int> enemyProjectilesWait = new List<int>();

        ////Lives
        static Rectangle topHeart = new Rectangle(1116, 136, 263, 177);
        static Rectangle middleHeart = new Rectangle(1116, 349, 263, 177);
        static Rectangle bottomHeart = new Rectangle(1116, 561, 263, 177);

        ////Variables
        int counter = 0;
        int ronaldAttackCounter = 250;

        int playerSpeed = 5;
        int dodgeCooldown = 0;
        int immunityCooldown = 10;
        int playerHealth = 3;
        int playerProjectileSizeTemp = 0;
        int ronaldHealth = 2000;
        int ronaldPosition = 0;
        string ronaldMovePattern = "stride";
        int ronaldMovePatternSwitch = 1;
        bool clockwise = true;
        int previousRonaldPosition = 0;
        int attackSetOneSwitch = 0;
        int individualAttackSetOne = 0;
        int individualAttackSetTwo = 0;
        int attackSetTwoSwitch = 0;
        bool ronaldShouldBeMoving = true;

        Random randGen = new Random();

        ////Player controls
        //movement
        bool moveUp = false;
        bool moveDown = false;
        bool moveLeft = false;
        bool moveRight = false;
        bool isMoving = false;
        //dodge
        bool dodgeDown = false;
        //shoot
        bool spaceDown = false;

        ////Difficulty Settings
        int difficultyMultiplier = 2;

        ////Brushes, Sounds, Images
        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);

        SolidBrush darkredBrush = new SolidBrush(Color.DarkRed);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush orangeredBrush = new SolidBrush(Color.OrangeRed);
        SolidBrush orangeBrush = new SolidBrush(Color.Orange);
        SolidBrush goldBrush = new SolidBrush(Color.Gold);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);

        SolidBrush inactiveBrush = new SolidBrush(Color.Black);

        Image backgroundImage = Properties.Resources.AnotherBackground;
        Image foregroundImage = Properties.Resources.Foreground;

        Image yellowFireImage = Properties.Resources.YellowFire2;
        Image yellowOrangeFireImage = Properties.Resources.YellowOrangeFire;
        Image orangeFireImage = Properties.Resources.OrangeFire;
        Image orangeRedFireImage = Properties.Resources.OrangeRedFire;
        Image redFireImage = Properties.Resources.RedFire;
        Image redAshFireImage = Properties.Resources.RedAshFire;

        static Image hasHeartImage = Properties.Resources.HasHeart;
        static Image hasBonusHeartImage = Properties.Resources.HasBonusHeart;
        static Image deadHeartImage = Properties.Resources.DeadHeart;

        static int firstHeart = 0;



        public Form1()
        {
            InitializeComponent();

            ////Parenting
            //topHeartBoxImage.Parent = foregroundPictureBox; change to be parented onto the right forground
            //middleHeartBoxImage.Parent = foregroundPictureBox;
            //bottomHeartBoxImage.Parent = foregroundPictureBox;
        }

        public static void HeartVisuals()
        {
            //top heart
            if (TopHeartSetting == 0)
            {
                //topHeartBoxImage.BackgroundImage = null;
                firstHeart = 0;
            }
            if (TopHeartSetting == 1)
            {
                topHeartBoxImage.BackgroundImage = hasHeartImage;
            }
            if (TopHeartSetting == 2)
            {
                topHeartBoxImage.BackgroundImage = hasBonusHeartImage;
            }
            if (TopHeartSetting == 3)
            {
                topHeartBoxImage.BackgroundImage = deadHeartImage;
            }


            //middle heart
            if (MiddleHeartSetting == 0)
            {
                middleHeartBoxImage.BackgroundImage = null;
            }
            if (MiddleHeartSetting == 1)
            {
                middleHeartBoxImage.BackgroundImage = hasHeartImage;
            }
            if (MiddleHeartSetting == 2)
            {
                middleHeartBoxImage.BackgroundImage = hasBonusHeartImage;
            }
            if (MiddleHeartSetting == 3)
            {
                middleHeartBoxImage.BackgroundImage = deadHeartImage;
            }

            //bottom heart
            if (BottomHeartSetting == 0)
            {
                bottomHeartBoxImage.BackgroundImage = null;
            }
            if (BottomHeartSetting == 1)
            {
                bottomHeartBoxImage.BackgroundImage = hasHeartImage;
            }
            if (BottomHeartSetting == 2)
            {
                bottomHeartBoxImage.BackgroundImage = hasBonusHeartImage;
            }
            if (BottomHeartSetting == 3)
            {
                bottomHeartBoxImage.BackgroundImage = deadHeartImage;
            }
        }

        public void HeartVisualContinued()
        {
            topHeartBoxImage.BackgroundImage = null;

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
           
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }
        //{
        //    //background 
        //    e.Graphics.DrawImage(backgroundImage, 0, 0, 1400, 900);

        //    //enemy projectiles
        //    for (int i = 0; i < enemyProjectiles.Count(); i++)
        //    {
        //        if (enemyProjectilesWait[i] <= 0)
        //        {
        //            e.Graphics.FillEllipse(darkredBrush, enemyProjectiles[i]);
        //        }
        //        else
        //        {
        //            e.Graphics.FillEllipse(inactiveBrush, enemyProjectiles[i]);
        //        }
        //    }

        //    //player projectiles -- flamethrower: burn extra calories!
        //    for (int i = 0; i < playerProjectiles.Count(); i++)
        //    {
        //        if (playerProjectilesLifespan[i] < 20)
        //        {
        //            //e.Graphics.FillRectangle(darkredBrush, playerProjectiles[i]);
        //            e.Graphics.DrawImage(redAshFireImage, playerProjectiles[i].X, playerProjectiles[i].Y, playerProjectileSize[i] + 20, playerProjectileSize[i] + 20);
        //        }
        //        else if (playerProjectilesLifespan[i] < 30)
        //        {
        //            //e.Graphics.FillRectangle(redBrush, playerProjectiles[i]);
        //            e.Graphics.DrawImage(redFireImage, playerProjectiles[i].X, playerProjectiles[i].Y, playerProjectileSize[i] + 20, playerProjectileSize[i] + 20);
        //        }
        //        else if (playerProjectilesLifespan[i] < 40)
        //        {
        //            //e.Graphics.FillRectangle(orangeredBrush, playerProjectiles[i]);
        //            e.Graphics.DrawImage(orangeRedFireImage, playerProjectiles[i].X, playerProjectiles[i].Y, playerProjectileSize[i] + 20, playerProjectileSize[i] + 20);
        //        }
        //        else if (playerProjectilesLifespan[i] < 45)
        //        {
        //            //e.Graphics.FillRectangle(orangeBrush, playerProjectiles[i]);
        //            e.Graphics.DrawImage(orangeFireImage, playerProjectiles[i].X, playerProjectiles[i].Y, playerProjectileSize[i] + 20, playerProjectileSize[i] + 20);
        //        }
        //        else if (playerProjectilesLifespan[i] < 62)
        //        {
        //            //e.Graphics.FillRectangle(goldBrush, playerProjectiles[i]);
        //            e.Graphics.DrawImage(yellowOrangeFireImage, playerProjectiles[i].X, playerProjectiles[i].Y, playerProjectileSize[i] + 20, playerProjectileSize[i] + 20);
        //        }
        //        else if (playerProjectilesLifespan[i] < 81)
        //        {
        //            e.Graphics.DrawImage(yellowFireImage, playerProjectiles[i].X, playerProjectiles[i].Y, playerProjectileSize[i] + 20, playerProjectileSize[i] + 20);
        //        }
        //    }


        //    //cover the projectiles
        //    e.Graphics.DrawImage(foregroundImage, 0, 0, 1400, 900);


        //    //hearts  too high quality, must be lowered
        //    e.Graphics.DrawImage(hasHeartImage, topHeart);
        //    e.Graphics.DrawImage(hasHeartImage, middleHeart);
        //    e.Graphics.DrawImage(hasBonusHeartImage, bottomHeart);


        //    //cooldown label
        //    cooldownTimerLabel.Text = $"{dodgeCooldown}";
        //    cooldownTimerLabel.Text += $"\n{ronaldHealth}";
        //    cooldownTimerLabel.Text += $"\n{playerHealth}";

        //    //player
        //    e.Graphics.FillEllipse(blueBrush, player);

        //    //Uncle Ron
        //    e.Graphics.FillRectangle(blueBrush, Ronald);
        //}


        private void Form1_Load(object sender, EventArgs e)
        {
            GameScreen gs = new GameScreen();

            gs.Location = new Point((this.ClientSize.Width - gs.Width) / 2, (this.ClientSize.Height - gs.Height) / 2);
            this.Controls.Add(gs);

            gs.Focus();
        }
    }
}
