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
    class Player : GameObject
    {

        private Texture2D playerPicture;
        private int posX;
        private int posY;
        private int MoveSpeed;
        private int WIDTH, HEIGHT;
        private int health;


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

        public void movement()
        {
            KeyboardState key = Keyboard.GetState();

            if (key.IsKeyDown(Keys.D))
                this.posX = this.posX + this.MoveSpeed;

            if (key.IsKeyDown(Keys.A))
                this.posX = this.posX - this.MoveSpeed;

            if (key.IsKeyDown(Keys.S))
                this.posY = this.posY + this.MoveSpeed;

            if (key.IsKeyDown(Keys.W))
                this.posY = this.posY - this.MoveSpeed;
        }

        public override void Update(GameTime gameTime)
        {
            movement();
        }


        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(playerPicture ,new Rectangle(this.posX,this.posY, 50, 50), Color.White);
        }
    }
}
