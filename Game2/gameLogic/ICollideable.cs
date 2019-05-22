using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.gameLogic
{
    interface ICollideable
    {
        bool Collision(GameObject other);
    }
}
