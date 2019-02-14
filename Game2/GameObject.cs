using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game2
{
    class GameObject
    {
        public virtual void Update(GameTime gameTime)
        {
          // skal overskrives for de enkelte objekter .
        }

        public virtual void Draw(GameTime gameTime)
        {
            // skal også overskrives fra de enkelt objekter.
        }

    }
}
