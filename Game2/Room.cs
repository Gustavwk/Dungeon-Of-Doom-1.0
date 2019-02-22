using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2
{
   
    class Room : GameObject
    {
        //800 x 480 pixels er vores nuværende x og y - dette kan sikkert gøres mere scalable
       
        private static int unit = 32;                               //Den fælles sidelænge på det wall-billede vi bruger!
        private int unitsAvailableX = 800 / unit;          //Længden af skærmen delt i 32
        private int unitsAvailableY = 480 / unit;          //Højden af skærmen delt i 32
        private int unitPosX;                                        //Holder styr på hvor den næste wall sættes på x-aksen
        private int  unitPosY;                                       //Holder styr på hvor den næste wall sættes på y-aksen
        private int prevUnitPosX;                                //Holder styr på hvor den sidste wall blev sat på x-aksen
        private int prevUnitPosY;                                //Holder styr på hvr den sidste wall blev sat på y-aksen

        List<Wall> walls = new List<Wall>();

        public Room()
        {
            porpulateRoom();
        }

        public void porpulateRoom()
        {
            for (int i = 0; i < unitsAvailableX; i++)
            {
                /*
                 * Første wall bliver lavet på unitPosX(0), unitPosY(0).
                 * prevUnitPosX bliver til unitPosX
                 * unitPosX bliver tilagt en unit(32)
                 * Næste Wall bliver lavet på unitPosX(32), unitPosY(0)
                 * ....
                 * Dette sker indtil i < unitAvailableX
                 */
                unitPosX = 0;
                walls.Add(new Wall(unitPosX,unitPosY));
                prevUnitPosX = unitPosX;       
                unitPosX = +unit;
            }

            for (int i = 0; i < unitsAvailableY; i++)
            {
                /*
                  * Første wall bliver lavet på unitPosX(0), unitPosY(0).
                 * prevUnitPosX bliver til unitPosY
                 * unitPosX bliver tilagt en unit(32)
                 * Næste Wall bliver lavet på unitPosX(0), unitPosY(32)
                 * ....
                 * Dette sker indtil i < unitAvailableY
                 */
                unitPosX = 0;
                walls.Add(new Wall(unitPosX,unitPosY));
                prevUnitPosY = unitPosY;
                unitPosY = +unit;
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (Wall wall in walls)
            {
                wall.Draw(spriteBatch, gameTime);
            }

        }
    }
}
