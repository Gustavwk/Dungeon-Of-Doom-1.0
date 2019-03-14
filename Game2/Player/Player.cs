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
        private int posX;
        private int posY;
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
       
        public Player(int posX, int posY)
        {
            health = 100;
            HEIGHT = 32;
            WIDTH = 32;
            MoveSpeed = 2;
            this.posX = posX;
            this.posY = posY;
            this.prevPositionX = posX;
            this.prevPositionY = posY;

        }

        public override void intersects(GameObject other)
        {

            this.posY = prevPositionY;
            this.posX = prevPositionX;
            Debug.WriteLine("Player Intersects");
            Debug.WriteLine("X: " + this.posX);
            Debug.WriteLine("Y: " + this.posY);
            
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
                this.prevPositionX = this.posX;
                this.posX = this.posX + this.MoveSpeed;
            }

            if (key.IsKeyDown(Keys.A))
            {
                this.prevPositionX = this.posX;
                this.posX = this.posX - this.MoveSpeed;
            }

            if (key.IsKeyDown(Keys.S))
            {      
                this.prevPositionY = this.posY;
                this.posY = this.posY + this.MoveSpeed;
            }

            if (key.IsKeyDown(Keys.W))
            {
                this.prevPositionY = this.posY;
                this.posY = this.posY - this.MoveSpeed;
            }
        }

        public override void Update(GameTime gameTime)
        {
            movement();
            this.hitbox = new Rectangle(this.posX, this.posY, WIDTH, HEIGHT);
           


           
           
         
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
