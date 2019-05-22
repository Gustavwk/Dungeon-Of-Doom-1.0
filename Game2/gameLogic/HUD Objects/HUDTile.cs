using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.Structures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2.gameLogic.HUD_Objects
{
    class HUDTile : Tiles

    {

        private Texture2D backgroundOne;
        private Texture2D backgroundTwo;
        private Texture2D backgroundThree;
        private Texture2D backgroundFour;
        private Texture2D backgroundFive;

        private int show = 0;

        public int Show;
       
        public HUDTile(int X, int Y, int loopCount, Mediator mediator) : base(X,Y,loopCount,mediator)
        {
            show = loopCount;
            this.priority = 0;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (show == 0)
            {
                spriteBatch.Draw(backgroundOne, hitbox, Color.White);
            }
            if (show == 1)
            {
                spriteBatch.Draw(backgroundTwo, hitbox, Color.White);
            }
            if (show == 2)
            {
                spriteBatch.Draw(backgroundThree, hitbox, Color.White);
            }
            if (show == 3)
            {
                spriteBatch.Draw(backgroundFour, hitbox, Color.White);
            }
            if (show == 4)
            {
                spriteBatch.Draw(backgroundFive, hitbox, Color.White);
            }
        }

        public override void Update(GameTime gameTime)
        {
          
        }

        public override void Load()
        {
            backgroundOne = Mediator.Game.Content.Load<Texture2D>("HUD/etched_0");
            backgroundTwo = Mediator.Game.Content.Load<Texture2D>("HUD/etched_1");
            backgroundThree = Mediator.Game.Content.Load<Texture2D>("HUD/etched_2");
            backgroundFour = Mediator.Game.Content.Load<Texture2D>("HUD/etched_3");
            backgroundFive = Mediator.Game.Content.Load<Texture2D>("HUD/etched_4");
        }

        public override bool Collision(GameObject other)
        {
            return true;
        }
    }
}
