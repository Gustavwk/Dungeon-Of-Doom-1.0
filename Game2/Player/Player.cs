using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game2.Structures;

namespace Game2.Player
{
    class Player : GameObject
    {

        private Texture2D playerPicture;
        private int X;
        private int Y;
        private int MoveSpeed;
        private int WIDTH, HEIGHT;
        public int health;
        public Rectangle  hitbox;
        private Boolean alive = true;
        private int prevPositionX;
        private int prevPositionY;

        protected Boolean north = false;
        protected Boolean south = false;
        protected Boolean east = false;
        protected Boolean west = false;
       
        public Player(int x, int y)
        {
            health = 100;
            HEIGHT = 32;
            WIDTH = 32;
            MoveSpeed = 2;
            this.X = x;
            this.Y = y;
            this.prevPositionX = x;
            this.prevPositionY = y;

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
                this.X = this.X + this.MoveSpeed;
            }

            if (key.IsKeyDown(Keys.A))
            {
                this.prevPositionX = this.X;
                this.X = this.X - this.MoveSpeed;
            }

            if (key.IsKeyDown(Keys.S))
            {      
                this.prevPositionY = this.Y;
                this.Y = this.Y + this.MoveSpeed;
            }

            if (key.IsKeyDown(Keys.W))
            {
                this.prevPositionY = this.Y;
                this.Y = this.Y - this.MoveSpeed;
            }
        }

        public override void Update(GameTime gameTime)
        {
            movement();
            this.hitbox = new Rectangle(this.X, this.Y, WIDTH, HEIGHT);
           


           
           
         
        }


        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //Nedenstående tegner en hitbox
            
            Texture2D texture = new Texture2D(spriteBatch.GraphicsDevice,1,1);
            texture.SetData(new Color[]{Color.Aqua});
            spriteBatch.Draw(texture, hitbox, Color.White);
            
            spriteBatch.Draw(playerPicture, hitbox, Color.White);
        }

    }
}
