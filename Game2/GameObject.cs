using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Game2.Structures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2
{
    abstract class GameObject : IMediator
    {
        private Texture2D defaultSprite;
        public Rectangle hitbox;
        protected int X;
        protected int Y;
        public Mediator mediator { get; set; }




        public virtual void Update(GameTime gameTime)
        {
           
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            
        }

        public virtual void Load()
        {
           
        }


        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(this.X, this.Y, defaultSprite.Width, defaultSprite.Height); 

            }
        }

        public void drawHitbox() { }


        public virtual void intersects(GameObject other)
        {

        }

        
    }
}

