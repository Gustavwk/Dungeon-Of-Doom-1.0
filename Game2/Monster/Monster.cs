using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Game2.Creeps
{
     abstract class Monster : GameObject
    {
       
        protected int movementspeed = 1;
        protected int health = 100;
        protected Boolean alive = true;
        protected int prevX;
        protected int prevY;
        protected Direction direction;
        protected bool shouldDraw = true;
        protected bool stuckInWall;
        protected Vector2 previousPosition;
        protected int bounceBack = 4;
        protected SoundEffect dead;
        

        public Monster(int x, int y, Mediator mediator) : base(mediator, x, y)
        {
            
        }

        public override void Load()
        {
            dead = Mediator.Game.Content.Load<SoundEffect>("Sounds/MonsterDead");
        }

        public void setX(int x)
        {
            this.X = x;
        }
        public void setY(int y)
        {
            this.Y = y;
        }

        public int Health
        {
            get => health;
            set => health = value;
        }
        public override void Update(GameTime gameTime)
        {
            if (health <= 0)
            {
                alive = false;
                //dead.Play(); //Virker ikke pt.

            }

            if (!alive)
            {
                mediator.player.Kills++;
                mediator.room.EnemyCount--;
                mediator.itemToBeDeleted.Add(this);
                
                
            }
            else
            {
                this.hitbox = new Rectangle(this.X, this.Y, WIDTH, HEIGHT);
            }

            this.previousPosition.X = prevX;
            this.previousPosition.Y = prevY;
            move();



        }
        public virtual void move()


        {

            if (!stuckInWall)
            {

                if (this.X < mediator.player.getX())
                {
                    this.prevX = this.X;

                    this.direction = Direction.EAST;
                    this.X = this.X + this.movementspeed;
                }

                if (this.Y < mediator.player.getY())
                {
                    this.prevY = this.Y;

                    this.direction = Direction.SOUTH;
                    this.Y = this.Y + this.movementspeed;
                }

                if (this.X > mediator.player.getX())
                {


                    this.prevX = this.X;

                    this.direction = Direction.WEST;
                    this.X = this.X - this.movementspeed;
                }

                if (this.Y > mediator.player.getY())
                {


                    this.prevY = this.Y;

                    this.direction = Direction.NORTH;
                    this.Y = this.Y - this.movementspeed;
                }

            }
            else
            {
                if (prevX < this.X)
                {
                    this.X = this.X - bounceBack;
                    stuckInWall = false;

                }

                if (prevX > this.X)
                {
                    this.X = this.X + bounceBack;
                    stuckInWall = false;
                }

                if (prevY < this.Y)
                {
                    this.Y = this.Y - bounceBack;
                    stuckInWall = false;
                }

                if (prevY > this.Y)
                {
                    this.Y = this.Y + bounceBack;
                    stuckInWall = false;
                }


            }
        }
    }
}
