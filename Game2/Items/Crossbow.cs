using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Game2.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2
{
    class Crossbow : Weapon
    {
        private Texture2D sprite;
        private bool shoudDraw = true;
        

        public Crossbow(int x, int y, Mediator mediator) : base(x, y, mediator)
        {
            this.hitbox = new Rectangle(this.X, this.Y, 32, 32);
              
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (shoudDraw)
            {
                spriteBatch.Draw(sprite, new Rectangle(this.X, this.Y, 32, 32), Color.White);
            }
        }

        public override void Update(GameTime gameTime)
        {

        }


        public override void fire(int x, int y, Direction direction)
        {
            Projectile crossbowProjectile = new CrossbowProjectile(x, y, direction, mediator);
            crossbowProjectile.Load();
            mediator.itemToBeAdded.Add(crossbowProjectile);
        }

        public override void Load()
        {
            sprite = Mediator.Game.Content.Load<Texture2D>("items/crossbow_1");
        }

      


        public override void intersects(GameObject other)
        {
            if (other is Player.Player)
            {
                
                shoudDraw = false;
                hitbox = Rectangle.Empty;
                mediator.player.Weapon = new Crossbow(0,0,mediator);
            }
        }

        public override string ToString()
        {
            return "Crossbow";
        }

       


    }
}

