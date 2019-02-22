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
       
        private int unit = 32;                                       //Den fælles sidelænge på det wall-billede vi bruger!
        private int unitsAvailableX;                              //Længden af skærmen - bliver delt i 32 i Room();
        private int unitsAvailableY;                              //Højden af skærmen - bliver delt i 32 i Room();
        private int unitPosX;                                        //Holder styr på hvor den næste wall sættes på x-aksen
        private int  unitPosY;                                       //Holder styr på hvor den næste wall sættes på y-aksen
        private int prevUnitPosX;                                //Holder styr på hvor den sidste wall blev sat på x-aksen  - Denne bliver ikke brugt pt.
        private int prevUnitPosY;                                //Holder styr på hvor den sidste wall blev sat på y-aksen  - Denne bliver ikke brugt pt.

        List<Wall> walls = new List<Wall>();

        public Room(int borderX, int borderY)
        {
            this.unitsAvailableX = borderX / this.unit;
            this.unitsAvailableY = borderY / this.unit;
            porpulateRoom();
        }

        public override void Load()
        {
            foreach (var Wall in walls)
            {
                Wall.Load();                                            //Loader alle billederne den skal bruge!
            }
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
              
                walls.Add(new Wall(unitPosX,0));
                prevUnitPosX = unitPosX;       
                unitPosX = unitPosX+unit;
                Console.WriteLine("Wall Placed at: X" + unitPosX + " Y:" + unitPosY);
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
                
                walls.Add(new Wall(0,unitPosY));
                prevUnitPosY = unitPosY;
                unitPosY = unitPosY+unit;
                Console.WriteLine("Wall Placed at: X" + unitPosX + " Y:" + unitPosY);
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
