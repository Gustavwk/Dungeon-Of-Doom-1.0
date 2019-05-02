using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2.Items.Weapons
{
    class Wand : Weapon 
    {
        private Texture2D sprite;
        public Wand(int x, int y, Mediator mediator) : base(x, y, mediator)
        {
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            this.Projectile = new WandProjectile(0,0,Direction.NORTH,mediator);
            spriteBatch.Draw(sprite, new Rectangle(this.X, this.Y, 32, 32), Color.White);

        }

        public override void fire(int x, int y, Direction direction)
        {
            Projectile wandProjectile = new WandProjectile(x, y, direction, mediator);
            wandProjectile.Load();
            mediator.itemToBeAdded.Add(wandProjectile);
        }

        public override void Load()
        {
            sprite = Mediator.Game.Content.Load<Texture2D>("Items/Weapons/spwpn_staff_of_dispater_new");
        }

        public override void intersects(GameObject other)
        {
            if (other is Player.Player)
            {
                mediator.player.Weapon = new Wand(0, 0, mediator);
                mediator.itemToBeDeleted.Add(this);
            }
        }

        public override string ToString()
        {
            return "Wand";
        }
    }
}
