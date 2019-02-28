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
        public Rectangle hitbox;
        
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
            this.hitbox = new Rectangle(this.posX,this.posY, 32,32);

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
            
            spriteBatch.Draw(defaultWall,hitbox, Color.White);
            //Nedenstående tegner en hitbox
            /*
            Texture2D texture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
             texture.SetData(new Color[] { Color.Aqua });
              spriteBatch.Draw(texture, hitbox, Color.White);
                */
}




}
}
