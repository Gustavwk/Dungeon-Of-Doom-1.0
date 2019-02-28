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
            if (north)
            {
                this.posY = this.posY - this.MoveSpeed;
            }

        }
        public void setDirectionEast()
        {
            this.south = false;
            this.north = false;
            this.east = true;
            this.west = false;
            this.posX = this.posX + this.MoveSpeed;

        }
        public void setDirectionWest()
        {
            this.east = false;
            this.west = true;
            this.south = false;
            this.north = true;
            this.posX = this.posX - this.MoveSpeed;

        }
        public void setDirectionSouth()
        {
            this.south = true;
            this.west = false;
            this.east = false;
            this.north = false;
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
            Debug.WriteLine("Player Intersecs");

            if (player.hitbox.Left == wall.hitbox.Right)
            {

            }
            else if (player.hitbox.Top == wall.hitbox.Bottom)
            {

                setDirectionNorth();

            }
            else if  (player.hitbox.Right == wall.hitbox.Left)
            {

            }
            else if (player.hitbox.Bottom == wall.hitbox.Top)
            {
              
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


            if (key.IsKeyDown(Keys.D))
            {
                setDirectionEast();
               
            }

            if (key.IsKeyDown(Keys.A))
            {
                setDirectionWest();
                
            }

            if (key.IsKeyDown(Keys.S))
            {
                setDirectionSouth();
              
            }

            if (key.IsKeyDown(Keys.W))
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
            /*
            Texture2D texture = new Texture2D(spriteBatch.GraphicsDevice,1,1);
            texture.SetData(new Color[]{Color.Aqua});
            spriteBatch.Draw(texture, hitbox, Color.White);
            */
            spriteBatch.Draw(playerPicture, hitbox, Color.White);
        }

    }
}
