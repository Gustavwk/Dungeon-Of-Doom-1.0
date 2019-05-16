using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Threading;
using Game2.Creeps;
using Game2.gameLogic;
using Game2.Structures;
using Game2.Player;
using Microsoft.Xna.Framework.Audio;
namespace Game2.Creep
{
    class Creep : Monster
    {
        private Texture2D creepPictureRight;
        private Texture2D creepPictureLeft;
        private Texture2D creepPictureBack;


        public Creep(int x, int y, Mediator mediator) : base(x,y, mediator)
        {
            this.priority = 6;

            
        }


        

        public override void Load()
        {
            creepPictureRight = Mediator.Game.Content.Load<Texture2D>("Creeps/big_kobold_new");
            creepPictureLeft = Mediator.Game.Content.Load<Texture2D>("Creeps/big_kobold_new");
            creepPictureBack = Mediator.Game.Content.Load<Texture2D>("Creeps/big_kobold_new");

            dead = Mediator.Game.Content.Load<SoundEffect>("Sounds/CreepDead");
        }


        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

           DrawAccordingToStats(spriteBatch);
           




        }



        private void DrawAccordingToStats(SpriteBatch spriteBatch)
        {

            {
                if (this.direction == Direction.EAST)
                {
                    spriteBatch.Draw(creepPictureRight, hitbox, Color.White);
                }

                if (this.direction == Direction.NORTH)
                {
                    spriteBatch.Draw(creepPictureBack, hitbox, Color.White);
                }

                if (this.direction == Direction.WEST)
                {
                    spriteBatch.Draw(creepPictureLeft, hitbox, Color.White);
                }

                if (this.direction == Direction.SOUTH)
                {
                    spriteBatch.Draw(creepPictureRight, hitbox, Color.White);
                }
            }

        }


    }

}
