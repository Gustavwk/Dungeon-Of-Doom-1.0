using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2
{
    class SpeedBoost : Items
    {
        private Texture2D filledSpeedBoost;
        private Texture2D emptySpeedBoost;
        private bool taken = false;
        public SpeedBoost(int x, int y, Mediator mediator) : base(x, y, mediator)
        {
            this.hitbox = new Rectangle(this.X, this.Y, 32, 32);
        }


        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (taken)
            {
                spriteBatch.Draw(emptySpeedBoost, new Rectangle(this.X,this.Y,32,32), Color.White);
            }
            else

            {
                spriteBatch.Draw(filledSpeedBoost, new Rectangle(this.X, this.Y, 32, 32), Color.White);
            }
        }

        public override void intersects(GameObject other)
        {
            if (other is Player.Player)
            {
                Player.Player p = (Player.Player) other;
                p.playerCooldown = 50;
             
                taken = true;
                this.hitbox = Rectangle.Empty;
            }
        }
        public override void Update(GameTime gameTime)
        {

        }

        public override void Load()
        {
            filledSpeedBoost = Mediator.Game.Content.Load<Texture2D>("items/potion_bubbly");
            emptySpeedBoost = Mediator.Game.Content.Load<Texture2D>("items/white_old");
        }
    }
}
