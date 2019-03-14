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
        private int X;
        private int Y;
        public Rectangle hitbox;

        public Wall ( int x, int y)
        {
            this.X = x;
            this.Y = y; 
            this.hitbox = new Rectangle(this.X,this.Y, 32,32);
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
