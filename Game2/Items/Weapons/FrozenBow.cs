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
    
    class FrozenBow : Weapon
    {
        public FrozenBow(int x, int y, Mediator mediator) : base(x, y, mediator)
        {
        }

        private Texture2D sprite;

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

            spriteBatch.Draw(sprite, new Rectangle(this.X, this.Y, 32, 32), Color.White);
            this.Projectile = new FrozenBowProjectile(0, 0, Direction.NORTH, mediator);
        }

        public override void fire(int x, int y, Direction direction)
        {
            Projectile frozenBowProjectile = new FrozenBowProjectile(x, y, direction, mediator);
            frozenBowProjectile.Load();
            mediator.itemToBeAdded.Add(frozenBowProjectile);
        }

        public override void Load()
        {
            sprite = Mediator.Game.Content.Load<Texture2D>("Items/Weapons/urand_piercer_new");
        }

        public override bool intersects(GameObject other)
        {
            if (other is Player.Player)
            {
                mediator.player.Weapon = new FrozenBow(0, 0, mediator);
                mediator.itemToBeDeleted.Add(this);
            }
            return true;
        }

        public override string ToString()
        {
            return "Frozen Bow";
        }
    }
}

