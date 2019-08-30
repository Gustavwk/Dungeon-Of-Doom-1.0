﻿using System;
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
    class BossGhost : Monster
    {
        private Texture2D undamgedRight;
        private Texture2D undamgedLeft;
        private Texture2D damgedRight;
        private Texture2D damgedLeft;
        private Texture2D damgedBack;
        private Texture2D undamgedBack;
        
        private Direction direction;

        public BossGhost(int x, int y, Mediator mediator) : base( x, y, mediator)
        {
            this.hitbox = new Rectangle(this.X, this.Y, 64, 64);
            this.priority = 10;
            this.health = 250;
            this.WIDTH = 24;
            this.HEIGHT = 24;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            DrawAccordingToStats(spriteBatch);
        }

        private void DrawAccordingToStats(SpriteBatch spriteBatch)
        {
            if (this.Health > 50)
            {
                if (this.direction == Direction.EAST)
                {
                    spriteBatch.Draw(undamgedRight, hitbox, Color.White);
                }

                if (this.direction == Direction.NORTH)
                {
                    spriteBatch.Draw(undamgedBack, hitbox, Color.White);
                }

                if (this.direction == Direction.WEST)
                {
                    spriteBatch.Draw(undamgedLeft, hitbox, Color.White);
                }

                if (this.direction == Direction.SOUTH)
                {
                    spriteBatch.Draw(undamgedRight, hitbox, Color.White);
                }
            }
            else
            {
                if (this.direction == Direction.EAST)
                {
                    spriteBatch.Draw(damgedRight, hitbox, Color.White);
                }

                if (this.direction == Direction.NORTH)
                {
                    spriteBatch.Draw(damgedBack, hitbox, Color.White);
                }

                if (this.direction == Direction.WEST)
                {
                    spriteBatch.Draw(damgedLeft, hitbox, Color.White);
                }

                if (this.direction == Direction.SOUTH)
                {
                    spriteBatch.Draw(damgedLeft, hitbox, Color.White);
                }
            }
        }

        public override void Load()
        {
            this.damgedLeft = Mediator.Game.Content.Load<Texture2D>("Creeps/Boss Ghost/boss ghost damaged");
            this.damgedRight = Mediator.Game.Content.Load<Texture2D>("Creeps/Boss Ghost/boss ghost damaged flipped");
            this.damgedBack = Mediator.Game.Content.Load<Texture2D>("Creeps/Boss Ghost/boss ghost back damaged");
            this.undamgedLeft = Mediator.Game.Content.Load<Texture2D>("Creeps/Boss Ghost/boss ghost");
            this.undamgedRight = Mediator.Game.Content.Load<Texture2D>("Creeps/Boss Ghost/boss ghost reversed");
            this.undamgedBack = Mediator.Game.Content.Load<Texture2D>("Creeps/Boss Ghost/boss ghost back");

            dead = Mediator.Game.Content.Load<SoundEffect>("Sounds/MonsterDead");
        }
       
        public override void moveTo(Player.Player player)
        {
            this.hitbox.X = X;
            this.hitbox.Y = Y;

            if (this.X < player.getX())
            {
                this.prevX = this.X;
                this.direction = Direction.EAST;
                this.X = this.X + this.movementspeed;
            }

            if (this.Y <player.getY())
            {
                this.prevY = this.Y;
                this.direction = Direction.SOUTH;
                this.Y = this.Y + this.movementspeed;
            }

            if (this.X > player.getX())
            {
                this.prevX = this.X;
                this.direction = Direction.WEST;
                this.X = this.X - this.movementspeed;
            }

            if (this.Y > player.getY())
            {
                this.prevY = this.Y;
                this.direction = Direction.NORTH;
                this.Y = this.Y - this.movementspeed;
            }
        }

        public override bool Collision(GameObject other)
        {
            if (other is Player.Player)
            {
                mediator.player.health = mediator.player.health - 2;
                mediator.player.OverallDamgeTaken = mediator.player.OverallDamgeTaken + 2;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
