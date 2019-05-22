using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Game2.Structures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Game2
{
  public class CrossbowProjectile : Projectile
    {

        public CrossbowProjectile(int x, int y, Direction direction, Mediator mediator) : base(x, y, direction, mediator)
        {
            this.damage = 50;
        }

        public override void Load()
        {
            this.projectileTextureUp = Mediator.Game.Content.Load<Texture2D>("Projectiles/CrossbowProjectiles/arrow_0");
            this.projectileTextureRight = Mediator.Game.Content.Load<Texture2D>("Projectiles/CrossbowProjectiles/arrow_2");
            this.projectileTextureLeft = Mediator.Game.Content.Load<Texture2D>("Projectiles/CrossbowProjectiles/arrow_6");
            this.projectileTextureDown = Mediator.Game.Content.Load<Texture2D>("Projectiles/CrossbowProjectiles/arrow_4");

            hitMonster = Mediator.Game.Content.Load<SoundEffect>("Sounds/Hit");
            hitWall = Mediator.Game.Content.Load<SoundEffect>("Sounds/HitWall");
        }
    }
}
