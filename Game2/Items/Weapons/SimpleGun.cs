using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2.Items.Weapons
{
    class SimpleGun : Weapon
    {
        private Texture2D sprite;

        public SimpleGun(int x, int y, Mediator mediator) : base(x, y, mediator)
        {
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            this.Projectile = new SimpleGunProjectile(0, 0, Direction.NORTH, mediator);
            spriteBatch.Draw(sprite, new Rectangle(this.X, this.Y, 32, 32), Color.White);

        }

        public override void fire(int x, int y, Direction direction)
        {
            Projectile simpleGunProjectile = new SimpleGunProjectile(x, y, direction, mediator);
            simpleGunProjectile.Load();
            mediator.itemToBeAdded.Add(simpleGunProjectile);
        }

        public override void Load()
        {
            sprite = Mediator.Game.Content.Load<Texture2D>("Items/Weapons/urand_blowgun");
        }

        public override void intersects(GameObject other)
        {
            if (other is Player.Player)
            {
                mediator.player.Weapon = new SimpleGun(0, 0, mediator);
                mediator.itemToBeDeleted.Add(this);
            }
        }

        public override string ToString()
        {
            return "Simple Gun";
        }
    }
}
