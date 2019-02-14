using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game2
{
    class Wall : GameObject
    {
        public override void Update(GameTime gameTime)
        {
      
            // her er evt logik fr en wall

            // kalder gameobjekts update metode
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
          //  tegn det her"wall" objekt
        }

        
    }
}
