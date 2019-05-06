using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game2;
using Game2.gameLogic;


class Button : GameObject
    {
        private MouseState currentMouseState;
        private SpriteFont font;
        private bool isHovered;
        private MouseState prevMouse;
        private Texture2D buttonTexture;
        private Texture2D buttonTextureHovered;
        private event EventHandler click;
        private bool clicked { get; set; }
        private Color fontColor = Color.Red;
        private Vector2 pos { get; set; }
        protected int ButtonHeight = 124;
        protected int ButtonWidth = 124;
        private string buttonString;
        private int stringPosX;
        private int stringPosY;


    public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)pos.X,(int)pos.Y,buttonTexture.Width,buttonTexture.Height);
            }
        }
        public Button(int X, int Y, Mediator mediator, String buttonString) : base(mediator, X, Y)
        {

            this.hitbox = new Rectangle(this.X, this.Y, ButtonWidth, ButtonHeight);
            this.buttonString = buttonString;
            stringPosX = X + 20;
            stringPosY = Y + 50;
        }



    public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            
            if (isHovered)
            {
                spriteBatch.Draw(buttonTextureHovered, hitbox, Color.White);
                spriteBatch.DrawString(font,  buttonString, new Vector2(stringPosX, stringPosY), fontColor);
        }
            else
            {
                spriteBatch.Draw(buttonTexture, hitbox, Color.White);
                spriteBatch.DrawString(font, buttonString, new Vector2(stringPosX, stringPosY), fontColor);
        }
        }

        public override void Update(GameTime gameTime)
        {
            prevMouse = currentMouseState;
            currentMouseState = Mouse.GetState();
            Rectangle mouseRect = new Rectangle(currentMouseState.X,currentMouseState.Y,1,1);

            isHovered = false;

            if (mouseRect.Intersects(this.hitbox))
            {
                isHovered = true;
                if (currentMouseState.LeftButton == ButtonState.Released && prevMouse.LeftButton == ButtonState.Pressed)
                {
                   Debug.Write("hej");
                }
            }
        }

        public override void Load()
        {
            buttonTexture = Mediator.Game.Content.Load<Texture2D> ("Menus/Buttons/Button");
            buttonTextureHovered = Mediator.Game.Content.Load<Texture2D>("Menus/Buttons/ButtonHowered");
            font = Mediator.Game.Content.Load<SpriteFont>("Menus/menusFont/File");
        }
    }

