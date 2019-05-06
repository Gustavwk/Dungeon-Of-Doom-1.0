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
    class HpBoost : Item
    {

        private Texture2D filledHpPotion;
        private Texture2D emptyHpPotion;
        private int hpPlus;
        private bool taken = false;
        
      

        public HpBoost(int hpPlus, int x, int y, Mediator mediator) : base(x,y,mediator)
        {
            this.hpPlus = hpPlus;
            this.hitbox = new Rectangle(this.X, this.Y, WIDTH, HEIGHT);
            
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

            if (taken)
            {
              spriteBatch.Draw(emptyHpPotion, new Rectangle(this.X, this.Y, WIDTH, HEIGHT), Color.White); //Kunne de to new rectangles ikke være hitboxen i stedet?
            }
            else
            {
                spriteBatch.Draw(filledHpPotion, new Rectangle(this.X, this.Y, WIDTH, HEIGHT), Color.White); //Kunne de to new rectangles ikke være hitboxen i stedet?
            }
            
        }

        public override void Load()
        {
            filledHpPotion = Mediator.Game.Content.Load<Texture2D>("items/ruby_old");
            emptyHpPotion = Mediator.Game.Content.Load<Texture2D>("items/white_old");
        }

        public override bool intersects(GameObject other)
        {
            if (other is Player.Player)
            {
                
                            
                mediator.player.health = mediator.player.health + hpPlus;               
                this.hitbox = Rectangle.Empty;
                this.taken = true;

            }
            return true;
        }

        public override void Update(GameTime gameTime)
        {
           
        }
    }
}

