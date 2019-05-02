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

        /*
         * Kreative overvejelser - Vi står lidt i den situation nu er at CrossBow(og alle andre våben) skal have et nyt projectile på den ene elelr den anden måde.
         * En måde at gøre det på kunne være at idet man samler våbnet op, så ændre hele projectile classen sig, inde i projectile. Dette virker dog ikke som en særlig "SOLID"
         * Måde at gøre tingende på.
         *
         * En anden løsning kunne være at hvert eneste våben havde en understående projectile classe. eksempelvis kunne crossbow have subclassen crossbowProjectile
         * Og hvis player havde samlet en crossbow op, så skød player med crossbowProjectile istedet for den projectile classe som player skyder med nu..
         *
         * jeg synes personeligt selv at den sidste løsning er meget fed, selvom den måske kræver lidt benarbejde. Vi kunne derudover også tilføje en abstract class der hedder
         * Allprojectiles eller sådan noget så vi slipper for at skrive mega meget dubplicate kode. 
         *
         */


    }
}

