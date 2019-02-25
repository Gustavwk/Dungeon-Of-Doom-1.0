using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            this.east = false;
            this.west = false;
            this.south = false;
        }
        public void setDirectionEast()
        {
            this.south = false;
            this.north = false;
            this.east = true;
            this.west = false;

        }
        public void setDirectionWest()
        {
            this.east = false;
            this.west = true;
            this.south = false;
            this.north = true;

        }
        public void setDirectionSouth()
        {
            this.south = true;
            this.west = false;
            this.east = false;
            this.north = false;
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
                this.posX = this.posX + this.MoveSpeed;
            }

            if (key.IsKeyDown(Keys.A))
            {
                setDirectionWest();
                this.posX = this.posX - this.MoveSpeed;
            }

            if (key.IsKeyDown(Keys.S))
            {
                setDirectionSouth();
                this.posY = this.posY + this.MoveSpeed;
            }

            if (key.IsKeyDown(Keys.W))
            {
                setDirectionNorth();
                this.posY = this.posY - this.MoveSpeed;
            }
        }

        public override void Update(GameTime gameTime)
        {
            movement();
        }


        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(playerPicture ,new Rectangle(this.posX,this.posY, 32, 32), Color.White);
        }
    }
}
