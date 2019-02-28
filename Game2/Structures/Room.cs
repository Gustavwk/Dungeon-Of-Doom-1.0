using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2.Structures
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
        private int resX;                                             //Resolution x-akse
        private int resY;                                             //Resolution y-akse
        
       
        public List<Wall> walls = new List<Wall>();

        public Room(int borderX, int borderY)
        {
            this.resX = borderX;
            this.resY = borderY;
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
                 *
                 * Når mans sætter et object til at "spawne" uden for et gyldigt x eller y, sætter den x / y til 0.
                 * Den anden wall der bliver sat i  dette loop bliver sat på det samme X-koordinat, men med et Y-koordinat
                 * der er skærmens højre - unit (32 - Dette gør at billedet går lige til kanten).
                 */
              
                walls.Add(new Wall(unitPosX,0));
             
                //Console.WriteLine("Wall(Outer) Placed at: X" + unitPosX + " Y:" + unitPosY);

                walls.Add(new Wall(unitPosX,resY-unit));
                //Console.WriteLine("Wall(Inner) Placed at: X" + unitPosX + " Y:" + unitPosY);

                prevUnitPosX = unitPosX;       
                unitPosX = unitPosX+unit;
                
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
                 *
                 * Når mans sætter et object til at "spawne" uden for et gyldigt x eller y, sætter den x / y til 0.
                 * Den anden wall der bliver sat i i dette loop bliver sat på det samme Y-koordinat, men med et X-koordinat
                 * der er skærmens højre - unit (32 - Dette gør at billedet går lige til kanten).
                 */

                walls.Add(new Wall(0,unitPosY));
                //Console.WriteLine("Wall(Outer) Placed at: X" + unitPosX + " Y:" + unitPosY);

                walls.Add(new Wall(resX-unit, unitPosY));
                //Console.WriteLine("Wall(Inner) Placed at: X" + unitPosX + " Y:" + unitPosY);

                prevUnitPosY = unitPosY;
                unitPosY = unitPosY+unit;
               
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
