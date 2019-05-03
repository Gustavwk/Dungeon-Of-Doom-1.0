using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Game2.gameLogic;
using Game2.Structures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2
{
    class LavaTile : Tiles
    {
        private Texture2D spriteOne;
        private Texture2D spriteTwo;
        private Texture2D spriteThree;
        private Texture2D spriteFour;
        private int show;
        private double lastStir = 0;
        private int cooldown = 600;

        

        public LavaTile(int X, int Y, int loopCount, Mediator mediator) : base(X, Y, loopCount, mediator)
        {
        }

        public override bool intersects(GameObject other)
        {
            if (other is Player.Player)
            {

              
                if (lastStir >= cooldown-100)
                {
                    mediator.player.health = mediator.player.health - 1;
                
                  
                }
            }
            return true;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (show == 0){
                spriteBatch.Draw(spriteOne, hitbox, Color.White);
            }
            if (show == 1)
            {
                spriteBatch.Draw(spriteTwo, hitbox, Color.White);
            }
            if (show == 2)
            {
                spriteBatch.Draw(spriteThree, hitbox, Color.White);
            }
            if (show == 3)
            {
                spriteBatch.Draw(spriteFour, hitbox, Color.White);
            }
            
            
            
           
        }

        public override void Load()
        {
            spriteOne = Mediator.Game.Content.Load<Texture2D>("tiles/LavaTiles/lava_0");
            spriteTwo = Mediator.Game.Content.Load<Texture2D>("tiles/LavaTiles/lava_1");
            spriteThree = Mediator.Game.Content.Load<Texture2D>("tiles/LavaTiles/lava_2");
            spriteFour = Mediator.Game.Content.Load<Texture2D>("tiles/LavaTiles/lava_3");
        }

        public override void Update(GameTime gameTime)
        {
            lastStir += gameTime.ElapsedGameTime.TotalMilliseconds;
            Random random = new Random();
            if (lastStir > cooldown)
            {
                show = random.Next(4);
                lastStir = 0;
            }

        }
    }
}
