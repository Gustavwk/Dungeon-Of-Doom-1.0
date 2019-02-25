using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2.Structures
{
    class Wall : GameObject
    {
        
        
        private Texture2D defaultWall;
        private int posX;
        private int posY;
        
             public Rectangle Rectangle
        {
            get
            {
                return new Rectangle( posX, posY, defaultWall.Width, defaultWall.Height);
            }
        }

        public Wall ( int posX, int posY)
        {
      
            this.posX = posX;
            this.posY = posY; 

        }

        public override void Load()
        {
           defaultWall = GameHolder.Game.Content.Load<Texture2D>("wall/brick_gray_0");
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }


        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(defaultWall,new Rectangle(this.posX,this.posY, 32, 32), Color.White);
        }


        #region Collision 
        protected bool isTouchingLeft ( Wall Wall)
        {
            return this.Rectangle.Right + this.posX > Wall.Rectangle.Left &&
                this.Rectangle.Left < Wall.Rectangle.Left &&
                this.Rectangle.Bottom > Wall.Rectangle.Top &&
                this.Rectangle.Top < Wall.Rectangle.Bottom;




        }
        protected bool isTouchingRight(Wall Wall)
        {
            return this.Rectangle.Left + this.posX > Wall.Rectangle.Right &&
                this.Rectangle.Right < Wall.Rectangle.Right &&
                this.Rectangle.Bottom > Wall.Rectangle.Top &&
                this.Rectangle.Top < Wall.Rectangle.Bottom;




        }
        protected bool isTouchingTop(Wall Wall)
        {
            return this.Rectangle.Bottom + this.posX > Wall.Rectangle.Top &&
                this.Rectangle.Top < Wall.Rectangle.Top &&
                this.Rectangle.Right > Wall.Rectangle.Left &&
                this.Rectangle.Left < Wall.Rectangle.Right;




        }
        protected bool isTouchingBottom(Wall Wall)
        {
            return this.Rectangle.Top + this.posX > Wall.Rectangle.Bottom &&
                this.Rectangle.Bottom < Wall.Rectangle.Bottom &&
                this.Rectangle.Right > Wall.Rectangle.Left &&
                this.Rectangle.Left < Wall.Rectangle.Right;




        }



        #endregion

    }
}
