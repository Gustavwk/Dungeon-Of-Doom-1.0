using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.Structures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2
{
    class GameObject
    {
        /*
         * nye variabler for alle gameobjects
         */
        private  Texture2D defaultSprite;
        private int posX;
        private int posY;

        public GameObject()
        {

        }

        public virtual void Update(GameTime gameTime)
        {
            // skal overskrives for de enkelte objekter .
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            // skal også overskrives fra de enkelt objekter.
        }

        public virtual void Load()
        {
            //skal overskrives for de enkelte objekter
        }

        /*
         * Okay folkens, jeg så lige det i lavede i vores wall class og jeg syntes umiddelbart at det var meget nemt at
         * gøre den universal til alle game objects (hvis det her virker). Jeg har taget alt i bruger om refractor'ed det til
         * ting der er universelle for gameObejcts. Dette har jeg gjordt ved at give game objects 3 variabler:
         * posX, posY og en defaultSprite. Når disse er i playerclassen kan man skrive alt hvad i har skrevet,
         * bare i denne her class. Dette betyder jo så at vi kan hive isTouching ned fra gameObjects istedet for at
         * den er specificeret til wall. jeg har ikke slettet noget af det i har skrevet i wall, hvis nu jeg skulle have
         * misforstået noget.
         */

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(posX, posY, defaultSprite.Width, defaultSprite.Height);
            }
        }
        
        #region Collision 
        protected bool isTouchingLeft(GameObject defaultGameObject)
        {
            return this.Rectangle.Right + this.posX > defaultGameObject.Rectangle.Left &&
                   this.Rectangle.Left < defaultGameObject.Rectangle.Left &&
                   this.Rectangle.Bottom > defaultGameObject.Rectangle.Top &&
                   this.Rectangle.Top < defaultGameObject.Rectangle.Bottom;




        }
        protected bool isTouchingRight(GameObject defaultGameObject)
        {
            return this.Rectangle.Left + this.posX > defaultGameObject.Rectangle.Right &&
                   this.Rectangle.Right < defaultGameObject.Rectangle.Right &&
                   this.Rectangle.Bottom > defaultGameObject.Rectangle.Top &&
                   this.Rectangle.Top < defaultGameObject.Rectangle.Bottom;




        }
        protected bool isTouchingTop(GameObject defaultGameObject)
        {
            return this.Rectangle.Bottom + this.posX > defaultGameObject.Rectangle.Top &&
                   this.Rectangle.Top < defaultGameObject.Rectangle.Top &&
                   this.Rectangle.Right > defaultGameObject.Rectangle.Left &&
                   this.Rectangle.Left < defaultGameObject.Rectangle.Right;




        }
        protected bool isTouchingBottom(GameObject defaultGameObject)
        {
            return this.Rectangle.Top + this.posX > defaultGameObject.Rectangle.Bottom &&
                   this.Rectangle.Bottom < defaultGameObject.Rectangle.Bottom &&
                   this.Rectangle.Right > defaultGameObject.Rectangle.Left &&
                   this.Rectangle.Left < defaultGameObject.Rectangle.Right;




        }
        #endregion
    }
}

