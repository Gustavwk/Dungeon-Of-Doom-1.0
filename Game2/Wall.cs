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
        
        private SpriteBatch spriteBatch;
        private Texture2D wallPicture;
        private int posX;
        private int posY;
        


        public Wall ( Texture2D wallPicture, int posX, int posY)
        {
            this.wallPicture = wallPicture;
            this.posX = posX;
            this.posY = posY; 

        }

       
        public override void Update(GameTime gameTime)
        {
            // her er evt logik for en wall
            // kalder gameobjekts update metode
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
           
            base.Draw(gameTime);
            spriteBatch.Draw(wallPicture, new Rectangle(posX, posY, 50, 50), Color.White);
            

          
            //  "Wall" skal tegnes her. 
           
        }

       

    }
}
