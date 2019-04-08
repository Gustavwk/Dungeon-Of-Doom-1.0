using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2
{
    class HealthBoost : Items
    {

        private Texture2D filledHpPotion;
        private Texture2D emptyHpPotion;
        private int hpPlus;
        private bool taken = false;
        
      

        public HealthBoost(int hpPlus, int x, int y, Mediator mediator) : base(x,y,mediator)
        {
            this.hpPlus = hpPlus;
            this.hitbox = new Rectangle(this.X, this.Y, 32, 32);
            
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

            if (taken)
            {
              spriteBatch.Draw(emptyHpPotion, new Rectangle(this.X, this.Y, 32, 32), Color.White);
            }
            else
            {
                spriteBatch.Draw(filledHpPotion, new Rectangle(this.X, this.Y, 32, 32), Color.White);
            }

            

             



        }

        public override void Load()
        {
            filledHpPotion = Mediator.Game.Content.Load<Texture2D>("items/ruby_old");
            emptyHpPotion = Mediator.Game.Content.Load<Texture2D>("items/white_old");
        }

        public override void intersects(GameObject other)
        {
            if (other is Player.Player)
            {
                
                Player.Player p = (Player.Player) other;
                Debug.Write("Player health rose from " + p.health);
                p.health = p.health + hpPlus;
                Debug.WriteLine(" to :" + p.health);
                this.hitbox = Rectangle.Empty;
                this.taken = true;



            }
        }

        public override void Update(GameTime gameTime)
        {
           
        }
    }
}

