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
 
        public float projectileDelay = 20; // delay variable for the projectiles
        protected Texture2D defaultSprite;
        bool visible; // is the projectile visible
        int shootSpeed = 3; //the speed the projectile moves
        int HEIGHT = 32;
        int WIDTH = 32;
        private Texture2D projectileTexture;
        // should a list of our projectiles be here, or in our GameObjects super class??? 

        public Projectiles(int x, int y, Texture2D projectileTexture) {

            
            this.X = x;
            this.Y = y;
            this.hitbox = new Rectangle(this.X, this.Y, WIDTH, HEIGHT);

            //visible = false; 
            
        }

        // method for future collision for our projectiles
        public virtual void intersects(GameObject gameObjectOne, GameObject gameObjectTwo)
        {

        }

        //what should be updated
        public virtual void Update(GameTime gameTime)
        {
            moveProjectiles();
            this.hitbox = new Rectangle(this.X, this.Y, WIDTH, HEIGHT);
        }

        // what should be drawed
        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(defaultSprite, hitbox, Color.White);
            drawHitbox();
         
        }

        //loading our projectile image
        public virtual void Load()
        {
            defaultSprite = GameHolder.Game.Content.Load<Texture2D>("Projectiles/DefaultProjectiles/1_HeroShotgunBulletFrames (1)");
        }

        // creating a new rectangle for our projectile hitbox 
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(this.X, this.Y, defaultSprite.Width, defaultSprite.Height);

            }
        }

        // draws the hitbox of the projectile

        public void drawHitbox(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Texture2D texture = new Texture2D(defaultSprite.GraphicsDevice, 1, 1);
            texture.SetData(new Color[] { Color.Aqua });
            spriteBatch.Draw(texture, hitbox, Color.White);
            spriteBatch.Draw(projectileTexture,hitbox, Color.White);
        }

        //intersecting with a wall method, dont know if this should be here
        public virtual void intersectsWithWall(GameObject player, GameObject wall)
        {

        }

        // im sure the move Projectiles method should be in the player class

        public void moveProjectiles()
        {

            
                KeyboardState key = Keyboard.GetState();

            // we need a position for our projectile, so that we can move our projectile in a direction, if our delay method allows it.
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
        
           /* if (key.IsKeyDown(Keys.Up))
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
            }*/

    


        }


    }


}

