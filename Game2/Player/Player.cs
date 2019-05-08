using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Threading;
using Game2.gameLogic;
using Game2.Items;
using Game2.Structures;

namespace Game2.Player
{

    class Player : GameObject, IMoveable

    {
        
        private Texture2D playerPictureRight;
        private Texture2D playerPictureLeft;
        private Texture2D playerPictureBack;
        private Texture2D playerPictureBackDmg;
        private Texture2D playerPictureLeftDmg;
        private Texture2D playerPictureRightDmg;
        public int movementspeed = 2;
        private int WIDTH = 24;
        private int HEIGHT = 24;
        public int health = 100;
        public Rectangle  hitbox;
        private Boolean alive = true;
        private int prevPositionX;
        private int prevPositionY;
        private int cooldown = 500; //mills between shots
        private double lastShot = 0;
        public Weapon weapon;
        private Direction direction;

        public int playerCooldown
        {
            get { return cooldown; }
            set { cooldown = value; }
        }

        public Weapon Weapon
        {
            get => weapon;
            set => weapon = value;
        }

        public int getX()
        {
            return this.X;
        }
        public int getY()
        {
            return this.Y;
        }






        public Player(int x, int y) //player bliver nød til at have sin egen constructor. pga rækkefølgen mediatoren bliver kaldt!
        {
            this.X = x;
            this.Y = y;
            this.prevPositionX = x;
            this.prevPositionY = y;
            this.hitbox = new Rectangle(this.X, this.Y, WIDTH, HEIGHT);
            this.priority = 5;

        }

        public override bool intersects(GameObject other)
        {
             if (other is Wall)
            {
               
                this.Y = prevPositionY;
                this.X = prevPositionX;
               
                Debug.WriteLine("Player Intersects with " + other);
                Debug.WriteLine("X: " + this.X);
                Debug.WriteLine("Y: " + this.Y);
            }

             return true;
        }

        public void setX(int x)
        {
            this.X = x;
        }
        public void setY(int y)
        {
            this.Y = y;
        }
       

        public override void Load()
        {
            playerPictureRight = Mediator.Game.Content.Load<Texture2D>("player/homeMadeSprite");
            playerPictureLeft = Mediator.Game.Content.Load<Texture2D>("Player/homeMadeSpriteReversed (2)");          
            playerPictureLeftDmg = Mediator.Game.Content.Load<Texture2D>("Player/homeMadeSpriteDamageReversed");
            playerPictureRightDmg = Mediator.Game.Content.Load<Texture2D>("Player/homeMadeSpriteDamage");
            playerPictureBack = Mediator.Game.Content.Load<Texture2D>("Player/homeMadeSpriteBack");
            playerPictureBackDmg = Mediator.Game.Content.Load<Texture2D>("Player/homeMadeSpriteDamgeBack");
          



        }

        public Boolean isDead(Boolean alive)
        {
            if (health >= 0)
            {
                this.alive = false;
            }

            return this.alive;
        }

        public void movement()
        { 
       
            KeyboardState key = Keyboard.GetState();

          


           if (key.IsKeyDown(Keys.A) && key.IsKeyDown(Keys.D) && key.IsKeyDown(Keys.S) || key.IsKeyDown(Keys.A) && key.IsKeyDown(Keys.D) && key.IsKeyDown(Keys.W))
            {
                this.direction = Direction.WEST;
                this.X = this.X - this.movementspeed;
            }

            #region skyd Skrådt



            
            /*if (key.IsKeyDown(Keys.D) && key.IsKeyDown(Keys.S))
            {
                this.direction = Direction.SOUTHEAST;
                this.prevPositionX = this.X;
                this.prevPositionY = this.Y;
                this.X = this.X + this.movementspeed;
                this.Y = this.Y + this.movementspeed;
            }

            if (key.IsKeyDown(Keys.A) && key.IsKeyDown(Keys.S))
            {
                this.direction = Direction.SOUTHWEST;
                this.prevPositionX = this.X;
                this.prevPositionY = this.Y;
                this.X = this.X - this.movementspeed;
                this.Y = this.Y + this.movementspeed;
            }

            if (key.IsKeyDown(Keys.D) && key.IsKeyDown(Keys.W))
            {
                this.direction = Direction.NORTHEAST;
                this.prevPositionX = this.X;
                this.prevPositionY = this.Y;
                this.X = this.X + this.movementspeed;
                this.Y = this.Y - this.movementspeed;
            }

            if (key.IsKeyDown(Keys.A) && key.IsKeyDown(Keys.W))
            {
                this.direction = Direction.NORTHWEST;
                this.prevPositionX = this.X;
                this.prevPositionY = this.Y;
                this.X = this.X - this.movementspeed;
                this.Y = this.Y - this.movementspeed;
            }*/
#endregion

            if (key.IsKeyDown(Keys.D))
            {
                this.direction = Direction.EAST;
                this.prevPositionX = this.X;
                this.X = this.X + this.movementspeed;
            }

            if (key.IsKeyDown(Keys.A))
            {
                this.direction = Direction.WEST;
                this.prevPositionX = this.X;
                this.X = this.X - this.movementspeed;
            }

            if (key.IsKeyDown(Keys.S))
            {
                this.direction = Direction.SOUTH;
                this.prevPositionY = this.Y;
                this.Y = this.Y + this.movementspeed;
            }

            if (key.IsKeyDown(Keys.W))
            {
                this.direction = Direction.NORTH;
                this.prevPositionY = this.Y;
                this.Y = this.Y - this.movementspeed;
            }
        }
        
       

        public override void Update(GameTime gameTime)
        {
            lastShot += gameTime.ElapsedGameTime.TotalMilliseconds;
            movement();
            shooting(gameTime);
           
            
                
            

            this.hitbox = new Rectangle(this.X, this.Y, WIDTH, HEIGHT);
           
         
        }

        public void shooting(GameTime gameTime)
        {
            

            KeyboardState key = Keyboard.GetState();
            if (key.IsKeyDown(Keys.Space))
            {


                if ( lastShot > cooldown)
                {
                    lastShot = 0;

                    if (weapon != null)
                    {
                        mediator.player.weapon.fire(this.X,this.Y,this.direction);
                    }
                    else if (weapon == null)
                    {
                        fireDefualt(this.X, this.Y, this.direction);
                    }
                }
       
            }
        }

        private void fireDefualt(int x, int y, Direction direction)
        {
            Projectile defaultProjectile = new Projectile(x,y,direction, mediator);
            defaultProjectile.Load();
            mediator.itemToBeAdded.Add(defaultProjectile);
        }


        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(playerPictureRight, hitbox, Color.White);

            
            if (health < 50)
            {
                if (direction == Direction.SOUTH)
                {
                    spriteBatch.Draw(playerPictureRightDmg, hitbox, Color.White);
                }

                if (direction == Direction.EAST)
                {
                    spriteBatch.Draw(playerPictureRightDmg, hitbox, Color.White);
                }

                if (direction == Direction.WEST)
                {
                    spriteBatch.Draw(playerPictureLeftDmg, hitbox, Color.White);
                }

                if (direction == Direction.NORTH)
                {
                    spriteBatch.Draw(playerPictureBackDmg, hitbox, Color.White);
                }
            }

            else

            {

                if (direction == Direction.EAST)
                {
                    spriteBatch.Draw(playerPictureRight, hitbox, Color.White);
                }

                if (direction == Direction.WEST)
                {
                    spriteBatch.Draw(playerPictureLeft, hitbox, Color.White);
                }

                if (direction == Direction.NORTH)
                {
                    spriteBatch.Draw(playerPictureBack, hitbox, Color.White);
                }
            }



        }
    }
}
