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


        public Door(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.hitbox = new Rectangle(this.X, this.Y, 32, 32);
        }
        public override void Load()
        {
            defaultDoor = GameHolder.Game.Content.Load<Texture2D>("Doors/closed_door");
        }


        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public override void intersects(GameObject Door)
        {
            if (Door is Player.Player)
            {
                Player.Player p = (Player.Player)Door;
                p.setX(200);
                p.setY(200);
                //Load new level
            }
            
        }


        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(defaultDoor, hitbox, Color.White);

        }
    }
}
