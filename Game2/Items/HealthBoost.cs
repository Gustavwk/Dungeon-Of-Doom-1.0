using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2
{
    class HealthBoost : Items
    {

        private Texture2D healthBooster;
        private int posX;
        private int posY;
        private int hpPlus;

        public HealthBoost(int hpPlus, int posX, int posY)
        {
            this.hpPlus = hpPlus;
            this.posX = posX;
            this.posY = posY;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(healthBooster, new Rectangle(this.posX, this.posY, 32, 32), Color.White);
        }

        public override void Load()
        {
            healthBooster = GameHolder.Game.Content.Load<Texture2D>("items/ruby_old");
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}

