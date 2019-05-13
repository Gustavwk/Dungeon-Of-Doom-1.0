using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Game2.Items.Weapons
{
    class Wand : Weapon 
    {
        private Texture2D sprite;
        private SoundEffect soundEffect;
        private SoundEffect pickupWand;

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
            soundEffect = Mediator.Game.Content.Load<SoundEffect>("Sounds/Wand");
            pickupWand = Mediator.Game.Content.Load<SoundEffect>("Sounds/PickupWand");
        }

        public override void fire(int x, int y, Direction direction)
        {
            Projectile wandProjectile = new WandProjectile(x, y, direction, mediator);
            //soundEffect.Play(); //Virker ikke pt.
            wandProjectile.Load();
            mediator.itemToBeAdded.Add(wandProjectile);
            
        }


        public override bool intersects(GameObject other)
        {
            if (other is Player.Player)
            {
                mediator.player.Weapon = new Wand(0, 0, mediator);
                mediator.itemToBeDeleted.Add(this);
                pickupWand.CreateInstance().Play();
            }

            return true;
        }

        public override string ToString()
        {
            return "Wand";
        }
    }
}
