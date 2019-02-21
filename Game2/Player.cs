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
        private MyPlayer MyPlayer;
        private int MoveSpeed;
        private int WIDTH, HEIGHT; 
        

        public Player( int posX, int posY)
        {
            HEIGHT = 50; // Jeg kan ikke helt forså hvorfor disse er difineret i vores constructer. Jeg synes umiddelbart de skal skal når man laver player objektet. 
            WIDTH = 20;
            MoveSpeed = 2;
            this.posX = posX; //Jeg har laver posx/y og players texture om så de defineres når man skaber objektet. 
            this.posY = posY;
        }

        public override void Load() //jeg har prøvet at override Load men jeg får stadig en nullpointer når jeg prøver at køre det. 
        {
            playerPicture = GameHolder.Game.Content.Load<Texture2D>("player/bloody");
        }

       
        public override void Update(GameTime gameTime) // Det her kan ikke compiles for mig. 
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


        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(playerPicture ,new Rectangle(this.posX,this.posY, 50, 50), Color.White);
        }

        /*private class Keyboard
        {
            internal static object GetState()
            {
                throw new NotImplementedException();
            }
        }*/
    }
}
