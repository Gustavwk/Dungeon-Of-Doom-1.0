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
using Game2.Player;
namespace Game2.Creep
{
    class Creep : GameObject
    {
        private Texture2D creepPicture;
        private int movementspeed = 1;
        private int WIDTH = 32;
        private int HEIGHT = 32;
        public int health = 100;
        private Rectangle hitbox;
        private Boolean alive = true;
        private int prevPositionX;
        private int prevPositionY;

        
        public void setX(int x)
        {
            this.X = x;
        }
        public void setY(int y)
        {
            this.Y = y;
        }

        public Creep(int x, int y, Mediator mediator) 
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
                this.X = this.X + movementspeed;
                this.Y = prevPositionY;
                this.X = prevPositionX;

                Debug.WriteLine("Creep Intersects with " + other);
                Debug.WriteLine("X: " + this.X);
                Debug.WriteLine("Y: " + this.Y);
            }

        }

        public override void Load()
        {
        
            creepPicture = Mediator.Game.Content.Load<Texture2D>("Creeps/First_Creep");
        }

        public override void Update(GameTime gameTime)
        {
            
            Debug.WriteLine(this.X + this.Y);

            this.hitbox = new Rectangle(this.X, this.Y, WIDTH, HEIGHT);


        }



        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {


            Texture2D texture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            texture.SetData(new Color[] { Color.Aqua });
            spriteBatch.Draw(texture, hitbox, Color.White);

            spriteBatch.Draw(creepPicture, hitbox, Color.White);


        }






    }

}
