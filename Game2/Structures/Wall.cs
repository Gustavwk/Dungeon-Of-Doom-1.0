using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2
{
    class Wall : GameObject
    {
        
        
        private Texture2D defaultWall;
        private int posX;
        private int posY;
        


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

       

    }
}
