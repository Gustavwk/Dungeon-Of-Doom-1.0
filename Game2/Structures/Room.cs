﻿using System;
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
        private int unitPosY;                                       //Holder styr på hvor den næste wall sættes på y-aksen
        private int prevUnitPosX;                                //Holder styr på hvor den sidste wall blev sat på x-aksen  - Denne bliver ikke brugt pt.
        private int prevUnitPosY;                                //Holder styr på hvor den sidste wall blev sat på y-aksen  - Denne bliver ikke brugt pt.
        private int width;                                             //Resolution x-akse
        private int height;                                            //Resolution y-akse
        
       
        public List<Wall> walls = new List<Wall>();

        public Room(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.unitsAvailableX = width / this.unit;
            this.unitsAvailableY = height / this.unit;
            populateRoom();
        }

        public override void Load()
        {
            foreach (var Wall in walls)
            {
                Wall.Load();                                            //Loader alle billederne den skal bruge!
            }
        }

        public void populateRoom()
        {

            for (int i = 0; i < unitsAvailableX; i++) 
            {

                if (i != 2) //hvorfor fuck virker det her ikke ? 
                {
                    #region MyRegion

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

                    #endregion

                    walls.Add(new Wall(unitPosX, 0));
                    walls.Add(new Wall(unitPosX, height - unit));
                    
                }

                // det virker nu!!
                prevUnitPosX = unitPosX;
                unitPosX = unitPosX + unit;
            }
          

            for (int i = 0; i < unitsAvailableY; i++)
            {

                walls.Add(new Wall(0,unitPosY));
                walls.Add(new Wall(width-unit, unitPosY));

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
