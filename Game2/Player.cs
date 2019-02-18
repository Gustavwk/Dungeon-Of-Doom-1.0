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
        private MyPlaywwer MyPlayer;
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
            Player.add(new Player());
        }


        public void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.d))
                Player.posx = Player.posx + Player.MoveSpeed;

            if (Keyboard.GetState().IsKeyDown(Keys.a))
                Player.posx = Player.posx - Player.MoveSpeed;

            if (Keyboard.GetState().IsKeyDown(Keys.s))
                Player.posy = Player.posy - Player.MoveSpeed;

            if (Keyboard.GetState().IsKeyDown(Keys.w))
                Player.posx = Player.posx + Player.MoveSpeed;
        }


        public override void Draw(GameTime gameTime)
        {
            position = new Rectangle(x, y, HEIGHT, WIDTH);
            spriteBatch.Draw(Player, position, Color.White);
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
