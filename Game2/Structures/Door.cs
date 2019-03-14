using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2.Structures 
{
    class Door : GameObject
    {
        private Texture2D defaultDoor;
        private int posX;
        private int posY;
        public Rectangle hitbox;

        public Door(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
            this.hitbox = new Rectangle(this.posX, this.posY, 32, 32);
        }
        public override void Load()
        {
            defaultDoor = GameHolder.Game.Content.Load<Texture2D>("Doors/closed_door");
        }


        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public override void intersects(GameObject other)
        {
            if (other is Player.Player)
            {
                //Load new level
            }
        }


        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(defaultDoor, hitbox, Color.White);

        }
    }
}
