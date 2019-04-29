using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Game2.Structures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2
{
    class CrossbowProjectile : Projectile
    {
        private int damage = 10;

        public CrossbowProjectile(int x, int y, Direction direction, Mediator mediator) : base(x, y, direction, mediator)
        {
            this.hitbox = new Rectangle(this.X, this.Y, WIDTH, HEIGHT);
            this.direction = direction;
        }



        public override void Load()
        {
            this.projectileTextureUp = Mediator.Game.Content.Load<Texture2D>("Projectiles/CrossbowProjectiles/arrow_0");
            this.projectileTextureRight = Mediator.Game.Content.Load<Texture2D>("Projectiles/CrossbowProjectiles/arrow_2");
            this.projectileTextureLeft = Mediator.Game.Content.Load<Texture2D>("Projectiles/CrossbowProjectiles/arrow_6");
            this.projectileTextureDown = Mediator.Game.Content.Load<Texture2D>("Projectiles/CrossbowProjectiles/arrow_4");
            this.projectileTextureNorthEast = Mediator.Game.Content.Load<Texture2D>("Projectiles/CrossbowProjectiles/arrow_1");
            this.projectileTextureNorthWest = Mediator.Game.Content.Load<Texture2D>("Projectiles/CrossbowProjectiles/arrow_7");
            this.projectileTextureSouthEast = Mediator.Game.Content.Load<Texture2D>("Projectiles/CrossbowProjectiles/arrow_3");
            this.projectileTextureSouthWest = Mediator.Game.Content.Load<Texture2D>("Projectiles/CrossbowProjectiles/arrow_5");
        }

        public override void intersects(GameObject other)
        {
            if (other is Wall)
            {
                //Hvis projectil rammer en væg så mister den sin hitbox og bliver ikke tegnet mere!
                shouldDraw = false;
                hitbox = Rectangle.Empty;
            }

            if (other is Creep.Creep)
            {
                Creep.Creep p = (Creep.Creep)other;

                p.health = p.health - damage;
                shouldDraw = false;
            }


        }

    }
}
