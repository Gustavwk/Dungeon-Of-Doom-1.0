using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Game2.Structures;
using Game2.Creep;
using Game2.Creeps;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace Game2
{
    class Projectile : GameObject, IProjectile
    {
        protected Texture2D projectileTextureLeft;
        protected Texture2D projectileTextureUp;
        protected Texture2D projectileTextureRight;
        protected Texture2D projectileTextureDown;
        protected Texture2D projectileTextureNorthEast;
        protected Texture2D projectileTextureNorthWest;
        protected Texture2D projectileTextureSouthEast;
        protected Texture2D projectileTextureSouthWest;

        protected SoundEffect hitMonster;
        protected SoundEffect hitWall;

        protected bool shouldDraw = true;
        protected int damage = 33;

        protected Direction direction;

        public int Damage
        {
            get => damage;
            set => damage = value;
        }

       

        bool visible; // is the projectile visible
        protected int shootSpeed = 8; //the speed the projectile moves

        protected const int HEIGHT = 30;
        protected const int WIDTH = 30;

        protected const int actualHEIGHT = 1;
        protected const int actualWIDTH = 1;



        public Projectile(int x, int y, Direction direction, Mediator mediator) : base(mediator, x, y)
        {
            this.hitbox = new Rectangle(this.X, this.Y, actualWIDTH, actualHEIGHT);
            this.direction = direction;
            this.priority = 4;
            //spawn projectile alt efter direction hvis op, så lidt længere 


        }
        
        public override bool intersects(GameObject other)
        {
            if (other is Monster)
            {
                Monster p = (Monster)other;

                p.Health = p.Health - damage;

                mediator.player.OverallDamegeDone += damage;

                Debug.WriteLine("Monster hp: " + p.Health);
                
                hitMonster.CreateInstance().Play();

                mediator.itemToBeDeleted.Add(this);
               
            }

            if (other is Wall || other is Door)
            {
                hitWall.CreateInstance().Play();

                mediator.itemToBeDeleted.Add(this);
            }
            return true;
        }

        
        public override void Update(GameTime gameTime)
        {
            MoveProjectile();


            this.hitbox = new Rectangle(this.X, this.Y, WIDTH, HEIGHT);
        }

        public void MoveProjectile()
        {
            if (this.direction == Direction.NORTH)
            {
                Y -= shootSpeed;
            }
            else if (this.direction == Direction.SOUTH)
            {
                Y += shootSpeed;
            }
            else if (this.direction == Direction.EAST)
            {
                X += shootSpeed;
            }
            else if (this.direction == Direction.WEST)
            {
                X -= shootSpeed;
            }
        }


        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            DrawAccordingToDirection(spriteBatch);
        }

        public virtual void DrawAccordingToDirection(SpriteBatch spriteBatch)
        {
            if (shouldDraw)
            {
                if (this.direction == Direction.NORTH)
                {
                    spriteBatch.Draw(projectileTextureUp, hitbox, Color.White);
                }
                else if (this.direction == Direction.SOUTH)
                {
                    spriteBatch.Draw(projectileTextureDown, hitbox, Color.White);
                }
                else if (this.direction == Direction.EAST)
                {
                    spriteBatch.Draw(projectileTextureRight, hitbox, Color.White);
                }
                else if (this.direction == Direction.WEST)
                {
                    spriteBatch.Draw(projectileTextureLeft, hitbox, Color.White);
                }
            }
        }

        public void preLoad()
        {
            //skriv noget her som preloader xD
            // preload til variable som man kan hente fra i runtime.
        }

        //loading our projectile image
        public override void Load()
        {
            projectileTextureLeft =
                Mediator.Game.Content.Load<Texture2D>("Projectiles/DefaultProjectiles/poison_arrow_6");
            projectileTextureRight =
                Mediator.Game.Content.Load<Texture2D>("Projectiles/DefaultProjectiles/poison_arrow_2");
            projectileTextureUp =
                Mediator.Game.Content.Load<Texture2D>("Projectiles/DefaultProjectiles/poison_arrow_0");
            projectileTextureDown =
                Mediator.Game.Content.Load<Texture2D>("Projectiles/DefaultProjectiles/poison_arrow_4");

            hitMonster = Mediator.Game.Content.Load<SoundEffect>("Sounds/Hit");
            hitWall = Mediator.Game.Content.Load<SoundEffect>("Sounds/HitWall");
        }

        // creating a new rectangle for our projectile hitbox 
        public Rectangle Rectangle
        {
            get { return new Rectangle(this.X, this.Y, projectileTextureLeft.Width, projectileTextureLeft.Height); }
        }

        // draws the hitbox of the projectile

        public void drawHitbox(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Texture2D texture = new Texture2D(projectileTextureLeft.GraphicsDevice, 1, 1);
            texture.SetData(new Color[] {Color.Aqua});
            spriteBatch.Draw(texture, hitbox, Color.White);

            spriteBatch.Draw(projectileTextureLeft, hitbox, Color.White);
        }

        
    }
}