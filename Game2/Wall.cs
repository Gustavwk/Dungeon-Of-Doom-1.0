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
        private int coordinateX;
        private int coordinateY;


        public Wall(int coordinateX, int coordinateY)
        {
            this.coordinateX = coordinateX;
            this.coordinateY = coordinateY;
        }

        public override void Update(GameTime gameTime)
        {
            // her er evt logik for en wall
            // kalder gameobjekts update metode
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
          //  "Wall" skal tegnes her. 
        }

        
    }
}
