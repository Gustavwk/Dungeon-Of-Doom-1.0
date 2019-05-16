using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Game2.Creeps
{
    class Fiend : Monster
    {
        private Texture2D spriteLeft;
        private Texture2D spriteRight;
        private Texture2D spriteBack;

        public Fiend(int x, int y, Mediator mediator) : base(x, y, mediator)
        {
            this.Health = 30;
            this.movementspeed = 2;
        }

        public override void Load()
        {
            this.spriteLeft = Mediator.Game.Content.Load<Texture2D>("Creeps/Fiend/Fiend left");
            this.spriteRight = Mediator.Game.Content.Load<Texture2D>("Creeps/Fiend/Fiend Right");
            this.spriteBack = Mediator.Game.Content.Load<Texture2D>("Creeps/Fiend/Fiend back");
            this.dead = Mediator.Game.Content.Load<SoundEffect>("Sounds/CreepDead");
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            base.Draw(spriteBatch, gameTime);
            DrawAccordingToStats(spriteBatch);
        }

        public override bool intersects(GameObject other)
        {
            if (other is Player.Player)
            {
                mediator.player.health--;
                return true;
            }

            return false;
        }

        public override void moveTo(Player.Player @where)
        {
            this.hitbox.X = X;
            this.hitbox.Y = Y;

            if (this.X < @where.getX())
            {
                this.prevX = this.X;

                this.direction = Direction.EAST;
                this.X = this.X + this.movementspeed;

            }

            if (this.Y < @where.getY())
            {
                this.prevY = this.Y;

                this.direction = Direction.SOUTH;
                this.Y = this.Y + this.movementspeed;
            }

            if (this.X > @where.getX())
            {


                this.prevX = this.X;

                this.direction = Direction.WEST;
                this.X = this.X - this.movementspeed;
            }

            if (this.Y > @where.getY())
            {


                this.prevY = this.Y;

                this.direction = Direction.NORTH;
                this.Y = this.Y - this.movementspeed;
            }
        }

        private void DrawAccordingToStats(SpriteBatch spriteBatch)
        {

            {
                if (this.direction == Direction.EAST)
                {
                    spriteBatch.Draw(spriteRight, hitbox, Color.White);
                }

                if (this.direction == Direction.NORTH)
                {
                    spriteBatch.Draw(spriteBack, hitbox, Color.White);
                }

                if (this.direction == Direction.WEST)
                {
                    spriteBatch.Draw(spriteLeft, hitbox, Color.White);
                }

                if (this.direction == Direction.SOUTH)
                {
                    spriteBatch.Draw(spriteLeft, hitbox, Color.White);
                }
            }

        }
    }
}
