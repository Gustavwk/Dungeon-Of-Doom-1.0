using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Game2.Structures;
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
        protected bool stuck;
        protected Vector2 previousPosition;
        protected int bounceBack = 3;
        protected SoundEffect dead;
        protected Wall stuckWall;
        

        public Monster(int x, int y, Mediator mediator) : base(mediator, x, y)
        {
            this.hitbox = new Rectangle(X, Y, WIDTH, HEIGHT);

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
            Debug.WriteLine(stuck);
            this.prevX = this.X;
            this.prevY = this.Y;

            if (health <= 0)
            {
                alive = false;
                dead.Play();

            }

            if (!alive)
            {
                Die();
            }
          

            
            move();



        }

        private void Die()
        {
            mediator.player.Kills++;
            mediator.room.EnemyCount--;
            mediator.gameOverMenu.PlayerKills = mediator.player.Kills;
            mediator.itemToBeDeleted.Add(this);
        }

        public override bool intersects(GameObject other)
        {
            if (other is Player.Player)
            {
                mediator.player.health = mediator.player.health - 1;
                mediator.player.OverallDamgeTaken = mediator.player.OverallDamgeTaken + 1;


                return true;
            }



            if (other is Wall || other is Creep.Creep && other != this)
            {
            
                this.X = prevX;
                this.Y = prevY;
             
                return true;

            }

            return false;
        }

        public virtual void move()


        {
            this.hitbox.X = X;
            this.hitbox.Y = Y;

            if (this.X < mediator.player.getX())
            {


                this.direction = Direction.EAST;
                this.X = this.X + this.movementspeed;


            }

            if (this.Y < mediator.player.getY())
            {


                this.direction = Direction.SOUTH;
                this.Y = this.Y + this.movementspeed;
            }

            if (this.X > mediator.player.getX())
            {



                this.direction = Direction.WEST;
                this.X = this.X - this.movementspeed;
            }

            if (this.Y > mediator.player.getY())
            {




                this.direction = Direction.NORTH;
                this.Y = this.Y - this.movementspeed;
            }
        


    }

       
    }
}
