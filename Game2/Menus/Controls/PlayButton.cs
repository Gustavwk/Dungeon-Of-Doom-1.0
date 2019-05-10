using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Game2.Menus.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game2.Menus.Controls
{
    class PlayButton : Button
    {
        public PlayButton(int X, int Y, Mediator mediator, string buttonString) : base(X, Y, mediator, buttonString)
        {
        }

        public override void Update(GameTime gameTime)
        {
            prevMouse = currentMouseState;
            currentMouseState = Mouse.GetState();
            Rectangle mouseRect = new Rectangle(currentMouseState.X, currentMouseState.Y, 1, 1);

            isHovered = false;
            

            if (mouseRect.Intersects(this.hitbox))
            {
                isHovered = true;
                if (currentMouseState.LeftButton == ButtonState.Released && prevMouse.LeftButton == ButtonState.Pressed)
                {
                    this.mediator.State.State = GameState.PLAY;
                }
            }
        }
    }
}
