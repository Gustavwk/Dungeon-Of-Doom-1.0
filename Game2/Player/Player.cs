using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Game2.gameLogic;
using Game2.Structures;

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
        public List<GameObject> projectiles = new List<GameObject>();
        public Mediator mediator { get; set; }

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
            if (other is Tiles)
            {
            }
            else
            {

                this.Y = prevPositionY;
                this.X = prevPositionX;
                Debug.WriteLine("Player Intersects");
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
            playerPicture = GameHolder.Game.Content.Load<Texture2D>("player/bloody");
            
           
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
                mediator.AllObjects.Add(new Projectile(this.X, this.Y,  key));
                Debug.WriteLine("SHOOT UP");
                

            }

            if (key.IsKeyDown(Keys.Left))
            {

                
                //projectiles.Add(new Projectile(this.X, this.Y, key));
                Debug.WriteLine("SHOOT LEFT");
            }

            if (key.IsKeyDown(Keys.Down))
            {

                projectiles.Add(new Projectile(this.X, this.Y,  key));
                Debug.WriteLine("SHOOT DOWN");
            }

            if (key.IsKeyDown(Keys.Right))
            {

                projectiles.Add(new Projectile(this.X, this.Y,  key));
                Debug.WriteLine("SHOOT RIGHT");
            }

        }
       

        public override void Update(GameTime gameTime)
        {
            movement();
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                shooting();
            }
            
            

            this.hitbox = new Rectangle(this.X, this.Y, WIDTH, HEIGHT);
           
         
        }


        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (GameObject projectile in projectiles)
            {
                projectile.Draw(spriteBatch, gameTime);
            }
            
            Texture2D texture = new Texture2D(spriteBatch.GraphicsDevice,1,1);
            texture.SetData(new Color[]{Color.Aqua});
            spriteBatch.Draw(texture, hitbox, Color.White);
            
            spriteBatch.Draw(playerPicture, hitbox, Color.White);

           
        }
    }
}
