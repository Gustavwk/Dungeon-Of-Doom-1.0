using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2.Items
{
    public abstract class Weapon : Item
    {
        protected Projectile projectile;
        private Texture2D sprite;

        public Projectile Projectile
        {
            get => projectile;
            set => projectile = value;
        }

        public Weapon(int x, int y, Mediator mediator) : base(x, y, mediator)
        {
            this.hitbox = new Rectangle(this.X, this.Y, WIDTH, HEIGHT);

        }

       

        public virtual void fire(int x, int y, Direction direction)
        {

        }
    }
}
