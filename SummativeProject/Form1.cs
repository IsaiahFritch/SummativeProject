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
        //public static string gameState = "StartUpScreen";
        public static string gameState = "lose";

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
        static int secondHeart = 0;
        static int thirdHeart = 0;



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
            else if (TopHeartSetting == 1)
            {
                //topHeartBoxImage.BackgroundImage = hasHeartImage;
                firstHeart = 1;
            }
            else if (TopHeartSetting == 2)
            {
                //topHeartBoxImage.BackgroundImage = hasBonusHeartImage;
                firstHeart = 2;
            }
            else if (TopHeartSetting == 3)
            {
                //topHeartBoxImage.BackgroundImage = deadHeartImage;
                firstHeart = 3;
            }


            //middle heart
            if (MiddleHeartSetting == 0)
            {
                //middleHeartBoxImage.BackgroundImage = null;
                secondHeart = 0;
            }
            else if (MiddleHeartSetting == 1)
            {
                //middleHeartBoxImage.BackgroundImage = hasHeartImage;
                secondHeart = 1;
            }
            else if (MiddleHeartSetting == 2)
            {
                //middleHeartBoxImage.BackgroundImage = hasBonusHeartImage;
                secondHeart = 2;
            }
            else if (MiddleHeartSetting == 3)
            {
                //middleHeartBoxImage.BackgroundImage = deadHeartImage;
                secondHeart = 3;
            }

            //bottom heart
            if (BottomHeartSetting == 0)
            {
                //bottomHeartBoxImage.BackgroundImage = null;
                thirdHeart = 0;
            }
            else if (BottomHeartSetting == 1)
            {
                //bottomHeartBoxImage.BackgroundImage = hasHeartImage;
                thirdHeart = 1;
            }
            else if (BottomHeartSetting == 2)
            {
                //bottomHeartBoxImage.BackgroundImage = hasBonusHeartImage;
                thirdHeart = 2;
            }
            else if (BottomHeartSetting == 3)
            {
                //bottomHeartBoxImage.BackgroundImage = deadHeartImage;
                thirdHeart = 3;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameState == "StartUpScreen")
            {
                switch (e.KeyCode)
                {
                    case Keys.E:
                        gameState = "easy";
                        break;
                    case Keys.M:
                        gameState = "medium";
                        break;
                    case Keys.H:
                        gameState = "hard";
                        break;
                }
            }

            if (gameState == "lose" || gameState == "win")
                switch (e.KeyCode)
                {

                    case Keys.R:
                        gameState = "StartUpScreen";
                        gameTimer.Enabled = true;
                        break;
                }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (gameState == "easy")
            {
                //set things up
                GameScreen.playerMaxHealth = 6;
                GameScreen.playerMaxHealth = 3;

                topHeartBoxImage.Visible = true;
                middleHeartBoxImage.Visible = true;
                bottomHeartBoxImage.Visible = true;
                foregroundPictureBox.Visible = true;

                startUpScreenBox.Visible = false;

                GameScreen.difficultyMultiplier = 1;

                //run game
                GameScreen gs = new GameScreen();

                gs.Location = new Point((this.ClientSize.Width - gs.Width) / 2, (this.ClientSize.Height - gs.Height) / 2);
                this.Controls.Add(gs);

                gameTimer.Enabled = false;

                gs.Focus();
            }
            else if (gameState == "medium")
            {
                //set things up
                GameScreen.playerMaxHealth = 4;
                GameScreen.playerMaxHealth = 2;

                topHeartBoxImage.Visible = false;
                middleHeartBoxImage.Visible = true;
                bottomHeartBoxImage.Visible = true;
                foregroundPictureBox.Visible = true;

                startUpScreenBox.Visible = false;

                GameScreen.difficultyMultiplier = 2;

                //run game
                GameScreen gs = new GameScreen();

                gs.Location = new Point((this.ClientSize.Width - gs.Width) / 2, (this.ClientSize.Height - gs.Height) / 2);
                this.Controls.Add(gs);

                gameTimer.Enabled = false;

                gs.Focus();
            }
            else if (gameState == "hard")
            {
                //set things up
                GameScreen.playerMaxHealth = 2;
                GameScreen.playerMaxHealth = 1;

                topHeartBoxImage.Visible = false;
                middleHeartBoxImage.Visible = false;
                bottomHeartBoxImage.Visible = true;
                foregroundPictureBox.Visible = true;

                startUpScreenBox.Visible = false;

                GameScreen.difficultyMultiplier = 3;

                //run game
                GameScreen gs = new GameScreen();

                gs.Location = new Point((this.ClientSize.Width - gs.Width) / 2, (this.ClientSize.Height - gs.Height) / 2);
                this.Controls.Add(gs);

                gameTimer.Enabled = false;

                gs.Focus();
            }
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == "StartUpScreen")
            {
                startUpScreenBox.Visible = true;
                winScreenBox.Visible = false;
                deathScreenBox.Visible = false;

                topHeartBoxImage.Visible = false;
                middleHeartBoxImage.Visible = false;
                bottomHeartBoxImage.Visible = false;
                foregroundPictureBox.Visible = false;
            }
            else if (gameState == "lose")
            {
                startUpScreenBox.Visible = false;
                winScreenBox.Visible = false;
                deathScreenBox.Visible = true;

                topHeartBoxImage.Visible = false;
                middleHeartBoxImage.Visible = false;
                bottomHeartBoxImage.Visible = false;
                foregroundPictureBox.Visible = false;

                gameTimer.Enabled = true;
            }
            else if (gameState == "win")
            {
                startUpScreenBox.Visible = false;
                winScreenBox.Visible = true;
                deathScreenBox.Visible = false;

                topHeartBoxImage.Visible = false;
                middleHeartBoxImage.Visible = false;
                bottomHeartBoxImage.Visible = false;
                foregroundPictureBox.Visible = false;

                gameTimer.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
