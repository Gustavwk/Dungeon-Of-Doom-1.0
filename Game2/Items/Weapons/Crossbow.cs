﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic;
using Game2.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Game2
{
    public class Crossbow : Weapon
    {
        private Texture2D sprite;
        private SoundEffect shoot;       

        public Crossbow(int x, int y, Mediator mediator) : base(x, y, mediator)
        {
            
        }

        public override bool Collision(GameObject other)
        {
            if (other is Player.Player)
            {
                taken = true;
                mediator.player.Weapon = new Crossbow(0, 0, mediator);
                mediator.itemToBeDeleted.Add(this);
                mediator.player.weapon.Projectile = new CrossbowProjectile(x, y, Direction.NORTH, mediator);
            }
            return true;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(sprite, new Rectangle(this.X, this.Y, WIDTH, HEIGHT), Color.White);
        }

        public override void fire(int x, int y, Direction direction)
        {
            Projectile crossbowProjectile = new CrossbowProjectile(x, y, direction, mediator);
            this.Load();
            shoot.CreateInstance().Play();
            crossbowProjectile.Load();
            mediator.itemToBeAdded.Add(crossbowProjectile);
        }

        public override void Load()
        {
            sprite = Mediator.Game.Content.Load<Texture2D>("items/crossbow_1");
            pickUp = Mediator.Game.Content.Load<SoundEffect>("Sounds/PickupCrossbow");
            shoot = Mediator.Game.Content.Load<SoundEffect>("Sounds/CrossBow");
        }

        public override string ToString()
        {
            return "Crossbow";
        }

        public override void Update(GameTime gameTime)
        {
            PlayPickUp();
        }
    }
}

