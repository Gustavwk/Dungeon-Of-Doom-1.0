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
using IDrawable = Game2.gameLogic.IDrawable;
using IUpdateable = Game2.gameLogic.IUpdateable;

namespace Game2
{
    abstract class GameObject : IMediator, IUpdateable, IDrawable, ICollideable
    {
        private Texture2D defaultSprite;
        public Rectangle hitbox;
        protected int X;
        protected int Y;
        public Mediator mediator { get; set; }

        public GameObject()
        {
            
        }
        public GameObject(Mediator mediator, int x, int y)
        {
            this.mediator = mediator;
            this.X = x;
            this.Y = y;
        }

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


        public virtual bool intersects(GameObject other)
        {
            return true;
        }

        
    }
}

