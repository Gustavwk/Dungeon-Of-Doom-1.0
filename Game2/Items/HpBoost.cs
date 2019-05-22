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
using Microsoft.Xna.Framework.Audio;

namespace Game2
{
    public class HpBoost : Item
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

        public override bool Collision(GameObject other)
        {
            if (other is Player.Player)
            {
                playSoundBool = true;
                mediator.player.health = mediator.player.health + hpPlus;
                mediator.player.OverallHealingDone += hpPlus;
                this.hitbox = Rectangle.Empty;
                this.taken = true;
            }
            return true;
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
            soundEffect = Mediator.Game.Content.Load<SoundEffect>("Sounds/Powerup");
        }

        public override void playSound()
        {
            soundEffect.CreateInstance().Play();
        }

        public override void Update(GameTime gameTime)
        {
            if (playSoundBool)
            {
                playSound();
                playSoundBool = false;
            }
        }
    }
}

