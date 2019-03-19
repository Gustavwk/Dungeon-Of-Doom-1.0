using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2
{
    class Projectiles : GameObject
    {
        public int X;
        public int Y;
        public float projectileDelay; // delay variable for the projectiles
        protected Texture2D defaultSprite;
        public Rectangle hitbox;
        bool visible; // is the projectile visible
        int shootSpeed; //the speed the projectile moves
        int HEIGHT;
        int WIDTH;
        private Texture2D projectileTexture;

        public Projectiles(int x, int y, Texture2D projectileTexture) {

            
            this.X = x;
            this.Y = y;
            projectileDelay = 20; // set projectile delay to 20
            shootSpeed = 3;
            HEIGHT = 32;
            WIDTH = 32;
            this.hitbox = new Rectangle(this.X, this.Y, WIDTH, HEIGHT);

            //visible = false; 
            
        }
         // constructor

        public Projectiles(Texture2D projectileTexture) 
        {
            this.projectileTexture = projectileTexture;
        }

        public virtual void intersects(GameObject gameObjectOne, GameObject gameObjectTwo)
        {

        }

        public virtual void Update(GameTime gameTime)
        {
            moveProjectiles();
            this.hitbox = new Rectangle(this.X, this.Y, WIDTH, HEIGHT);
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(defaultSprite, hitbox, Color.White);
            drawHitbox();
         
        }

        public virtual void Load()
        {
            defaultSprite = GameHolder.Game.Content.Load<Texture2D>("Projectiles/DefaultProjectiles/1_HeroShotgunBulletFrames (1)");
        }


        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(this.X, this.Y, defaultSprite.Width, defaultSprite.Height);

            }
        }

        public void drawHitbox(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Texture2D texture = new Texture2D(defaultSprite.GraphicsDevice, 1, 1);
            texture.SetData(new Color[] { Color.Aqua });
            spriteBatch.Draw(texture, hitbox, Color.White);
            spriteBatch.Draw(projectileTexture,hitbox, Color.White);
        }

        public virtual void intersectsWithWall(GameObject player, GameObject wall)
        {

        }

        public void moveProjectiles()
        {

            
                KeyboardState key = Keyboard.GetState();
            /*if (projectileDelay >= 0)
            {
                projectileDelay--;
            }

            if (projectileDelay <= 0)
            {
                Projectiles projectiles = new Projectiles(projectileTexture);

            }
            */
            
            // could / should make this method a "SWICH"
        
            if (key.IsKeyDown(Keys.Up))
            {

               Projectiles projectiles = new Projectiles(projectileTexture);
               this.Y = Y --;
            }

            if (key.IsKeyDown(Keys.Left))
            {

               this.X = this.X - this.shootSpeed;
            }

            if (key.IsKeyDown(Keys.Down))
            {

               this.Y = this.Y + this.shootSpeed;
            }

            if (key.IsKeyDown(Keys.Right))
            {

               this.X = this.X + this.shootSpeed;
            }

    


        }


    }


}

