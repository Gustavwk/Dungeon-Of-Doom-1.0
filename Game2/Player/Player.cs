using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Game2.Player
{
    class Player : GameObject
    {

        private Texture2D playerPicture;
        private Texture2D projectileTexture; // the projectile texture
        private int movementspeed = 2;
        private int WIDTH = 32;
        private int HEIGHT = 32;
        public int health = 100;
        public Rectangle  hitbox;
        private Boolean alive = true;
        private int prevPositionX;
        private int prevPositionY;
       

        protected Boolean north = false;
        protected Boolean south = false;
        protected Boolean east = false;
        protected Boolean west = false;
        //public List<Projectile> projectileList; // not sure yet
       
        public Player(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.prevPositionX = x;
            this.prevPositionY = y;
            this.hitbox = new Rectangle(this.X, this.Y, WIDTH, HEIGHT);
        }

        public override void intersects(GameObject other)
        {

            this.Y = prevPositionY;
            this.X = prevPositionX;
            Debug.WriteLine("Player Intersects");
            Debug.WriteLine("X: " + this.X);
            Debug.WriteLine("Y: " + this.Y);
            
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
            playerPicture = GameHolder.Game.Content.Load<Texture2D>("player/bloody");
            
           projectileTexture = GameHolder.Game.Content.Load<Texture2D>("Projectiles/DefaultProjectiles/1_HeroShotgunBulletFrames (1)");
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
            if (key.IsKeyDown(Keys.D))
            {
                this.prevPositionX = this.X;
                this.X = this.X + this.movementspeed;
            }

            if (key.IsKeyDown(Keys.A))
            {
                this.prevPositionX = this.X;
                this.X = this.X - this.movementspeed;
            }

            if (key.IsKeyDown(Keys.S))
            {      
                this.prevPositionY = this.Y;
                this.Y = this.Y + this.movementspeed;
            }

            if (key.IsKeyDown(Keys.W))
            {
                this.prevPositionY = this.Y;
                this.Y = this.Y - this.movementspeed;
            }
        }
        public void shooting()
         {
            
            KeyboardState key = Keyboard.GetState();
            if (key.IsKeyDown(Keys.Up))
            {
                Projectiles projectiles = new Projectiles(this.X, this.Y,projectileTexture,key);
                //Projectiles projectiles = new Projectiles(projectileTexture);
                //projectiles.Y = Y --;
            }

            if (key.IsKeyDown(Keys.Left))
            {
               
                this.X = this.X - this.movementspeed;
            }

            if (key.IsKeyDown(Keys.Down))
            {
                
                this.Y = this.Y + this.movementspeed;
            }

            if (key.IsKeyDown(Keys.Right))
            {
                
                this.X = this.X + this.movementspeed;
            }

        }
       

        public override void Update(GameTime gameTime)
        {
            movement();
            shooting();

            this.hitbox = new Rectangle(this.X, this.Y, WIDTH, HEIGHT);
           
         
        }


        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //Nedenstående tegner en hitbox
            
            Texture2D texture = new Texture2D(spriteBatch.GraphicsDevice,1,1);
            texture.SetData(new Color[]{Color.Aqua});
            spriteBatch.Draw(texture, hitbox, Color.White);
            
            spriteBatch.Draw(playerPicture, hitbox, Color.White);

            /*if (Keyboard.GetState().IsKeyDown(Keys.Up)) { 
            Texture2D texture2 = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            texture2.SetData(new Color[] { Color.Aqua });
            spriteBatch.Draw(texture2, hitbox, Color.White);

            spriteBatch.Draw(projectileTexture, hitbox, Color.White);
            }*/
        }
    }
}
