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


        Player(int x, int y)
        {
            HEIGHT = 50;
            WIDTH = 20;
            MoveSpeed = 2;
            x = 20;
            y = 10;
        }



        public Player ( Texture2D)
        {
            Player.add(new Player(posX, posY));
        }


        public void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.D))
                Player.posX = Player.posX + Player.MoveSpeed;

            if (Keyboard.GetState().IsKeyDown(Keys.A))
                Player.posX = Player.posX - Player.MoveSpeed;

            if (Keyboard.GetState().IsKeyDown(Keys.S))
                Player.posY = Player.posY - Player.MoveSpeed;

            if (Keyboard.GetState().IsKeyDown(Keys.W))
                Player.posY = Player.posY + Player.MoveSpeed;
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
