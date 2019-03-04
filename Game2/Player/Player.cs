using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game2.Structures;

namespace Game2.Player
{
    class Player : GameObject
    {
        


        private Texture2D playerPicture;
        private int posX;
        private int posY;
        private int MoveSpeed;
        private int WIDTH, HEIGHT;
        private int health;
        public Rectangle  hitbox;
        private Boolean alive = true;
        private int prevPositionX;
        private int prevPositionY;


        private Boolean north = false;
        private Boolean south = false;
        private Boolean east = false;
        private Boolean west = false;
       
        /*
         * Nedenstående er setters der afgører hvilken retning spilelren går, de bliver brugt i movement.
         */

        public void setDirectionNorth()
        {
            this.north = true;
            this.south = false;
            this.east = false;
            this.west = false;
            this.prevPositionX = this.posX;
            this.prevPositionY = this.posY;

            this.posY = this.posY - this.MoveSpeed;
            

        }
        public void setDirectionEast()
        {
            this.south = false;
            this.north = false;
            this.east = true;
            this.west = false;
            this.prevPositionX = this.posX;
            this.prevPositionY = this.posY;
            this.posX = this.posX + this.MoveSpeed;

        }
        public void setDirectionWest()
        {
            this.east = false;
            this.west = true;
            this.south = false;
            this.north = true;
            this.prevPositionX = this.posX;
            this.prevPositionY = this.posY;
            this.posX = this.posX - this.MoveSpeed;

        }
        public void setDirectionSouth()
        {
            this.south = true;
            this.west = false;
            this.east = false;
            this.north = false;
            this.prevPositionX = this.posX;
            this.prevPositionY = this.posY;
            this.posY = this.posY + this.MoveSpeed;
           
        }


        public Player(int posX, int posY)
        {
            health = 100;
            HEIGHT = 32;
            WIDTH = 32;
            MoveSpeed = 2;
            this.posX = posX;
            this.posY = posY;
           
        }

        public override void intersectsWithWall(GameObject player, GameObject wall)
        {

            this.posY = prevPositionY;
            this.posX = prevPositionX;
            Debug.WriteLine("Player Intersects");
            Debug.WriteLine("X: " + this.posX);
            Debug.WriteLine("Y: " + this.posY);



            if (player.hitbox.Left <= wall.hitbox.Right)
            {

               

                //this.posX = posX + 2;
            }
          if (player.hitbox.Top > wall.hitbox.Bottom && player.hitbox.Top < wall.hitbox.Top)
            {
                //Debug.WriteLine("NORTH");
                //this.posY = posY + 2;
            }
            if  (player.hitbox.Right > wall.hitbox.Left && player.hitbox.Right < wall.hitbox.Right)
            {
                //Debug.WriteLine("EAST");
               // this.posX = posX -2;
            }
            if (player.hitbox.Bottom > wall.hitbox.Top && player.hitbox.Bottom < wall.hitbox.Bottom)
            {
                // Debug.WriteLine("SOUTH");
                //this.posY = posY - 2;
            }
            
            base.intersectsWithWall(player, wall);

        }

        public override void Load()
        {
            playerPicture = GameHolder.Game.Content.Load<Texture2D>("player/bloody");
        }

        public Boolean isDead(Boolean alive)
        {
            if (health >= 0)
            {
                this.alive = false;
            }

            return this.alive;
        }

        public void movement()
        {
            KeyboardState key = Keyboard.GetState();
            /*
             * "else if" istedet for "if" det gør det meget nemmere at bruge prevPosition
             * på vores player og gør derved collision nemmere - det føles
             * tilgengæld fucking mærkeligt at bevæge sig. 
             */

            if (key.IsKeyDown(Keys.D))
            {
                setDirectionEast();
               
            }

           else if (key.IsKeyDown(Keys.A))
            {
                setDirectionWest();
                
            }

           else if (key.IsKeyDown(Keys.S))
            {
                setDirectionSouth();
              
            }

           else if (key.IsKeyDown(Keys.W))
            {
                setDirectionNorth();
               
                
            }
        }

        public override void Update(GameTime gameTime)
        {
            movement();
            this.hitbox = new Rectangle(this.posX, this.posY, WIDTH, HEIGHT);
           


           
           
         
        }


        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //Nedenstående tegner en hitbox
            
            Texture2D texture = new Texture2D(spriteBatch.GraphicsDevice,1,1);
            texture.SetData(new Color[]{Color.Aqua});
            spriteBatch.Draw(texture, hitbox, Color.White);
            
            spriteBatch.Draw(playerPicture, hitbox, Color.White);
        }

    }
}
