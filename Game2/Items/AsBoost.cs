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
    class AsBoost : Item, IPowerUp
    {
        private Texture2D filledSpeedBoost;
        private Texture2D emptySpeedBoost;
        private double duration = 250;
        private int cooldownReduction = 150;
        private bool active = false;
        private bool taken = false;

        public AsBoost(int x, int y, Mediator mediator) : base(x, y, mediator)
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

        public override bool intersects(GameObject other)
        {
            PlayerInteraction(other);
            return true;
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

        public override void Update(GameTime gameTime) //Det virker nu, men jeg tror det kan gøres bedre!
        {
            EffectForDuration();
        }

      public void EffectForDuration()
        {
            if (taken)
            {
                if (active)
                {
                    mediator.player.playerCooldown = cooldownReduction;
                    duration--;
                }

                if (duration < 1)

                {
                    active = false;
                    mediator.player.playerCooldown = 500;
                    duration = 300; // Det virker nu - den skal bare sættets over 1 den her
                }


            }
        }

        public override void Load()
        {
            filledSpeedBoost = Mediator.Game.Content.Load<Texture2D>("items/potion_bubbly");
            emptySpeedBoost = Mediator.Game.Content.Load<Texture2D>("items/white_old");
        }
    }
}
