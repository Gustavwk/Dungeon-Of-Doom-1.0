using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Threading;
using Game2.gameLogic;
using Game2.Structures;
using Game2.Player;
namespace Game2.Creep
{
    class Creep : GameObject
    {
        private Texture2D creepPicture;
        private int movementspeed = 1;
        public int health = 100;
        private Boolean alive = true;
        private int prevX;
        private int prevY;
        private Direction direction;
        private bool shouldDraw = true;
        private bool stuckInWall;
        private Vector2 previousPosition;
        private int bounceBack = 4;
        


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

        public Creep(int x, int y, Mediator mediator) : base(mediator,x,y)
        {
            this.hitbox = new Rectangle(this.X, this.Y, WIDTH, HEIGHT);
            this.priority = 5;
        }


        public override bool intersects(GameObject other)
        {
            if (other is Player.Player)
            {
                mediator.player.health = mediator.player.health - 1;
                Debug.WriteLine("player health " + mediator.player.health);
                return true;
            }

           

            if (other is Wall)
            {
                stuckInWall = true;
                return true;
                
            }

            return false;
        }

        public override void Load()
        {
        
            creepPicture = Mediator.Game.Content.Load<Texture2D>("Creeps/big_kobold_new");
        }

        public override void Update(GameTime gameTime)
        {
            if (health <= 0)
            {
                alive = false;
               
                
            }

            if (!alive)
            {
                
                mediator.itemToBeDeleted.Add(this);
                mediator.room.EnemyCount--;
            }
            else
            {
                this.hitbox = new Rectangle(this.X, this.Y, WIDTH, HEIGHT);
            }

            this.previousPosition.X = prevX;
            this.previousPosition.Y = prevY;
            move();

                

        }

        public void move()
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
        


        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {


            if (shouldDraw)
            {
                spriteBatch.Draw(creepPicture, hitbox, Color.White);
            }

           


        }






    }

}
