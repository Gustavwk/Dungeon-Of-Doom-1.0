using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2
{
    class Room : GameObject
    {
        List<Wall> walls = new List<Wall>();


        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (Wall wall in walls)
            {
                wall.Draw(spriteBatch, gameTime);
            }

        }
    }
}
