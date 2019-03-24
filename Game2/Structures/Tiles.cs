using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2.Structures
{
    class Tiles : Structures
    {
        private Texture2D tilesPicOne;
        private Texture2D tilesPicTwo;
        private Texture2D tilesPicThree;
        private Texture2D tilesPicFour;
       

        private int loopCount = 1;

        public Tiles(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            this.hitbox = new Rectangle(this.X, this.Y, 32, 32);
            

        }

        public override void Load()
        {
            tilesPicOne = GameHolder.Game.Content.Load<Texture2D>("tiles/sandstone_floor_6");
            tilesPicTwo = GameHolder.Game.Content.Load<Texture2D>("tiles/sandstone_floor_7");
            tilesPicThree = GameHolder.Game.Content.Load<Texture2D>("tiles/sandstone_floor_8");
            tilesPicFour = GameHolder.Game.Content.Load<Texture2D>("tiles/sandstone_floor_9");

            //defaultWall = GameHolder.Game.Content.Load<Texture2D>("wall/brick_gray_0");
        }

        public override void intersects(GameObject other)
        {
            if (other is Player.Player)
            {

                



            }
        }


        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }


        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (loopCount == 1)
            {
                spriteBatch.Draw(tilesPicOne, hitbox, Color.White);
            }

            if (this.loopCount == 2)
            {
                spriteBatch.Draw(tilesPicTwo, hitbox, Color.White);
            }
            else if (this.loopCount == 3)
            {
                spriteBatch.Draw(tilesPicThree, hitbox, Color.White);
            }
            else if(this.loopCount == 4)
            {
                spriteBatch.Draw(tilesPicFour, hitbox, Color.White);
            }


            

        }
    }
}
