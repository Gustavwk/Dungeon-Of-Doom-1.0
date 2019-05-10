using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Game2.Statemachine
{
    class TextField : GameObject
    {
        private SpriteFont font;
        private String text;
        private Color textColor;

        public TextField(int x, int y, Mediator mediator, String text, Color color)
        {
            this.X = x;
            this.Y = y;
            this.mediator = mediator;
            this.text = text;
            this.textColor = color;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.DrawString(font, text, new Vector2(X, Y), textColor);
        }

        public override void Load()
        {
            font = Mediator.Game.Content.Load<SpriteFont>("Menus/menusFont/File");
        }
    }
}
