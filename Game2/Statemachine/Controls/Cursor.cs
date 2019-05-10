using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2.Menus.Controls
{
    class Cursor : GameObject
    {
        protected MouseState currentMouseState;
        protected MouseState prevMouse;
        private Texture2D mouseSprite;
        public Cursor()
        {
            this.priority = 5;
        }

        

        public override void Update(GameTime gameTime)
        {
            prevMouse = currentMouseState;
            currentMouseState = Mouse.GetState();
            Rectangle mouseRect = new Rectangle(currentMouseState.X, currentMouseState.Y, WIDTH, HEIGHT);
            this.hitbox = mouseRect;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
           spriteBatch.Draw(mouseSprite, hitbox, Color.White);
        }

        public override void Load()
        {
            mouseSprite = Mediator.Game.Content.Load<Texture2D>("Projectiles/WandProjectile/magic_dart_0");
        }
        
    }
}
