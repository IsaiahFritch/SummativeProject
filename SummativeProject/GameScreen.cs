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
    public partial class GameScreen : UserControl
    {
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

        ////Variables
        int counter = 0;
        int ronaldAttackCounter = 250;

        int playerSpeed = 5;
        int dodgeCooldown = 0;
        int immunityCooldown = 10;
        int playerProjectileSizeTemp = 0;
        static public int ronaldHealth = 2000;
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
        public static int playerMaxHealth = 6;
        public static int playerHealth = 3;


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
        public static int difficultyMultiplier = 1;

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

        public GameScreen()
        {
            InitializeComponent();
            GameStartUp();
        }

        public void GameStartUp()
        {
            //collecct difficulty information from other screen

            //reset the game elements
            player.X = 700 - 4;
            player.Y = 700 - 4;

            playerProjectiles.Clear();
            playerProjectilesSpeedsX.Clear();
            playerProjectilesSpeedsY.Clear();
            playerProjectilesLifespan.Clear();
            playerProjectileSize.Clear();

            Ronald.X = 700 - 40;
            Ronald.Y = 100 + 40;
            enemyProjectiles.Clear();
            enemyProjectilesSpeedsX.Clear();
            enemyProjectilesSpeedsY.Clear();
            enemyProjectilesWait.Clear();

            counter = 0;
            ronaldAttackCounter = 250;

            playerSpeed = 5;
            dodgeCooldown = 0;
            immunityCooldown = 10;
            playerProjectileSizeTemp = 0;
            ronaldPosition = 0;
            ronaldMovePattern = "stride";
            ronaldMovePatternSwitch = 1;
            clockwise = true;
            previousRonaldPosition = 0;
            attackSetOneSwitch = 0;
            individualAttackSetOne = 0;
            individualAttackSetTwo = 0;
            attackSetTwoSwitch = 0;
            ronaldShouldBeMoving = true;

            if (playerMaxHealth == 6)
            {
                Form1.TopHeartSetting = 1;
                Form1.MiddleHeartSetting = 1;
                Form1.BottomHeartSetting = 1;
            }
            if (playerMaxHealth == 4)
            {
                Form1.TopHeartSetting = 0;
                Form1.MiddleHeartSetting = 1;
                Form1.BottomHeartSetting = 1;
            }
            if (playerMaxHealth == 2)
            {
                Form1.TopHeartSetting = 0;
                Form1.MiddleHeartSetting = 0;
                Form1.BottomHeartSetting = 1;
            }
            Form1.HeartVisuals();
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                //Movement Keys
                case Keys.W:
                    moveUp = true;
                    isMoving = true;
                    break;
                case Keys.S:
                    moveDown = true;
                    isMoving = true;
                    break;
                case Keys.A:
                    moveLeft = true;
                    isMoving = true;
                    break;
                case Keys.D:
                    moveRight = true;
                    isMoving = true;
                    break;
                case Keys.Up:
                    moveUp = true;
                    isMoving = true;
                    break;
                case Keys.Down:
                    moveDown = true;
                    isMoving = true;
                    break;
                case Keys.Left:
                    moveLeft = true;
                    isMoving = true;
                    break;
                case Keys.Right:
                    moveRight = true;
                    isMoving = true;
                    break;

                //Dodge Keys
                case Keys.Enter:
                    dodgeDown = true;
                    break;
                case Keys.Shift:
                    dodgeDown = true;
                    break;

                //Shoot Key
                case Keys.Space:
                    spaceDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //Movement Keys
                case Keys.W:
                    moveUp = false;
                    isMoving = false;
                    break;
                case Keys.S:
                    moveDown = false;
                    isMoving = false;
                    break;
                case Keys.A:
                    moveLeft = false;
                    isMoving = false;
                    break;
                case Keys.D:
                    moveRight = false;
                    isMoving = false;
                    break;
                case Keys.Up:
                    moveUp = false;
                    isMoving = false;
                    break;
                case Keys.Down:
                    moveDown = false;
                    isMoving = false;
                    break;
                case Keys.Left:
                    moveLeft = false;
                    isMoving = false;
                    break;
                case Keys.Right:
                    moveRight = false;
                    isMoving = false;
                    break;

                //Dodge Keys
                case Keys.Enter:
                    dodgeDown = false;
                    break;
                case Keys.Shift:
                    dodgeDown = false;
                    break;

                //Shoot Key
                case Keys.Space:
                    spaceDown = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            ////Cooldowns
            dodgeCooldown -= 1;
            individualAttackSetTwo--;

            if (immunityCooldown != 0)
            {
                immunityCooldown -= 1;
            }
            counter++;
            for (int i = 0; i < playerProjectiles.Count(); i++)
            {
                playerProjectilesLifespan[i] -= 1;

                if (playerProjectilesLifespan[i] < 20)
                {
                    playerProjectileSize[i] -= 1;
                }
            }
            for (int i = 0; i < enemyProjectiles.Count(); i++)
            {
                enemyProjectilesWait[i]--;
            }

            ////Dodge
            if (dodgeDown == true && dodgeCooldown < 1 && isMoving == true && player.Y > 295 + playerSpeed * 10 && player.Y < 900 - player.Width - playerSpeed * 10 && player.X > 425 + playerSpeed * 10 && player.X < this.Width - player.Width - 425 - playerSpeed * 10)
            {
                playerSpeed *= 10;
                dodgeCooldown = 200;
                immunityCooldown += 10;
            }


            ////Move Player
            if (moveUp == true && player.Y > 295)
            {
                player.Y -= playerSpeed;
            }
            if (moveDown == true && player.Y < 900 - player.Width)
            {
                player.Y += playerSpeed;
            }
            if (moveLeft == true && player.X > 425)
            {
                player.X -= playerSpeed;
            }
            if (moveRight == true && player.X < this.Width - player.Width - 425)
            {
                player.X += playerSpeed;
            }
            playerSpeed = 5;


            ////Player Created Projectiles
            //creation
            if (spaceDown == true)
            {
                playerProjectileSizeTemp = randGen.Next(17, 28);

                playerProjectileSize.Add(playerProjectileSizeTemp);
                playerProjectiles.Add(new Rectangle(player.X + player.Width / 2 - playerProjectileSizeTemp / 2, player.Y - playerProjectileSizeTemp, playerProjectileSizeTemp, playerProjectileSizeTemp));
                playerProjectilesSpeedsX.Add(randGen.Next(-1, 2));
                playerProjectilesSpeedsY.Add(randGen.Next(7, 12));
                playerProjectilesLifespan.Add(randGen.Next(20, 80));
            }

            //move projectiles 
            for (int i = 0; i < playerProjectiles.Count(); i++)
            {
                //find new position
                int x = playerProjectiles[i].X + playerProjectilesSpeedsX[i];
                int y = playerProjectiles[i].Y - playerProjectilesSpeedsY[i];

                //replace
                playerProjectiles[i] = new Rectangle(x, y, playerProjectileSize[i], playerProjectileSize[i]);
            }

            //removal
            for (int i = 0; i < playerProjectiles.Count(); i++)
            {
                if (playerProjectiles[i].Y < 0 || playerProjectileSize[i] == 0)
                {
                    playerProjectileSize.RemoveAt(i);
                    playerProjectiles.RemoveAt(i);
                    playerProjectilesSpeedsX.RemoveAt(i);
                    playerProjectilesSpeedsY.RemoveAt(i);
                    playerProjectilesLifespan.RemoveAt(i);
                }
            }


            ////Move Ronald
            if (ronaldShouldBeMoving == true)
            {
                previousRonaldPosition = ronaldPosition;
                //move patterns
                if (ronaldMovePattern == "figure eight")
                {
                    switch (ronaldPosition)
                    {
                        case 0:
                            Ronald = new Rectangle(700 - 40, 100 + 40, 80, 80);
                            break;
                        case 1:
                            Ronald = new Rectangle(700 - 14 - Ronald.Height / 2, 100 - 5 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 2:
                            Ronald = new Rectangle(700 - 29 - Ronald.Height / 2, 100 - 10 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 3:
                            Ronald = new Rectangle(700 - 43 - Ronald.Height / 2, 100 - 20 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 4:
                            Ronald = new Rectangle(700 - 57 - Ronald.Height / 2, 100 - 30 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 5:
                            Ronald = new Rectangle(700 - 71 - Ronald.Height / 2, 100 - 40 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 6:
                            Ronald = new Rectangle(700 - 86 - Ronald.Height / 2, 100 - 50 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 7:
                            Ronald = new Rectangle(700 - 100 - Ronald.Height / 2, 100 - 55 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 8:
                            Ronald = new Rectangle(700 - 115 - Ronald.Height / 2, 100 - 60 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 9:
                            Ronald = new Rectangle(700 - 130 - Ronald.Height / 2, 100 - 55 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 10:
                            Ronald = new Rectangle(700 - 144 - Ronald.Height / 2, 100 - 50 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 11:
                            Ronald = new Rectangle(700 - 159 - Ronald.Height / 2, 100 - 40 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 12:
                            Ronald = new Rectangle(700 - 173 - Ronald.Height / 2, 100 - 30 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 13:
                            Ronald = new Rectangle(700 - 187 - Ronald.Height / 2, 100 - 20 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 14:
                            Ronald = new Rectangle(700 - 201 - Ronald.Height / 2, 100 - 10 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 15:
                            Ronald = new Rectangle(700 - 211 - Ronald.Height / 2, 100 - 5 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 16:
                            Ronald = new Rectangle(700 - 230 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;

                        case 17:
                            Ronald = new Rectangle(700 - 211 - Ronald.Height / 2, 100 + 5 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 18:
                            Ronald = new Rectangle(700 - 201 - Ronald.Height / 2, 100 + 10 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 19:
                            Ronald = new Rectangle(700 - 187 - Ronald.Height / 2, 100 + 20 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 20:
                            Ronald = new Rectangle(700 - 173 - Ronald.Height / 2, 100 + 30 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 21:
                            Ronald = new Rectangle(700 - 159 - Ronald.Height / 2, 100 + 40 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 22:
                            Ronald = new Rectangle(700 - 144 - Ronald.Height / 2, 100 + 50 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 23:
                            Ronald = new Rectangle(700 - 130 - Ronald.Height / 2, 100 + 55 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 24:
                            Ronald = new Rectangle(700 - 115 - Ronald.Height / 2, 100 + 60 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 25:
                            Ronald = new Rectangle(700 - 100 - Ronald.Height / 2, 100 + 55 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 26:
                            Ronald = new Rectangle(700 - 86 - Ronald.Height / 2, 100 + 50 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 27:
                            Ronald = new Rectangle(700 - 71 - Ronald.Height / 2, 100 + 40 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 28:
                            Ronald = new Rectangle(700 - 57 - Ronald.Height / 2, 100 + 30 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 29:
                            Ronald = new Rectangle(700 - 43 - Ronald.Height / 2, 100 + 20 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 30:
                            Ronald = new Rectangle(700 - 29 - Ronald.Height / 2, 100 + 10 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 31:
                            Ronald = new Rectangle(700 - 14 - Ronald.Height / 2, 100 + 5 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 32: //same as zero
                            Ronald = new Rectangle(700 - 40, 100 + 40, 80, 80);
                            break;

                        case 33:
                            Ronald = new Rectangle(700 + 14 - Ronald.Height / 2, 100 - 5 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 34:
                            Ronald = new Rectangle(700 + 29 - Ronald.Height / 2, 100 - 10 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 35:
                            Ronald = new Rectangle(700 + 43 - Ronald.Height / 2, 100 - 20 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 36:
                            Ronald = new Rectangle(700 + 57 - Ronald.Height / 2, 100 - 30 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 37:
                            Ronald = new Rectangle(700 + 71 - Ronald.Height / 2, 100 - 40 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 38:
                            Ronald = new Rectangle(700 + 86 - Ronald.Height / 2, 100 - 50 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 39:
                            Ronald = new Rectangle(700 + 100 - Ronald.Height / 2, 100 - 55 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 40:
                            Ronald = new Rectangle(700 + 115 - Ronald.Height / 2, 100 - 60 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 41:
                            Ronald = new Rectangle(700 + 130 - Ronald.Height / 2, 100 - 55 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 42:
                            Ronald = new Rectangle(700 + 144 - Ronald.Height / 2, 100 - 50 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 43:
                            Ronald = new Rectangle(700 + 159 - Ronald.Height / 2, 100 - 40 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 44:
                            Ronald = new Rectangle(700 + 173 - Ronald.Height / 2, 100 - 30 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 45:
                            Ronald = new Rectangle(700 + 187 - Ronald.Height / 2, 100 - 20 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 46:
                            Ronald = new Rectangle(700 + 201 - Ronald.Height / 2, 100 - 10 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 47:
                            Ronald = new Rectangle(700 + 211 - Ronald.Height / 2, 100 - 5 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 48:
                            Ronald = new Rectangle(700 + 230 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;

                        case 49:
                            Ronald = new Rectangle(700 + 211 - Ronald.Height / 2, 100 + 5 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 50:
                            Ronald = new Rectangle(700 + 201 - Ronald.Height / 2, 100 + 10 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 51:
                            Ronald = new Rectangle(700 + 187 - Ronald.Height / 2, 100 + 20 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 52:
                            Ronald = new Rectangle(700 + 173 - Ronald.Height / 2, 100 + 30 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 53:
                            Ronald = new Rectangle(700 + 159 - Ronald.Height / 2, 100 + 40 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 54:
                            Ronald = new Rectangle(700 + 144 - Ronald.Height / 2, 100 + 50 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 55:
                            Ronald = new Rectangle(700 + 130 - Ronald.Height / 2, 100 + 55 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 56:
                            Ronald = new Rectangle(700 + 115 - Ronald.Height / 2, 100 + 60 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 57:
                            Ronald = new Rectangle(700 + 100 - Ronald.Height / 2, 100 + 55 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 58:
                            Ronald = new Rectangle(700 + 86 - Ronald.Height / 2, 100 + 50 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 59:
                            Ronald = new Rectangle(700 + 71 - Ronald.Height / 2, 100 + 40 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 60:
                            Ronald = new Rectangle(700 + 57 - Ronald.Height / 2, 100 + 30 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 61:
                            Ronald = new Rectangle(700 + 43 - Ronald.Height / 2, 100 + 20 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 62:
                            Ronald = new Rectangle(700 + 29 - Ronald.Height / 2, 100 + 10 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 63:
                            Ronald = new Rectangle(700 + 14 - Ronald.Height / 2, 100 + 5 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                            //case 64: //same as zero
                            //    Ronald = new Rectangle(700 - 40, 100 + 40, 80, 80);
                            //    break;
                    }
                }
                if (ronaldMovePattern == "stride")
                {
                    switch (ronaldPosition)
                    {
                        case 0:
                            Ronald = new Rectangle(700 - 40, 100 + 40, 80, 80);
                            break;
                        case 1:
                            Ronald = new Rectangle(700 - 14 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 2:
                            Ronald = new Rectangle(700 - 29 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 3:
                            Ronald = new Rectangle(700 - 43 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 4:
                            Ronald = new Rectangle(700 - 57 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 5:
                            Ronald = new Rectangle(700 - 71 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 6:
                            Ronald = new Rectangle(700 - 86 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 7:
                            Ronald = new Rectangle(700 - 100 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 8:
                            Ronald = new Rectangle(700 - 115 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 9:
                            Ronald = new Rectangle(700 - 130 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 10:
                            Ronald = new Rectangle(700 - 144 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 11:
                            Ronald = new Rectangle(700 - 159 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 12:
                            Ronald = new Rectangle(700 - 173 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 13:
                            Ronald = new Rectangle(700 - 187 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 14:
                            Ronald = new Rectangle(700 - 201 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 15:
                            Ronald = new Rectangle(700 - 211 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 16:
                            Ronald = new Rectangle(700 - 230 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;

                        case 17:
                            Ronald = new Rectangle(700 - 211 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 18:
                            Ronald = new Rectangle(700 - 201 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 19:
                            Ronald = new Rectangle(700 - 187 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 20:
                            Ronald = new Rectangle(700 - 173 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 21:
                            Ronald = new Rectangle(700 - 159 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 22:
                            Ronald = new Rectangle(700 - 144 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 23:
                            Ronald = new Rectangle(700 - 130 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 24:
                            Ronald = new Rectangle(700 - 115 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 25:
                            Ronald = new Rectangle(700 - 100 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 26:
                            Ronald = new Rectangle(700 - 86 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 27:
                            Ronald = new Rectangle(700 - 71 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 28:
                            Ronald = new Rectangle(700 - 57 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 29:
                            Ronald = new Rectangle(700 - 43 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 30:
                            Ronald = new Rectangle(700 - 29 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 31:
                            Ronald = new Rectangle(700 - 14 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 32: //same as zero
                            Ronald = new Rectangle(700 - 40, 100 + 40, 80, 80);
                            break;

                        case 33:
                            Ronald = new Rectangle(700 + 14 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 34:
                            Ronald = new Rectangle(700 + 29 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 35:
                            Ronald = new Rectangle(700 + 43 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 36:
                            Ronald = new Rectangle(700 + 57 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 37:
                            Ronald = new Rectangle(700 + 71 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 38:
                            Ronald = new Rectangle(700 + 86 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 39:
                            Ronald = new Rectangle(700 + 100 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 40:
                            Ronald = new Rectangle(700 + 115 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 41:
                            Ronald = new Rectangle(700 + 130 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 42:
                            Ronald = new Rectangle(700 + 144 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 43:
                            Ronald = new Rectangle(700 + 159 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 44:
                            Ronald = new Rectangle(700 + 173 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 45:
                            Ronald = new Rectangle(700 + 187 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 46:
                            Ronald = new Rectangle(700 + 201 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 47:
                            Ronald = new Rectangle(700 + 211 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 48:
                            Ronald = new Rectangle(700 + 230 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;

                        case 49:
                            Ronald = new Rectangle(700 + 211 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 50:
                            Ronald = new Rectangle(700 + 201 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 51:
                            Ronald = new Rectangle(700 + 187 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 52:
                            Ronald = new Rectangle(700 + 173 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 53:
                            Ronald = new Rectangle(700 + 159 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 54:
                            Ronald = new Rectangle(700 + 144 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 55:
                            Ronald = new Rectangle(700 + 130 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 56:
                            Ronald = new Rectangle(700 + 115 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 57:
                            Ronald = new Rectangle(700 + 100 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 58:
                            Ronald = new Rectangle(700 + 86 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 59:
                            Ronald = new Rectangle(700 + 71 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 60:
                            Ronald = new Rectangle(700 + 57 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 61:
                            Ronald = new Rectangle(700 + 43 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 62:
                            Ronald = new Rectangle(700 + 29 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                        case 63:
                            Ronald = new Rectangle(700 + 14 - Ronald.Height / 2, 100 + Ronald.Height / 2, Ronald.Height, Ronald.Height);
                            break;
                            //case 64: //same as zero
                            //    Ronald = new Rectangle(700 - 40, 100 + 40, 80, 80);
                            //    break;
                    }

                }
                if (ronaldMovePattern == "slam")
                {
                    switch (ronaldPosition)
                    {
                        case 0:
                            Ronald = new Rectangle(700 - 40, 100 + 40, 80, 80);
                            break;
                        case 1:
                            Ronald = new Rectangle(700 - 40, 100 + 45 + 40, 80, 90);
                            break;
                        case 2:
                            Ronald = new Rectangle(700 - 40, 100 + 55 + 40, 80, 92);
                            break;
                        case 3:
                            Ronald = new Rectangle(700 - 40, 100 + 75 + 40, 80, 92);
                            break;
                        case 4:
                            Ronald = new Rectangle(700 - 40, 100 + 95 + 40, 80, 95);
                            break;
                        case 5:
                            Ronald = new Rectangle(700 - 40, 100 + 120 + 40, 80, 95);
                            break;
                        case 6:
                            Ronald = new Rectangle(700 - 40, 100 + 142 + 40, 80, 95);
                            break;
                        case 7:
                            Ronald = new Rectangle(700 - 40, 100 + 166 + 40, 80, 95);
                            break;
                        case 8:
                            Ronald = new Rectangle(700 - 40 + 2, 100 + 196 + 40, 76, 95);
                            break;
                        case 9:
                            Ronald = new Rectangle(700 - 40 + 2, 100 + 230 + 40, 76, 95);
                            break;
                        case 10:
                            Ronald = new Rectangle(700 - 40 + 2, 100 + 260 + 40, 76, 95);
                            break;
                        case 11:
                            Ronald = new Rectangle(700 - 40 + 2, 100 + 290 + 40, 76, 95);
                            break;
                        case 12:
                            Ronald = new Rectangle(700 - 40 + 2, 100 + 320 + 40, 76, 95);
                            break;
                        case 13:
                            Ronald = new Rectangle(700 - 40 + 2, 100 + 350 + 40, 76, 95);
                            break;
                        case 14:
                            Ronald = new Rectangle(700 - 40 + 2, 100 + 380 + 40, 76, 95);
                            break;
                        case 15:
                            Ronald = new Rectangle(700 - 40 + 2, 100 + 410 + 40, 76, 95);
                            break;
                        case 16:
                            Ronald = new Rectangle(700 - 40 + 2, 100 + 440 + 40, 76, 95);
                            break;
                        case 17:
                            Ronald = new Rectangle(700 - 40 + 2, 100 + 470 + 40, 76, 95);
                            break;
                        case 18:
                            Ronald = new Rectangle(700 - 40 + 2, 100 + 510 + 40, 76, 95);
                            break;
                        case 19:
                            Ronald = new Rectangle(700 - 40 + 2, 100 + 550 + 40, 76, 95);
                            break;
                        case 20:
                            Ronald = new Rectangle(700 - 40 + 2, 100 + 600 + 40, 76, 95);
                            break;
                        case 21:
                            Ronald = new Rectangle(700 - 40 + 2, 100 + 650 + 40, 76, 95);
                            break;
                        case 22:
                            Ronald = new Rectangle(700 - 40 + 2, 100 + 700 + 40, 76, 95);
                            break;
                        case 23:
                            Ronald = new Rectangle(700 - 40 + 2, 100 + 750 + 40, 76, 95);
                            break;
                        case 24:
                            Ronald = new Rectangle(700 - 40 + 2, 100 + 800 + 40, 76, 95);
                            break;
                        case 25:
                            Ronald = new Rectangle(700 - 40 + 2, 100 + 850 + 40, 76, 95);
                            break;
                        case 26:
                            Ronald = new Rectangle(700 - 40 + 1, 100 - 150 + 40, 78, 90);
                            break;
                        case 27:
                            Ronald = new Rectangle(700 - 40 + 1, 100 - 100 + 40, 78, 90);
                            break;
                        case 28:
                            Ronald = new Rectangle(700 - 40 + 1, 100 - 60 + 40, 78, 90);
                            break;
                        case 29:
                            Ronald = new Rectangle(700 - 40, 100 - 40 + 40, 80, 85);
                            break;
                        case 30:
                            Ronald = new Rectangle(700 - 40, 100 - 30 + 40, 80, 80);
                            break;
                        case 31:
                            Ronald = new Rectangle(700 - 40, 100 - 20 + 40, 80, 80);
                            break;
                        case 32:
                            Ronald = new Rectangle(700 - 40, 100 - 10 + 40, 80, 80);
                            break;
                        case 33:
                            Ronald = new Rectangle(700 - 40, 100 - 5 + 40, 80, 80);
                            break;
                        case 34:
                            Ronald = new Rectangle(700 - 40, 100 + 40, 80, 80);
                            break;
                    }

                }

                //pick direction
                if (counter % 50 == 0)
                {
                    if (randGen.Next(1, 3) == 1)
                    {
                        clockwise = true;
                    }
                    else
                    {
                        clockwise = false;
                    }
                }

                //move position -- figure eight and stide, slam
                if (counter % 2 == 0 && clockwise == true && ronaldMovePattern != "slam")
                {
                    ronaldPosition += 1;
                    if (ronaldPosition > 63)
                    {
                        ronaldPosition = 0;
                    }
                }
                else if (counter % 2 == 0 && clockwise == false && ronaldMovePattern != "slam")
                {
                    ronaldPosition -= 1;
                    if (ronaldPosition < 1)
                    {
                        ronaldPosition = 64;
                    }
                }
                else if (counter % 2 == 0 && ronaldMovePattern == "slam")
                {
                    ronaldPosition += 1;
                    if (ronaldPosition > 34)
                    {
                        ronaldPosition = 0;
                    }
                }

                //switch to another pattern
                if (ronaldPosition == 0 || ronaldPosition == 32 && ronaldMovePattern != "slam")
                {
                    ronaldMovePatternSwitch = randGen.Next(1, 101);
                }

                if (ronaldMovePatternSwitch < 38 || Ronald.X == previousRonaldPosition)
                {
                    ronaldMovePattern = "figure eight";
                }
                else if (ronaldMovePatternSwitch < 76)
                {
                    ronaldMovePattern = "stride";
                }
                else if (ronaldMovePatternSwitch < 101)
                {
                    ronaldMovePattern = "slam";
                }
            }

            ////Ronald Projectiles
            //is it time to attack?
            if (ronaldMovePattern != "slam")
            {
                ronaldAttackCounter++;
            }

            //set 1
            if ((ronaldAttackCounter * difficultyMultiplier) % 300 <= 0) //attacks from set 1 - world orientated attacks
            {
                //systematically pick from a list of avalable attacks
                attackSetOneSwitch++;

                //make sure that attack is within the list - if the number is greater than the amount of attacks, reset to one  !!!ADD EXTRA ATTACKS IN PHASE 2!!!
                if (attackSetOneSwitch > 4)
                {
                    attackSetOneSwitch = 1;
                }

                //set timer
                individualAttackSetOne = 300;
            }

            //attack one list
            switch (attackSetOneSwitch)
            {
                case 1:
                    SetOneCaseOne();
                    break;
                case 2:
                    SetOneCaseTwo();
                    break;
                case 3:
                    SetOneCaseThree();
                    break;
                case 4:
                    SetOneCaseFour();
                    break;
            }

            //set 2
            //stop back to back attacks
            if (individualAttackSetTwo <= 0 && individualAttackSetTwo >= -49)
            {
                attackSetTwoSwitch = 0;
            }

            if (individualAttackSetTwo <= -50 && ronaldMovePattern != "slam") //attacks from set 2 - boss orientated attacks
            {
                //randomly pick from a list of avalable attacks    !!!ADD A VARIABLE IN THE RANDGEN THAT CHANGES TO CONTROL PHASE 2!!!
                attackSetTwoSwitch = randGen.Next(1, 3);

                //set timer
                individualAttackSetTwo = 450;
            }

            //attack two list
            switch (attackSetTwoSwitch)
            {
                case 1:
                    SetTwoCaseOne();
                    break;
                case 2:
                    SetTwoCaseTwo();
                    break;
            }

            //move Ronald projectiles
            for (int i = 0; i < enemyProjectiles.Count(); i++)
            {
                if (enemyProjectilesWait[i] <= 0)
                {
                    //find new position
                    int x = enemyProjectiles[i].X + enemyProjectilesSpeedsX[i];
                    int y = enemyProjectiles[i].Y + enemyProjectilesSpeedsY[i];

                    //replace
                    enemyProjectiles[i] = new Rectangle(x, y, enemyProjectiles[i].Width, enemyProjectiles[i].Height);
                }
            }

            //removal
            for (int i = 0; i < enemyProjectiles.Count(); i++)
            {
                if (enemyProjectiles[i].X < -10 || enemyProjectiles[i].X > 1300 || enemyProjectiles[i].Y < -300 || enemyProjectiles[i].Y > 1000) //CAN BE OPTIMIZED
                {
                    enemyProjectiles.RemoveAt(i);
                    enemyProjectilesSpeedsX.RemoveAt(i);
                    enemyProjectilesSpeedsY.RemoveAt(i);
                    enemyProjectilesWait.RemoveAt(i);
                }
            }

            ////Scoring, Checking Win Conditions, Other Miscellaneous Tasks
            //damage Ronald
            for (int i = 0; i < playerProjectiles.Count(); i++)
            {
                if (playerProjectiles[i].IntersectsWith(Ronald))
                {
                    playerProjectileSize.RemoveAt(i);
                    playerProjectiles.RemoveAt(i);
                    playerProjectilesSpeedsX.RemoveAt(i);
                    playerProjectilesSpeedsY.RemoveAt(i);
                    playerProjectilesLifespan.RemoveAt(i);
                    ronaldHealth -= 1;
                }
            }
            if (ronaldHealth <= 0)
            {
                Form1.gameState = "win";
                gameTimer.Enabled = false;
            }

            //damage player
            for (int i = 0; i < enemyProjectiles.Count(); i++)
            {
                if (enemyProjectiles[i].IntersectsWith(player) && immunityCooldown <= 0)
                {
                    enemyProjectiles.RemoveAt(i);
                    enemyProjectilesSpeedsX.RemoveAt(i);
                    enemyProjectilesSpeedsY.RemoveAt(i);
                    enemyProjectilesWait.RemoveAt(i);
                    playerHealth -= 1;
                    immunityCooldown += 100;
                }
            }
            if (Ronald.IntersectsWith(player) && immunityCooldown <= 0)
            {
                playerHealth -= 1;
                immunityCooldown += 100;
            }
            
            if (playerHealth == 0)
            {
                Form1.gameState = "lose";
                //GameScreen.Close();
                gameTimer.Enabled = false;
            }

            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //background 
            e.Graphics.DrawImage(backgroundImage, 0, 0, 1400, 900);

            //enemy projectiles
            for (int i = 0; i < enemyProjectiles.Count(); i++)
            {
                if (enemyProjectilesWait[i] <= 0)
                {
                    e.Graphics.FillEllipse(darkredBrush, enemyProjectiles[i]);
                }
                else
                {
                    e.Graphics.FillEllipse(inactiveBrush, enemyProjectiles[i]);
                }
            }

            //player projectiles -- flamethrower: burn extra calories!
            for (int i = 0; i < playerProjectiles.Count(); i++)
            {
                if (playerProjectilesLifespan[i] < 20)
                {
                    e.Graphics.FillRectangle(darkredBrush, playerProjectiles[i]);
                    //e.Graphics.DrawImage(redAshFireImage, playerProjectiles[i].X, playerProjectiles[i].Y, playerProjectileSize[i] + 20, playerProjectileSize[i] + 20);
                }
                else if (playerProjectilesLifespan[i] < 30)
                {
                    e.Graphics.FillRectangle(redBrush, playerProjectiles[i]);
                    //e.Graphics.DrawImage(redFireImage, playerProjectiles[i].X, playerProjectiles[i].Y, playerProjectileSize[i] + 20, playerProjectileSize[i] + 20);
                }
                else if (playerProjectilesLifespan[i] < 40)
                {
                    e.Graphics.FillRectangle(orangeredBrush, playerProjectiles[i]);
                    //e.Graphics.DrawImage(orangeRedFireImage, playerProjectiles[i].X, playerProjectiles[i].Y, playerProjectileSize[i] + 20, playerProjectileSize[i] + 20);
                }
                else if (playerProjectilesLifespan[i] < 45)
                {
                    e.Graphics.FillRectangle(orangeBrush, playerProjectiles[i]);
                    //e.Graphics.DrawImage(orangeFireImage, playerProjectiles[i].X, playerProjectiles[i].Y, playerProjectileSize[i] + 20, playerProjectileSize[i] + 20);
                }
                else if (playerProjectilesLifespan[i] < 62)
                {
                    e.Graphics.FillRectangle(goldBrush, playerProjectiles[i]);
                    //e.Graphics.DrawImage(yellowOrangeFireImage, playerProjectiles[i].X, playerProjectiles[i].Y, playerProjectileSize[i] + 20, playerProjectileSize[i] + 20);
                }
                else if (playerProjectilesLifespan[i] < 81)
                {
                    e.Graphics.FillRectangle(goldBrush, playerProjectiles[i]);
                    //e.Graphics.DrawImage(yellowFireImage, playerProjectiles[i].X, playerProjectiles[i].Y, playerProjectileSize[i] + 20, playerProjectileSize[i] + 20);
                }
            }

            //player
            e.Graphics.FillEllipse(blueBrush, player);

            //Uncle Ron
            e.Graphics.FillRectangle(blueBrush, Ronald);

            cooldownTimerLabel.Text = $"{ronaldHealth}";
        }

        public void SetOneCaseOne()
        {
            //run attack
            individualAttackSetOne--;

            if (individualAttackSetOne % (120 / difficultyMultiplier) == 0)
            {
                enemyProjectiles.Add(new Rectangle(465 - 10, -5, 20, 20));
                enemyProjectilesSpeedsX.Add(0);
                enemyProjectilesSpeedsY.Add(3);
                enemyProjectilesWait.Add(0);

                enemyProjectiles.Add(new Rectangle(583 - 10, (-165 / difficultyMultiplier) - 10, 20, 20));
                enemyProjectilesSpeedsX.Add(0);
                enemyProjectilesSpeedsY.Add(3);
                enemyProjectilesWait.Add(0);

                enemyProjectiles.Add(new Rectangle(700 - 10, -5, 20, 20));
                enemyProjectilesSpeedsX.Add(0);
                enemyProjectilesSpeedsY.Add(3);
                enemyProjectilesWait.Add(0);

                enemyProjectiles.Add(new Rectangle(818 - 10, (-165 / difficultyMultiplier) - 10, 20, 20));
                enemyProjectilesSpeedsX.Add(0);
                enemyProjectilesSpeedsY.Add(3);
                enemyProjectilesWait.Add(0);

                enemyProjectiles.Add(new Rectangle(935 - 10, -5, 20, 20));
                enemyProjectilesSpeedsX.Add(0);
                enemyProjectilesSpeedsY.Add(3);
                enemyProjectilesWait.Add(0);

                //difficulty settings
                if (difficultyMultiplier >= 2)
                {
                    enemyProjectiles.Add(new Rectangle(524 - 7, -5, 14, 14));
                    enemyProjectilesSpeedsX.Add(0);
                    enemyProjectilesSpeedsY.Add(4);
                    enemyProjectilesWait.Add(0);

                    enemyProjectiles.Add(new Rectangle(641 - 7, -5, 14, 14));
                    enemyProjectilesSpeedsX.Add(0);
                    enemyProjectilesSpeedsY.Add(4);
                    enemyProjectilesWait.Add(0);

                    enemyProjectiles.Add(new Rectangle(759 - 7, -5, 14, 14));
                    enemyProjectilesSpeedsX.Add(0);
                    enemyProjectilesSpeedsY.Add(4);
                    enemyProjectilesWait.Add(0);

                    enemyProjectiles.Add(new Rectangle(877 - 7, -5, 14, 14));
                    enemyProjectilesSpeedsX.Add(0);
                    enemyProjectilesSpeedsY.Add(4);
                    enemyProjectilesWait.Add(0);
                }
            }
        }

        public void SetOneCaseTwo()
        {
            //ronaldShouldBeMoving = false;

            //run attack
            individualAttackSetOne--;

            if (individualAttackSetOne % (42 / difficultyMultiplier) == 0)
            {
                enemyProjectiles.Add(new Rectangle((Ronald.X - (10 - Ronald.Width / 2)), Ronald.Y - ((10 - Ronald.Height / 2)), 20, 20));
                enemyProjectilesSpeedsX.Add(-6);
                enemyProjectilesSpeedsY.Add(2);
                enemyProjectilesWait.Add(0);

                enemyProjectiles.Add(new Rectangle((Ronald.X - (10 - Ronald.Width / 2)), Ronald.Y - ((10 - Ronald.Height / 2)), 20, 20));
                enemyProjectilesSpeedsX.Add(-2);
                enemyProjectilesSpeedsY.Add(6);
                enemyProjectilesWait.Add(0);

                enemyProjectiles.Add(new Rectangle((Ronald.X - (10 - Ronald.Width / 2)), Ronald.Y - ((10 - Ronald.Height / 2)), 20, 20));
                enemyProjectilesSpeedsX.Add(2);
                enemyProjectilesSpeedsY.Add(6);
                enemyProjectilesWait.Add(0);

                enemyProjectiles.Add(new Rectangle((Ronald.X - (10 - Ronald.Width / 2)), Ronald.Y - ((10 - Ronald.Height / 2)), 20, 20));
                enemyProjectilesSpeedsX.Add(6);
                enemyProjectilesSpeedsY.Add(2);
                enemyProjectilesWait.Add(0);

                enemyProjectiles.Add(new Rectangle((Ronald.X - (10 - Ronald.Width / 2)), Ronald.Y - ((10 - Ronald.Height / 2)), 20, 20));
                enemyProjectilesSpeedsX.Add(3);
                enemyProjectilesSpeedsY.Add(-1);
                enemyProjectilesWait.Add(0);

                enemyProjectiles.Add(new Rectangle((Ronald.X - (10 - Ronald.Width / 2)), Ronald.Y - ((10 - Ronald.Height / 2)), 20, 20));
                enemyProjectilesSpeedsX.Add(2);
                enemyProjectilesSpeedsY.Add(-6);
                enemyProjectilesWait.Add(0);

                enemyProjectiles.Add(new Rectangle((Ronald.X - (10 - Ronald.Width / 2)), Ronald.Y - ((10 - Ronald.Height / 2)), 20, 20));
                enemyProjectilesSpeedsX.Add(-2);
                enemyProjectilesSpeedsY.Add(-6);
                enemyProjectilesWait.Add(0);

                enemyProjectiles.Add(new Rectangle((Ronald.X - (10 - Ronald.Width / 2)), Ronald.Y - ((10 - Ronald.Height / 2)), 20, 20));
                enemyProjectilesSpeedsX.Add(-6);
                enemyProjectilesSpeedsY.Add(-2);
                enemyProjectilesWait.Add(0);
            }
            //if (individualAttackSetOne <= 20)
            //{
            //    ronaldShouldBeMoving = true;
            //}
        }

        public void SetOneCaseThree()
        {
            //run attack
            individualAttackSetOne -= 4;

            enemyProjectiles.Add(new Rectangle(500 - 10, -5, 20, 20));
            enemyProjectilesSpeedsX.Add(0);
            enemyProjectilesSpeedsY.Add(8);
            enemyProjectilesWait.Add(0);
            enemyProjectiles.Add(new Rectangle(900 - 10, 905, 20, 20));
            enemyProjectilesSpeedsX.Add(0);
            enemyProjectilesSpeedsY.Add(-8);
            enemyProjectilesWait.Add(38);

            enemyProjectiles.Add(new Rectangle(300 - 10, 490 - 10, 20, 20));
            enemyProjectilesSpeedsX.Add(8);
            enemyProjectilesSpeedsY.Add(0);
            enemyProjectilesWait.Add(0);
            enemyProjectiles.Add(new Rectangle(1100 - 10, 710 - 10, 20, 20));
            enemyProjectilesSpeedsX.Add(-8);
            enemyProjectilesSpeedsY.Add(0);
            enemyProjectilesWait.Add(0);

            if (difficultyMultiplier >= 2)
            {
                enemyProjectiles.Add(new Rectangle(680 - 7, 905, 14, 14));
                enemyProjectilesSpeedsX.Add(0);
                enemyProjectilesSpeedsY.Add(-8);
                enemyProjectilesWait.Add(38);
                enemyProjectiles.Add(new Rectangle(720 - 7, -5, 14, 14));
                enemyProjectilesSpeedsX.Add(0);
                enemyProjectilesSpeedsY.Add(8);
                enemyProjectilesWait.Add(0);
            }
            if (difficultyMultiplier == 3)
            {
                if (individualAttackSetOne <= 100 && individualAttackSetOne >= 0)
                {
                    enemyProjectiles.Add(new Rectangle(300 - 7, 784 - 7, 14, 14));
                    enemyProjectilesSpeedsX.Add(8);
                    enemyProjectilesSpeedsY.Add(0);
                    enemyProjectilesWait.Add(0);
                    enemyProjectiles.Add(new Rectangle(1100 - 7, 858 - 7, 14, 14));
                    enemyProjectilesSpeedsX.Add(-8);
                    enemyProjectilesSpeedsY.Add(0);
                    enemyProjectilesWait.Add(0);
                }
                else if (individualAttackSetOne <= 200)
                {
                    enemyProjectiles.Add(new Rectangle(1100 - 7, 564 - 7, 14, 14));
                    enemyProjectilesSpeedsX.Add(-8);
                    enemyProjectilesSpeedsY.Add(0);
                    enemyProjectilesWait.Add(0);
                    enemyProjectiles.Add(new Rectangle(300 - 7, 637 - 7, 14, 14));
                    enemyProjectilesSpeedsX.Add(8);
                    enemyProjectilesSpeedsY.Add(0);
                    enemyProjectilesWait.Add(0);
                }
                else if (individualAttackSetOne <= 300)
                {
                    enemyProjectiles.Add(new Rectangle(300 - 7, 416 - 7, 14, 14));
                    enemyProjectilesSpeedsX.Add(8);
                    enemyProjectilesSpeedsY.Add(0);
                    enemyProjectilesWait.Add(0);
                    enemyProjectiles.Add(new Rectangle(1100 - 7, 342 - 7, 14, 14));
                    enemyProjectilesSpeedsX.Add(-8);
                    enemyProjectilesSpeedsY.Add(0);
                    enemyProjectilesWait.Add(0);
                }
            }
        }

        public void SetOneCaseFour()
        {
            //run attack
            individualAttackSetOne--;

            if (individualAttackSetOne % (120 / difficultyMultiplier) == 0)
            {
                enemyProjectiles.Add(new Rectangle(465 - 10, -5 + 1000, 20, 20));
                enemyProjectilesSpeedsX.Add(0);
                enemyProjectilesSpeedsY.Add(-3);
                enemyProjectilesWait.Add(0);

                enemyProjectiles.Add(new Rectangle(583 - 10, ((-165 + 1000) / difficultyMultiplier) - 10, 20, 20));
                enemyProjectilesSpeedsX.Add(0);
                enemyProjectilesSpeedsY.Add(-3);
                enemyProjectilesWait.Add(0);

                enemyProjectiles.Add(new Rectangle(700 - 10, -5 + 1000, 20, 20));
                enemyProjectilesSpeedsX.Add(0);
                enemyProjectilesSpeedsY.Add(-3);
                enemyProjectilesWait.Add(0);

                enemyProjectiles.Add(new Rectangle(818 - 10, ((-165 + 1000) / difficultyMultiplier) - 10, 20, 20));
                enemyProjectilesSpeedsX.Add(0);
                enemyProjectilesSpeedsY.Add(-3);
                enemyProjectilesWait.Add(0);

                enemyProjectiles.Add(new Rectangle(935 - 10, -5 + 1000, 20, 20));
                enemyProjectilesSpeedsX.Add(0);
                enemyProjectilesSpeedsY.Add(-3);
                enemyProjectilesWait.Add(0);

                //difficulty settings
                if (difficultyMultiplier >= 2)
                {
                    enemyProjectiles.Add(new Rectangle(524 - 7, -5 + 1000, 14, 14));
                    enemyProjectilesSpeedsX.Add(0);
                    enemyProjectilesSpeedsY.Add(-4);
                    enemyProjectilesWait.Add(0);

                    enemyProjectiles.Add(new Rectangle(641 - 7, -5 + 1000, 14, 14));
                    enemyProjectilesSpeedsX.Add(0);
                    enemyProjectilesSpeedsY.Add(-4);
                    enemyProjectilesWait.Add(0);

                    enemyProjectiles.Add(new Rectangle(759 - 7, -5 + 1000, 14, 14));
                    enemyProjectilesSpeedsX.Add(0);
                    enemyProjectilesSpeedsY.Add(-4);
                    enemyProjectilesWait.Add(0);

                    enemyProjectiles.Add(new Rectangle(877 - 7, -5 + 1000, 14, 14));
                    enemyProjectilesSpeedsX.Add(0);
                    enemyProjectilesSpeedsY.Add(-4);
                    enemyProjectilesWait.Add(0);
                }
            }
        }



        public void SetTwoCaseOne()
        {
            //run attack

            if (individualAttackSetTwo % (438 / difficultyMultiplier) == 0)
            {
                ////code explained:
                // (player.X - (10 - player.Width / 2)) +/- #, ... <--- always starts the block in the center of the player, moved from here

                //enemyProjectiles.Add(new Rectangle((player.X - (10 - player.Width / 2)), (player.Y - (10 - player.Height / 2)), 20, 20));
                //enemyProjectilesSpeedsX.Add(0);
                //enemyProjectilesSpeedsY.Add(3);
                //enemyProjectilesWait.Add(randGen.Next(30, 100));

                enemyProjectiles.Add(new Rectangle((player.X - (10 - player.Width / 2)) - 200, player.Y - ((10 - player.Height / 2)), 20, 20));
                enemyProjectilesSpeedsX.Add(4);
                enemyProjectilesSpeedsY.Add(0);
                enemyProjectilesWait.Add(randGen.Next(30, 100));

                enemyProjectiles.Add(new Rectangle((player.X - (10 - player.Width / 2)) - 140, player.Y - ((10 - player.Height / 2)) + 140, 20, 20));
                enemyProjectilesSpeedsX.Add(2);
                enemyProjectilesSpeedsY.Add(-2);
                enemyProjectilesWait.Add(randGen.Next(30, 100));

                enemyProjectiles.Add(new Rectangle((player.X - (10 - player.Width / 2)), player.Y - ((10 - player.Height / 2)) + 200, 20, 20));
                enemyProjectilesSpeedsX.Add(0);
                enemyProjectilesSpeedsY.Add(-4);
                enemyProjectilesWait.Add(randGen.Next(30, 100));

                enemyProjectiles.Add(new Rectangle((player.X - (10 - player.Width / 2)) + 140, player.Y - ((10 - player.Height / 2)) + 140, 20, 20));
                enemyProjectilesSpeedsX.Add(-2);
                enemyProjectilesSpeedsY.Add(-2);
                enemyProjectilesWait.Add(randGen.Next(30, 100));

                enemyProjectiles.Add(new Rectangle((player.X - (10 - player.Width / 2)) + 200, player.Y - ((10 - player.Height / 2)), 20, 20));
                enemyProjectilesSpeedsX.Add(-4);
                enemyProjectilesSpeedsY.Add(0);
                enemyProjectilesWait.Add(randGen.Next(30, 100));

                enemyProjectiles.Add(new Rectangle((player.X - (10 - player.Width / 2)) + 140, player.Y - ((10 - player.Height / 2)) - 140, 20, 20));
                enemyProjectilesSpeedsX.Add(-2);
                enemyProjectilesSpeedsY.Add(2);
                enemyProjectilesWait.Add(randGen.Next(30, 100));

                enemyProjectiles.Add(new Rectangle((player.X - (10 - player.Width / 2)), player.Y - ((10 - player.Height / 2)) - 200, 20, 20));
                enemyProjectilesSpeedsX.Add(0);
                enemyProjectilesSpeedsY.Add(4);
                enemyProjectilesWait.Add(randGen.Next(30, 100));

                enemyProjectiles.Add(new Rectangle((player.X - (10 - player.Width / 2)) - 140, player.Y - ((10 - player.Height / 2)) - 140, 20, 20));
                enemyProjectilesSpeedsX.Add(2);
                enemyProjectilesSpeedsY.Add(2);
                enemyProjectilesWait.Add(randGen.Next(30, 100));

                if (difficultyMultiplier == 3)
                {
                    enemyProjectiles.Add(new Rectangle((player.X - (10 - player.Width / 2)) - 170, player.Y - ((10 - player.Height / 2)) + 70, 20, 20));
                    enemyProjectilesSpeedsX.Add(3);
                    enemyProjectilesSpeedsY.Add(-1);
                    enemyProjectilesWait.Add(randGen.Next(30, 100));

                    enemyProjectiles.Add(new Rectangle((player.X - (10 - player.Width / 2)) - 70, player.Y - ((10 - player.Height / 2)) + 170, 20, 20));
                    enemyProjectilesSpeedsX.Add(1);
                    enemyProjectilesSpeedsY.Add(-3);
                    enemyProjectilesWait.Add(randGen.Next(30, 100));

                    enemyProjectiles.Add(new Rectangle((player.X - (10 - player.Width / 2)) + 70, player.Y - ((10 - player.Height / 2)) + 170, 20, 20));
                    enemyProjectilesSpeedsX.Add(-1);
                    enemyProjectilesSpeedsY.Add(-3);
                    enemyProjectilesWait.Add(randGen.Next(30, 100));

                    enemyProjectiles.Add(new Rectangle((player.X - (10 - player.Width / 2)) + 170, player.Y - ((10 - player.Height / 2)) + 70, 20, 20));
                    enemyProjectilesSpeedsX.Add(-3);
                    enemyProjectilesSpeedsY.Add(-1);
                    enemyProjectilesWait.Add(randGen.Next(30, 100));

                    enemyProjectiles.Add(new Rectangle((player.X - (10 - player.Width / 2)) + 170, player.Y - ((10 - player.Height / 2)) - 70, 20, 20));
                    enemyProjectilesSpeedsX.Add(-3);
                    enemyProjectilesSpeedsY.Add(1);
                    enemyProjectilesWait.Add(randGen.Next(30, 100));

                    enemyProjectiles.Add(new Rectangle((player.X - (10 - player.Width / 2)) + 70, player.Y - ((10 - player.Height / 2)) - 170, 20, 20));
                    enemyProjectilesSpeedsX.Add(-1);
                    enemyProjectilesSpeedsY.Add(3);
                    enemyProjectilesWait.Add(randGen.Next(30, 100));

                    enemyProjectiles.Add(new Rectangle((player.X - (10 - player.Width / 2)) - 70, player.Y - ((10 - player.Height / 2)) - 170, 20, 20));
                    enemyProjectilesSpeedsX.Add(1);
                    enemyProjectilesSpeedsY.Add(3);
                    enemyProjectilesWait.Add(randGen.Next(30, 100));

                    enemyProjectiles.Add(new Rectangle((player.X - (10 - player.Width / 2)) - 170, player.Y - ((10 - player.Height / 2)) - 70, 20, 20));
                    enemyProjectilesSpeedsX.Add(3);
                    enemyProjectilesSpeedsY.Add(1);
                    enemyProjectilesWait.Add(randGen.Next(30, 100));
                }
            }
        }

        public void SetTwoCaseTwo()
        {
            ronaldShouldBeMoving = false;

            if (difficultyMultiplier != 1)
            {
                individualAttackSetTwo -= difficultyMultiplier * difficultyMultiplier;
            }

            if (difficultyMultiplier == 3)
            {
                enemyProjectiles.Add(new Rectangle(Ronald.X + Ronald.Width / 2, Ronald.Y + Ronald.Height, 20, 20));
                AngleMovement(Ronald.X + Ronald.Width / 2, Ronald.Y + Ronald.Height, player.X + player.Width / 2 - 10, player.Y + player.Height / 2 - 10, 3);
                enemyProjectilesWait.Add(0);
            }
            else if (difficultyMultiplier == 2 && individualAttackSetTwo % 8 == 0)
            {
                enemyProjectiles.Add(new Rectangle(Ronald.X + Ronald.Width / 2, Ronald.Y + Ronald.Height, 20, 20));
                AngleMovement(Ronald.X + Ronald.Width / 2, Ronald.Y + Ronald.Height, player.X + player.Width / 2 - 10, player.Y + player.Height / 2 - 10, 3);
                enemyProjectilesWait.Add(0);
            }
            else if (difficultyMultiplier == 1 && individualAttackSetTwo % 30 == 0)
            {
                enemyProjectiles.Add(new Rectangle(Ronald.X + Ronald.Width / 2, Ronald.Y + Ronald.Height, 20, 20));
                AngleMovement(Ronald.X + Ronald.Width / 2, Ronald.Y + Ronald.Height, player.X + player.Width / 2 - 10, player.Y + player.Height / 2 - 10, 3);
                enemyProjectilesWait.Add(0);
            }
            if (individualAttackSetTwo <= 20)
            {
                ronaldShouldBeMoving = true;
            }
        }


        ////Angle Calculator
        public void AngleMovement(int xr, int yr, int xp, int yp, int speed)
        {
            double xMovement = 0;
            double yMovement = 0;

            int run = xp - xr;
            int rise = yp - yr;

            double hypontenous = Math.Sqrt(run * run + rise * rise);
            double newSpeed = Math.Sqrt(speed * speed + speed * speed) * Math.Sqrt(speed * speed + speed * speed);

            double divisionFactor = newSpeed / hypontenous;

            xMovement = run * divisionFactor;
            yMovement = rise * divisionFactor;

            //add projectile x and y speed
            enemyProjectilesSpeedsX.Add(Convert.ToInt32(xMovement));
            enemyProjectilesSpeedsY.Add(Convert.ToInt32(yMovement));
        }

    }
}
