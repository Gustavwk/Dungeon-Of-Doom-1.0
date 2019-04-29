using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2.gameLogic
{
    interface IDrawable
    {
        void Draw(SpriteBatch spriteBatch, GameTime gameTime);
        void Load();
    }
}
