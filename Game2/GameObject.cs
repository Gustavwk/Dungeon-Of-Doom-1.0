using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Game2.Structures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using IDrawable = Game2.gameLogic.IDrawable;
using IUpdateable = Game2.gameLogic.IUpdateable;

namespace Game2
{
    abstract class GameObject : IMediator, IUpdateable, IDrawable, ICollideable, IComparable
    {
        private Texture2D defaultSprite;
        public Rectangle hitbox;
        protected int X;
        protected int Y;
        protected int WIDTH = 32;
        protected int HEIGHT = 32;
        protected SoundEffect effect;
        protected int priority = 2;
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

        public virtual void playEffect()
        {
            if (effect != null)
            {
                effect.Play();
            }
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


        public int CompareTo(object obj)
        {
            GameObject gameObject = (GameObject)obj;
            int rtn = 0;

            if (this.priority < gameObject.priority) { rtn = -1; }
            if (this.priority > gameObject.priority) { rtn = +1; }
            return rtn;
        }
    }
}

