using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        protected Texture2D projectileTextureLeft;
        protected Texture2D projectileTextureUp;
        protected Texture2D projectileTextureRight;
        protected Texture2D projectileTextureDown;
        private bool directionUp;
        private bool directionDown;
        private bool directionLeft;
        private bool directionRight;


        bool visible; // is the projectile visible
        int shootSpeed = 3; //the speed the projectile moves
        int HEIGHT = 32;
        int WIDTH = 32;
        
        // should a list of our projectiles be here, or in our GameObjects super class??? 

        public Projectiles(int x, int y, KeyboardState key ) {
            if (key.IsKeyDown(Keys.Up))
            {
                directionUp = true;
                directionDown = false;
                directionLeft = false;
                directionRight = false;     

            } else if (key.IsKeyDown(Keys.Down))
            {
                directionUp = false;
                directionDown = true;
                directionLeft = false;
                directionRight = false;
            }
            else if (key.IsKeyDown(Keys.Left))
            {
                directionUp = false;
                directionDown = false;
                directionLeft = true;
                directionRight = false;
            }
            else if (key.IsKeyDown(Keys.Right))
            {
                directionUp = false;
                directionDown = false;
                directionLeft = false;
                directionRight = true;
            }

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
            if (directionUp)
            {
                shootUp();

            } else if (directionDown)
            {
                shootDown();
            }
            else if(directionLeft)
            {
                shootLeft();
            }
            else if (directionRight)
            {
                shootRight();
            }

            this.hitbox = new Rectangle(this.X, this.Y, WIDTH, HEIGHT);
          
        }

        // what should be drawed
        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
           
            if (directionUp)
            {
                spriteBatch.Draw(projectileTextureUp, hitbox, Color.White);
                
            }
            else if (directionDown)
            {
                spriteBatch.Draw(projectileTextureDown, hitbox, Color.White);
            }
            else if (directionLeft)
            {
                spriteBatch.Draw(projectileTextureLeft, hitbox, Color.White);
            }
            else if (directionRight)
            {
                spriteBatch.Draw(projectileTextureRight, hitbox, Color.White);
            }
            
         
        }

        //loading our projectile image
        public virtual void Load()
        {
            projectileTextureLeft = GameHolder.Game.Content.Load<Texture2D>("Projectiles/DefaultProjectiles/poison_arrow_6");
            projectileTextureRight = GameHolder.Game.Content.Load<Texture2D>("Projectiles/DefaultProjectiles/poison_arrow_2");
            projectileTextureUp = GameHolder.Game.Content.Load<Texture2D>("Projectiles/DefaultProjectiles/poison_arrow_0");
            projectileTextureDown = GameHolder.Game.Content.Load<Texture2D>("Projectiles/DefaultProjectiles/poison_arrow_4");
        }

        // creating a new rectangle for our projectile hitbox 
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(this.X, this.Y, projectileTextureLeft.Width, projectileTextureLeft.Height);

            }
        }

        // draws the hitbox of the projectile

        public void drawHitbox(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Texture2D texture = new Texture2D(projectileTextureLeft.GraphicsDevice, 1, 1);
            texture.SetData(new Color[] { Color.Aqua });
            spriteBatch.Draw(texture, hitbox, Color.White);

            spriteBatch.Draw(projectileTextureLeft,hitbox, Color.White);
        }

        //intersecting with a wall method, dont know if this should be here
        public virtual void intersectsWithWall(GameObject player, GameObject wall)
        {

        }

        // im sure the move Projectiles method should be in the player class


      

        public bool shootUp()
        {


            this.Y = this.Y - shootSpeed;
            


            return true;
        }
        public bool shootDown()
        {


            this.Y = this.Y + shootSpeed;



            return true;
        }
        public bool shootLeft()
        {


            this.X = this.X - shootSpeed;


            return true;
        }
        public bool shootRight()
        {

            this.X = this.X + shootSpeed;


            return true;
        }

    }


}

