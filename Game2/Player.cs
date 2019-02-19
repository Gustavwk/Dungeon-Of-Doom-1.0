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
        private SpriteBatch spriteBatch;
        private Texture2D playerPicture;
        private int posX;
        private int posY;
        private MyPlayer MyPlayer;
        private int MoveSpeed;
        private int WIDTH, HEIGHT; 


        public Player(Texture2D playerPicture, int posX, int posY)
        {
            HEIGHT = 50; // Jeg kan ikke helt forså hvorfor disse er difineret i vores constructer. Jeg synes umiddelbart de skal skal når man laver player objektet. 
            WIDTH = 20;
            MoveSpeed = 2;
            this.posX = posX; //Jeg har laver posx/y og players texture om så de defineres når man skaber objektet. 
            this.posY = posY;
            this.playerPicture = playerPicture; 
        }



        public Player ( Texture2D) // Jeg forstår ikke hvad det her er ? - Det virker som om at du vil tilføje player til en liste med et Texture2D parameter. Dette skal gøres i main, hvis det altså du altså vil tilføje Player til allObjects 
        {
            Player.add(new Player());
        }


        public override void Update(GameTime gameTime) // Det her kan ikke compiles for mig. 
        {
            if (Keyboard.GetState().IsKeyDown(Keys.d))
                Player.posX = Player.posx + Player.MoveSpeed;

            if (Keyboard.GetState().IsKeyDown(Keys.a))
                Player.posx = Player.posx - Player.MoveSpeed;

            if (Keyboard.GetState().IsKeyDown(Keys.s))
                Player.posy = Player.posy - Player.MoveSpeed;

            if (Keyboard.GetState().IsKeyDown(Keys.w))
                Player.posx = Player.posx + Player.MoveSpeed;
        }


        public override void Draw(GameTime gameTime)
        {
            Rectangle position = new Rectangle(posX, posY, HEIGHT, WIDTH);
            spriteBatch.Draw(playerPicture, position, Color.White);
        }

        private class Keyboard
        {
            internal static object GetState()
            {
                throw new NotImplementedException();
            }
        }
    }
}
