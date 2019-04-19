using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game2.gameLogic
{
    interface IPlayer
    {
        void movement();
        void shooting(GameTime gameTime);
    }
}
