using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2
{
    class MsBoost : Items, IPowerUp
    {
        private Texture2D filledPotion;
        private Texture2D emptyPotion;
        private bool active = false;
        private bool taken = false;
        private double duration = 250;
        private int speedBoost = 4;

        public MsBoost(int x, int y, Mediator mediator) : base(x, y, mediator)
        {
            this.hitbox = new Rectangle(this.X, this.Y, 32, 32);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (taken)
            {
                spriteBatch.Draw(emptyPotion, new Rectangle(this.X, this.Y, 32, 32), Color.White);
            }
            else

            {
                spriteBatch.Draw(filledPotion, new Rectangle(this.X, this.Y, 32, 32), Color.White);
            }
        }

        public override void Update(GameTime gameTime)
        {
            EffectForDuration();
        }


        public void EffectForDuration()
        {
            if (taken)
            {
                if (active)
                {
                    mediator.player.movementspeed = speedBoost;
                    duration--;
                }

                if (duration < 1)

                {
                    active = false;
                    mediator.player.movementspeed = 2;
                    duration = 300; 
                }
            }
        }

        public override void Load()
        {
            filledPotion = Mediator.Game.Content.Load<Texture2D>("items/Potions/yellow_old");
            emptyPotion = Mediator.Game.Content.Load<Texture2D>("items/white_old");
        }

        public override void intersects(GameObject other)
        {
            PlayerInteraction(other);
        }

        public void PlayerInteraction(GameObject other)
        {
            if (other is Player.Player)
            {
                Player.Player p = (Player.Player) other;

                taken = true;
                active = true;
                this.hitbox = Rectangle.Empty;
            }
        }
    }
}
