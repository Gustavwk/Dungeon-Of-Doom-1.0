using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private int X;
        private int Y;
        private int hpPlus;
        public Rectangle hitbox;

        public HealthBoost(int hpPlus, int x, int y)
        {
            this.hpPlus = hpPlus;
            this.X = x;
            this.Y = y;
            this.hitbox = new Rectangle(this.X, this.Y, 32, 32);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(healthBooster, new Rectangle(this.X, this.Y, 32, 32), Color.White);
        }

        public override void Load()
        {
            healthBooster = GameHolder.Game.Content.Load<Texture2D>("items/ruby_old");
        }

        public override void intersects(GameObject other)
        {
            if (other is Player.Player)
            {
                
                Player.Player p = (Player.Player) other;
                Debug.Write(this.healthBooster + " intersects with:" + p);
                p.health = p.health + hpPlus;
            }
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}

