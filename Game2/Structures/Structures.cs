﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2.Structures
{
    public abstract class Structures : GameObject
    {
        protected Room room;
        protected int unit = 32;
        protected int x;                                             //Resolution x-akse
        protected int y;

        protected Structures()
        {
            
        }

        protected Structures(Mediator mediator, int x, int y) : base(mediator, x, y)
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
            base.Update(gameTime);
        }
    }
}



