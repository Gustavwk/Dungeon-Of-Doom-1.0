using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Threading;
using Game2.gameLogic;
using Game2.Structures;

namespace Game2.Player
{

    class Player : GameObject

    {

        private Texture2D playerPicture;
        private int movementspeed = 2;
        private int WIDTH = 32;
        private int HEIGHT = 32;
        public int health = 100;
        public Rectangle  hitbox;
        private Boolean alive = true;
        private int prevPositionX;
        private int prevPositionY;
        private int cooldown = 500; //mills between shots
        private double lastShot = 0;
        private Direction direction;

        

        public String GetDirection()
        {
            if (this.direction == Direction.NORTH)
            {
                return "NORTH";
            } else if (this.direction == Direction.SOUTH)
            {
                return "SOUTH";
            }
            else if (this.direction == Direction.EAST)
            {
                return "EAST";
            }
            else if ( this.direction == Direction.WEST)
            {
                return "WEST";
            }
            else
            {
                return "NONE";
            }

            
        }



        public Player(int x, int y) //layer bliver nød til at have sin egen constructor. pga rækkefølgen mediatoren bliver kaldt!
        {
            this.X = x;
            this.Y = y;
            this.prevPositionX = x;
            this.prevPositionY = y;
            this.hitbox = new Rectangle(this.X, this.Y, WIDTH, HEIGHT);
           

        }

        public override void intersects(GameObject other)
        {
            if (other is Tiles || other is Projectile)
            {
            }
            else
            {
                /*
                Random random = new Random();
                mediator.AllObjects.Add(new HealthBoost(random.Next(100), random.Next(100), 100));
                */ // Burde man ikke kunne tilføje løbende til programmet sådan her ??????

                this.Y = prevPositionY;
                this.X = prevPositionX;
               
                Debug.WriteLine("Player Intersects with " + other);
                Debug.WriteLine("X: " + this.X);
                Debug.WriteLine("Y: " + this.Y);
            }

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
            playerPicture = Mediator.Game.Content.Load<Texture2D>("player/bloody");
            
           
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

          


            if (key.IsKeyDown(Keys.A) && key.IsKeyDown(Keys.D) && key.IsKeyDown(Keys.S))
            {
                this.direction = Direction.WEST;
                this.X = this.X - movementspeed;
            }
            else if (key.IsKeyDown(Keys.A) && key.IsKeyDown(Keys.D) && key.IsKeyDown(Keys.W))
            {
                this.direction = Direction.WEST;
                this.X = this.X - movementspeed;
            }

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
                    //https://stackoverflow.com/questions/25613008/how-to-toggle-a-key-press Det her kunne være et fix!


                    Projectile defaultProjectile = new Projectile(this.X, this.Y, this.direction, mediator);
                    defaultProjectile.Load();
                    mediator.itemToBeAdded.Add(defaultProjectile);
                    

                }


                   
            }
        }


        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            
            
            Texture2D texture = new Texture2D(spriteBatch.GraphicsDevice,1,1);
            texture.SetData(new Color[]{Color.Aqua});
            spriteBatch.Draw(texture, hitbox, Color.White);
            
            spriteBatch.Draw(playerPicture, hitbox, Color.White);

           
        }
    }
}
