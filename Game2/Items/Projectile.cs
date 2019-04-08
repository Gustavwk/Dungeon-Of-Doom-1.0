using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
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
        private Player.Player player;
        private Direction direction;

       

        bool visible; // is the projectile visible
        int shootSpeed = 3; //the speed the projectile moves

        const int HEIGHT = 32;
        const int WIDTH = 32;

       

        public Projectile(int x, int y, String direction, Mediator mediator, Player.Player player) : base(mediator, x, y)
        {
            this.hitbox = new Rectangle(this.X, this.Y, WIDTH, HEIGHT);
            this.player = player;

            if (direction == "NORTH")
            {
                this.direction = Direction.NORTH;
            }
            else if (direction == "SOUTH")
            {
                this.direction = Direction.SOUTH;
            }
            else if (direction == "WEST")
            {
                this.direction = Direction.WEST;
            }
            else if (direction == "EAST")
            {
                this.direction = Direction.EAST;
            }

        }

        
        public override void intersects(GameObject otherObject)
        {
            Debug.WriteLine("Projectile impacts");
        }

        
        public override void Update(GameTime gameTime)
        {
            if (direction == Direction.NORTH)
            {
                this.Y = Y--;

            } else if (direction == Direction.SOUTH)
            {
                this.Y = Y++;
            }
            else if (direction == Direction.EAST)
            {
                this.X = X++;
            }
            else if (direction == Direction.WEST)
            {
                this.X = X--;
            }



            this.hitbox = new Rectangle(this.X, this.Y, WIDTH, HEIGHT);
        }

        
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (this.player.GetDirection() == "NORTH")
            {
                spriteBatch.Draw(projectileTextureUp,hitbox,Color.White);
            }
            else if (this.player.GetDirection() == "SOUTH")
            {
                spriteBatch.Draw(projectileTextureDown, hitbox, Color.White);
            }
            else if(this.player.GetDirection() == "EAST")
            {
                spriteBatch.Draw(projectileTextureRight, hitbox, Color.White);
            }
            else if (this.player.GetDirection() == "WEST")
            {
                spriteBatch.Draw(projectileTextureLeft, hitbox, Color.White);
            }


            
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

        //intersecting with a wall method, dont know if this should be here
        public virtual void intersectsWithWall(GameObject player, GameObject wall)
        {
        }
    }
}