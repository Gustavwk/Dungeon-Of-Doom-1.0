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
        private int unitsAvailableX;                              //Længden af skærmen - bliver delt i 32 i Room();
        private int unitsAvailableY;
        private int unit = 32;
        private SpriteFont spriteFont;
        private Color textColor = Color.GreenYellow;
        


        
       

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

        public void showPlayerHP()
        {

        }

        public HUD(int x, int y, Mediator mediator) : base(mediator,x,y)
        {
            this.unitsAvailableX = this.X / this.unit;
            this.unitsAvailableY = this.Y / this.unit;

            initHUDBackground();

        }


        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.DrawString(spriteFont, "HP: " + mediator.player.health, new Vector2(0+10, 480), textColor);
            spriteBatch.DrawString(spriteFont, "Weapon: " + mediator.player.weapon, new Vector2(0+10, 480 + unit), textColor);
            spriteBatch.DrawString(spriteFont, "Cooldown: " + mediator.player.playerCooldown, new Vector2(0+10, 480+unit*2), textColor);
            spriteBatch.DrawString(spriteFont, "Movement Speed: " + mediator.player.movementspeed, new Vector2(unit*8, 480), textColor);


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
