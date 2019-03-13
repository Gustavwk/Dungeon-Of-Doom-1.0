using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
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
        private Texture2D defaultSprite;
        private int posX;
        private int posY;
        public Rectangle hitbox;

        public GameObject()
        {

        }

        public virtual void intersects(GameObject gameObjectOne, GameObject gameObjectTwo)
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


        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(this.posX, this.posY, defaultSprite.Width, defaultSprite.Height); 

            }
        }

        public void drawHitbox() { }

        public virtual void intersectsWithWall(GameObject player, GameObject wall)
        {
           
        }

        public virtual void intersectsWithDoor(GameObject player, GameObject door)
        {

        }

    }
}

