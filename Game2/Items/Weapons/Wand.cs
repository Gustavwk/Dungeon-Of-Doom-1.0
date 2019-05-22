using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using IUpdateable = Game2.gameLogic.IUpdateable;

namespace Game2.Items.Weapons
{
    public class Wand : Weapon 
    {
        private Texture2D sprite;
        private SoundEffect shoot;
        

        public Wand(int x, int y, Mediator mediator) : base(x, y, mediator)
        {
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            this.Projectile = new WandProjectile(0,0,Direction.NORTH,mediator);
            spriteBatch.Draw(sprite, new Rectangle(this.X, this.Y, WIDTH, HEIGHT), Color.White);

        }

        public override void Load()
        {
            sprite = Mediator.Game.Content.Load<Texture2D>("Items/Weapons/spwpn_staff_of_dispater_new");
            shoot = Mediator.Game.Content.Load<SoundEffect>("Sounds/Wand");
            pickUp = Mediator.Game.Content.Load<SoundEffect>("Sounds/PickupWand");
        }

        public override void fire(int x, int y, Direction direction)
        {
            Projectile wandProjectile = new WandProjectile(x, y, direction, mediator);
            this.Load();
            shoot.Play();
            wandProjectile.Load();
            mediator.itemToBeAdded.Add(wandProjectile);
        }


        public override bool Collision(GameObject other)
        {
            

            if (other is Player.Player)
            {
                taken = true;
                mediator.player.Weapon = new Wand(0, 0, mediator);
                mediator.itemToBeDeleted.Add(this);
               
            }

            return true;
        }

        public override void Update(GameTime gameTime)
        {
           PlayPickUp();
        }

        

        public override string ToString()
        {
            return "Wand";
        }
    }
}
