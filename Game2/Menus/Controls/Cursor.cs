using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2.Menus.Controls
{
    class Cursor : GameObject
    {
        private Texture2D mouseSprite;

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Load()
        {
            mouseSprite = Mediator.Game.Content.Load<Texture2D>("Projectiles / WandProjectile / magic_dart_0");
        }
        
    }
}
