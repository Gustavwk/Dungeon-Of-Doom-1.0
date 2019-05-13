using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2;
using Game2.gameLogic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Game2
{
    class WandProjectile : Projectile
    {
        SoundEffect shoot;

        public WandProjectile(int x, int y, Direction direction, Mediator mediator) : base(x, y, direction, mediator)
        {
            this.damage = 100;
           //shoot.CreateInstance().Play();
        }


        public override void Load()
        {
            this.projectileTextureUp = Mediator.Game.Content.Load<Texture2D>("Projectiles/WandProjectile/magic_dart_0");
            this.projectileTextureRight = Mediator.Game.Content.Load<Texture2D>("Projectiles/WandProjectile/magic_dart_3");
            this.projectileTextureLeft = Mediator.Game.Content.Load<Texture2D>("Projectiles/WandProjectile/magic_dart_0");
            this.projectileTextureDown = Mediator.Game.Content.Load<Texture2D>("Projectiles/WandProjectile/magic_dart_3");
            this.projectileTextureNorthEast = null;
            this.projectileTextureNorthWest = null;
            this.projectileTextureSouthEast = null;
            this.projectileTextureSouthWest = null;
            hitMonster = Mediator.Game.Content.Load<SoundEffect>("Sounds/Hit");
            this.shoot = Mediator.Game.Content.Load<SoundEffect>("Sounds/Wand");
        }
    }
}
