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
    class Projectile : GameObject
    {
 
       
        protected Texture2D projectileTextureLeft;
        protected Texture2D projectileTextureUp;
        protected Texture2D projectileTextureRight;
        protected Texture2D projectileTextureDown;
        


        bool visible; // is the projectile visible
        int shootSpeed = 3; //the speed the projectile moves
        int HEIGHT = 32;
        int WIDTH = 32;
        
        // should a list of our projectiles be here, or in our GameObjects super class??? 

        public Projectile(int x, int y, KeyboardState key ) {

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
            this.hitbox = new Rectangle(this.X, this.Y, WIDTH, HEIGHT);

        }

        // what should be drawed
        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
           
            
            
         
        }

        //loading our projectile image
        public virtual void Load()
        {
            projectileTextureLeft = GameHolder.Game.Content.Load<Texture2D>("Projectile/DefaultProjectiles/poison_arrow_6");
            projectileTextureRight = GameHolder.Game.Content.Load<Texture2D>("Projectile/DefaultProjectiles/poison_arrow_2");
            projectileTextureUp = GameHolder.Game.Content.Load<Texture2D>("Projectile/DefaultProjectiles/poison_arrow_0");
            projectileTextureDown = GameHolder.Game.Content.Load<Texture2D>("Projectile/DefaultProjectiles/poison_arrow_4");
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

        

            // denne metode kloner projectiler, da sprites er en refereance, derfor skal vi klone før vi bruger objektet, eller kan vi ikke skyde.
            // jeg kan bare ikke lige gennemskue hvordan vi skal implementerer denne metode så vi kan bruge den i vores program.
            // I need help :-)

        /*public bool addProjectile()
        {
            var projectile = projectile.clone;
            return true;
        }*/




       
       

    }
    

}

