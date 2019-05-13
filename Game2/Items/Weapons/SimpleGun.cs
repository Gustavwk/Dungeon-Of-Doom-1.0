using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Game2.Items.Weapons
{
    class SimpleGun : Weapon
    {
        private Texture2D sprite;
        private SoundEffect pickupSimpleGun;
        private SoundEffect shoot;

        public SimpleGun(int x, int y, Mediator mediator) : base(x, y, mediator)
        {
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            this.Projectile = new SimpleGunProjectile(0, 0, Direction.NORTH, mediator);
            spriteBatch.Draw(sprite, new Rectangle(this.X, this.Y, WIDTH, HEIGHT), Color.White);

        }

        public override void fire(int x, int y, Direction direction)
        {
            Projectile simpleGunProjectile = new SimpleGunProjectile(x, y, direction, mediator);
            this.Load();
            shoot.CreateInstance().Play();
            simpleGunProjectile.Load();
            mediator.itemToBeAdded.Add(simpleGunProjectile);
        }

        public override void Load()
        {
            sprite = Mediator.Game.Content.Load<Texture2D>("Items/Weapons/urand_blowgun");
            pickupSimpleGun = Mediator.Game.Content.Load<SoundEffect>("Sounds/PickupSimpleGun");
            shoot = Mediator.Game.Content.Load<SoundEffect>("Sounds/SimpleGun");
        }

        public override bool intersects(GameObject other)
        {
            if (other is Player.Player)
            {
                mediator.player.Weapon = new SimpleGun(0, 0, mediator);
                mediator.itemToBeDeleted.Add(this);
                pickupSimpleGun.CreateInstance().Play();
            }
            return true;
        }

        public override string ToString()
        {
            return "Simple Gun";
        }
    }
}
