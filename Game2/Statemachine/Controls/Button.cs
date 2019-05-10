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
using Game2.Menus.States;


class Button : GameObject
    {
        protected MouseState currentMouseState;
        protected SpriteFont font;
        protected bool isHovered;
        protected MouseState prevMouse;
        protected Texture2D buttonTexture;
        protected Texture2D buttonTextureHovered;
        protected event EventHandler click;
        protected bool clicked { get; set; }
        protected Color fontColor = Color.Red;
        protected Vector2 pos { get; set; }
        protected int ButtonHeight = 124;
        protected int ButtonWidth = 124;
        protected string buttonString;
        protected int stringPosX;
        protected int stringPosY;


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
            
        }

      

        public override void Load()
        {
            buttonTexture = Mediator.Game.Content.Load<Texture2D> ("Menus/Buttons/Button");
            buttonTextureHovered = Mediator.Game.Content.Load<Texture2D>("Menus/Buttons/ButtonHowered");
            font = Mediator.Game.Content.Load<SpriteFont>("Menus/menusFont/File");
        }
    }

