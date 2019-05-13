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
    class CrossbowProjectile : Projectile
    {

        public CrossbowProjectile(int x, int y, Direction direction, Mediator mediator) : base(x, y, direction,
            mediator)
        {
            this.damage = 50;
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

        

    }
}
