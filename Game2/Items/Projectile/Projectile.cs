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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

        protected bool shouldDraw = true;
        private int damage = 5;

        protected Direction direction;

        public int Damage
        {
            get => damage;
            set => damage = value;
        }

       

        bool visible; // is the projectile visible
        int shootSpeed = 8; //the speed the projectile moves

        protected const int HEIGHT = 32;
        protected const int WIDTH = 32;

       

        public Projectile(int x, int y, Direction direction, Mediator mediator) : base(mediator, x, y)
        {
            this.hitbox = new Rectangle(this.X, this.Y, WIDTH, HEIGHT);
            this.direction = direction;
            //spawn projectile alt efter direction hvis op, så lidt længere 


        }


        
        public override void intersects(GameObject other)
        {

            if (other is Wall)
            {
                //Hvis projectil rammer en væg så mister den sin hitbox og bliver ikke tegnet mere!
                shouldDraw = false;
                hitbox = Rectangle.Empty;
            }

            if (other is Creep.Creep)
            {
                Creep.Creep p = (Creep.Creep) other;

                p.health = p.health - damage;
                shouldDraw = false;
            }


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
            else if (this.direction == Direction.NORTHEAST)
            {
                X += shootSpeed;
                Y -= shootSpeed;
            }
            else if (this.direction == Direction.NORTHWEST)
            {
                X -= shootSpeed;
                Y -= shootSpeed;
            }
            else if (this.direction == Direction.SOUTHEAST)
            {
                X += shootSpeed;
                Y += shootSpeed;
            }
            else if (this.direction == Direction.SOUTHWEST)
            {
                X -= shootSpeed;
                Y += shootSpeed;
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
                else if (this.direction == Direction.NORTHEAST)
                {
                    spriteBatch.Draw(projectileTextureNorthEast, hitbox, Color.White);
                }
                else if (this.direction == Direction.NORTHWEST)
                {
                    spriteBatch.Draw(projectileTextureNorthWest, hitbox, Color.White);
                }
                else if (this.direction == Direction.SOUTHEAST)
                {
                    spriteBatch.Draw(projectileTextureSouthEast, hitbox, Color.White);
                }
                else if (this.direction == Direction.SOUTHWEST)
                {
                    spriteBatch.Draw(projectileTextureSouthWest, hitbox, Color.White);
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
            projectileTextureNorthWest =
                Mediator.Game.Content.Load<Texture2D>("Projectiles/DefaultProjectiles/poison_arrow_7");
            projectileTextureNorthEast =
                Mediator.Game.Content.Load<Texture2D>("Projectiles/DefaultProjectiles/poison_arrow_1");
            projectileTextureSouthWest =
                Mediator.Game.Content.Load<Texture2D>("Projectiles/DefaultProjectiles/poison_arrow_5");
            projectileTextureSouthEast =
                Mediator.Game.Content.Load<Texture2D>("Projectiles/DefaultProjectiles/poison_arrow_3");
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