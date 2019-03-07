using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2
{
    class Projectiles : GameObject
    {
        protected int posX;
        protected int posY;
        protected Texture2D defaultSprite;


        public virtual void intersects(GameObject gameObjectOne, GameObject gameObjectTwo)
        {

        }

        public virtual void Update(GameTime gameTime)
        {
           
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
         
        }

        public virtual void Load()
        {
            defaultSprite = GameHolder.Game.Content.Load<Texture2D>("Projectiles/DefaultProjectiles/1_HeroShotgunBulletFrames (1)");
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
        public void moveProjectiles(Player.Player player)
        {
          
        }
    }


}

