﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2
{
    public abstract class Item : GameObject
    {

        public Item(int x, int y, Mediator mediator) :base (mediator,x,y)
        {
            this.priority = 3;
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
    }
}
