using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2.Menus.Controls
{
    class GameOverMenu : StateHolder
    {
        private SpriteFont spriteFont;
        private Color textColor = Color.LightYellow;

        public GameOverMenu(int x, int y, Mediator mediator, GameTime gameTime) : base(x, y, mediator, gameTime)
        {
            MenuBackground();
        }

        public void stats()
        {
        }
    }
}
