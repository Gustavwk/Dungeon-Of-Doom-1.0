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
        /*public int wall_Left;
        public int wall_Right;
        public int wall_Top;
        public int wall_Bottom;*/
        

        public Wall ( int posX, int posY)
        {
      
            this.posX = posX;
            this.posY = posY; 
            this.hitbox = new Rectangle(this.posX,this.posY, 32,32);
            /*this.wall_Left = this.hitbox.Left;
            this.wall_Right = this.hitbox.Right;
            this.wall_Bottom = this.hitbox.Bottom;
            this.wall_Top = this.hitbox.Top;*/


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
            
}




}
}
