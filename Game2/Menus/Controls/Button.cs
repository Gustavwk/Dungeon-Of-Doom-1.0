using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2.Menus.Controls
{
    public class Button : GameObject
    {
        private MouseState currentMouseState;
        private SpriteFont font;
        private bool isHovered;
        private MouseState prevMouse;
        private Texture2D buttonTexture;
        private Texture2D buttonTextureHovered;
        public event EventHandler click;
        public bool clicked { get; set; }
        public Color PenColor { get; set; }
        public Vector2 pos { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)pos.X,(int)pos.Y,buttonTexture.Width,buttonTexture.Height);
            }
        }


        public Button(Texture2D teture, SpriteFont font)
        {
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Load()
        {
            
        }
    }
}
