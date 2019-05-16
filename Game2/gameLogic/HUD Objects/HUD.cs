using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Game2.gameLogic.HUD_Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2.gameLogic
{
    class HUD : GameObject
    {
        private Player.Player player;
        private Level level;
        private int unitsAvailableX;                              
        private int unitsAvailableY;
        private int unit = 32;
        private SpriteFont spriteFont;
        private Color textColor = Color.LightYellow;
        


        
       

        public void initHUDBackground()
        {
            Random random = new Random();
            
            for (int i = 0; i < this.X; i+=unit)
            {
                    for (int j = 0; j < this.Y; j += unit)
                    {
                    
                    mediator.AllObjects.Add(new HUDTile(i, j+480, random.Next(5), this.mediator));
                }
            }
        }


        public HUD(int x, int y, Mediator mediator) : base(mediator,x,y)
        {
            this.unitsAvailableX = this.X / this.unit;
            this.unitsAvailableY = this.Y / this.unit;

            
            initHUDBackground();
            
        }


        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            StaticHUDText(spriteBatch);
        }

        private void StaticHUDText(SpriteBatch spriteBatch)
        {
            if (mediator.player.health > 0)
            {
                spriteBatch.DrawString(spriteFont, "HP: " + mediator.player.health, new Vector2(0 + 10, 480), textColor);
            }
            else
            {
                spriteBatch.DrawString(spriteFont, "DEAD", new Vector2(0 + 10, 480), textColor);
            }


            spriteBatch.DrawString(spriteFont, "Weapon: " + mediator.player.weapon, new Vector2(0 + 10, 480 + unit), textColor);
            spriteBatch.DrawString(spriteFont, "Cooldown: " + mediator.player.playerCooldown,
                new Vector2(0 + 10, 480 + unit * 2), textColor);
            spriteBatch.DrawString(spriteFont, "Movement Speed: " + mediator.player.movementspeed, new Vector2(unit * 8, 480),
                textColor);
            spriteBatch.DrawString(spriteFont, "Kills: " + mediator.player.Kills, new Vector2(unit * 8, 480 + unit * 2),
                textColor);
            spriteBatch.DrawString(spriteFont, "Enemies in Room: " + mediator.room.EnemyCount, new Vector2(unit * 16, 480),
                textColor);
            DisplayDmg(spriteBatch);
            if (mediator.player.BloodRush)
            {

                spriteBatch.DrawString(spriteFont, "STATUS: BLOOD RUSH", new Vector2(unit * 12, 480 + (unit*2)),
                    Color.Red);

            }
            else if (mediator.player.Hybris)
            {
                spriteBatch.DrawString(spriteFont, "STATUS: HYBRIS" , new Vector2(unit * 12, 480 + (unit*2)),
                    Color.Yellow);
            }
            else
            {
                spriteBatch.DrawString(spriteFont, "STATUS:", new Vector2(unit * 12, 480 + (unit * 2)),
                    textColor);

            }

        }

        private void DisplayDmg(SpriteBatch spriteBatch)
        {
            int x = unit * 8;
            int y = 480 + unit;

            if (mediator.player.Weapon == null)
            {
              
                Projectile p = new Projectile(0, 0, Direction.NORTH, mediator);
                spriteBatch.DrawString(spriteFont, "DMG " + p.Damage, new Vector2(x, y), textColor);
            }
            else if (mediator.player.Weapon != null)
            {

                //null pointer her - fucking irri

               // Projectile cp = mediator.player.Weapon.Projectile;
              //  spriteBatch.DrawString(spriteFont, "DMG " + cp.Damage, new Vector2(x, y), textColor);
               
            }

        }

        public override void Load()
        {
            spriteFont = Mediator.Game.Content.Load<SpriteFont>("HUD/font/Gamefont");
        }

        public override void Update(GameTime gameTime)
        {
          
        }

        public int unitCoord(int coord) //den her er translater et coordinat så det giver mening i forhold til vores units !
        {
            int unitCoord = coord * unit;
            return unitCoord;
        }

    }
    
}
