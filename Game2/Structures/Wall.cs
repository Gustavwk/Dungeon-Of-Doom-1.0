using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2.Structures
{
    class Wall : Structures
    {
        
        private Texture2D defaultWall;
     

        public Wall ( int x, int y, Mediator mediator) : base(mediator,x,y)
        {
           
            this.hitbox = new Rectangle(this.X,this.Y, 32,32);
        }

        public override void Load()
        {
           defaultWall = Mediator.Game.Content.Load<Texture2D>("wall/brick_gray_0");
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
