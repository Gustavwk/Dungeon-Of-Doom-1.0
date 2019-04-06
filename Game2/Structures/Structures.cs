using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2.Structures
{
    abstract class Structures : GameObject
    {
        protected Room room;
        protected int unit = 32;
        protected int x;                                             //Resolution x-akse
        protected int y;

        protected Structures()
        {
            
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

        }

        public override void Load()
        {

        }

        public override void Update(GameTime gameTime)
        {

        }

        public void setRoom(Room room)
        {
            //this.room = room;
        }

        protected Structures(Mediator mediator, int x, int y) : base(mediator,x,y)
        {
        }
    }
}



