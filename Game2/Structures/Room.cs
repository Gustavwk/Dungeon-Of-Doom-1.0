using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Game2.gameLogic;
using Game2.Items.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2.Structures
{

    class Room : GameObject
    {
        //800 x 480 pixels er vores nuværende x og y - dette kan sikkert gøres mere scalable
        private int unit = 32;                                    //Den fælles sidelænge på det wall-billede vi bruger!
        private int unitsAvailableX;                              //Længden af skærmen - bliver delt i 32 i Room();
        private int unitsAvailableY;                              //Højden af skærmen - bliver delt i 32 i Room();
        private int unitPosX;                                     //Holder styr på hvor den næste wall sættes på x-aksen
        private int unitPosY;                                     //Holder styr på hvor den næste wall sættes på y-aksen
        private int prevUnitPosX;                                 //Holder styr på hvor den sidste wall blev sat på x-aksen  - Denne bliver ikke brugt pt.
        private int prevUnitPosY;                                 //Holder styr på hvor den sidste wall blev sat på y-aksen  - Denne bliver ikke brugt pt.
                                                                  //Resolution y-akse

        private int multiplier = 1;

        public int Multiplier
        {
            get => multiplier;
            set => multiplier = value;
        }

        private Random random = new Random();






        public Room(int x, int y, Mediator mediator) : base(mediator, x, y)
        {



            this.unitsAvailableX = x / this.unit;
            this.unitsAvailableY = y / this.unit;


        }

        public void initRandomLevel()
        {
            Level level = new Level();
            Random random = new Random();

            layFloor();
            roomBoarders();
            int randomLevelOne = random.Next(level.LevelList.Count);
            int randomLevelTwo = random.Next(level.LevelList.Count);
            int randomLevelTree = random.Next(level.LevelList.Count);

            
            TraverseLevelArray(unitCoord(2), unitCoord(1),level.LevelList[randomLevelOne]);
            TraverseLevelArray(unitCoord(9), unitCoord(1), level.LevelList[randomLevelTwo]);
            TraverseLevelArray(unitCoord(16), unitCoord(1), level.LevelList[randomLevelTree]);

        }

        public override void Load()
        {


        }

        public void layFloor()
        {
            unitPosX = 0;
            unitPosY = 0;

            for (int i = 0; i < this.X; i += unit)
            {
                for (int j = 0; j < this.Y; j += unit)
                {
                    mediator.itemToBeAdded.Add(new Tiles(i, j, random.Next(3) + 1, this.mediator));
                }
            }

        }

    
        private void TraverseLevelArray(int x, int y, int[,] level)
        {
            /*
             * 0 = Ingenting
             * 1 = wall
             * 2 = lavatile
             * 3 = crossbow
             * 4 = movementspeed boost
             * 5 = attack speed boost
             * 6 = Hp boost
             * 7 = Creep
             * 8 = FrozenBow
             * 9 = SimpleGun
             * 10 = Wand
             */

            int uBound0 = level.GetUpperBound(0);
            int uBound1 = level.GetUpperBound(1);

            for (int i = 0; i <= uBound0; i++)
            {
                for (int j = 0; j <= uBound1; j++)
                {
                    if (level[i, j] == 2)
                    {
                        mediator.itemToBeAdded.Add(new LavaTile(x + unitCoord(i), y + unitCoord(j), 0, mediator));
                    }

                    if (level[i, j] == 4)
                    {
                        mediator.itemToBeAdded.Add(new MsBoost(x + unitCoord(i), y + unitCoord(j), mediator));
                    }

                    if (level[i, j] == 5)
                    {
                        mediator.itemToBeAdded.Add(new AsBoost(x + unitCoord(i), y + unitCoord(j), mediator));
                    }

                    if (level[i, j] == 6)
                    {
                        mediator.itemToBeAdded.Add(new HpBoost(60, x + unitCoord(i), y + unitCoord(j), mediator));
                    }

                    if (level[i, j] == 7)
                    {
                        mediator.itemToBeAdded.Add(new Creep.Creep(x + unitCoord(i), y + unitCoord(j), mediator));
                    }

                    if (level[i, j] == 3)
                    {
                        mediator.itemToBeAdded.Add(new Crossbow(x + unitCoord(i), y + unitCoord(j), mediator));
                    }

                    if (level[i, j] == 1)
                    {
                        mediator.itemToBeAdded.Add(new Wall(x + unitCoord(i), y + unitCoord(j), mediator));
                    }
                    if (level[i, j] == 8)
                    {
                        mediator.itemToBeAdded.Add(new FrozenBow(x + unitCoord(i), y + unitCoord(j), mediator));
                    }
                    if (level[i, j] == 9)
                    {
                        mediator.itemToBeAdded.Add(new SimpleGun(x + unitCoord(i), y + unitCoord(j), mediator));
                    }
                    if (level[i, j] == 10)
                    {
                        mediator.itemToBeAdded.Add(new Wand(x + unitCoord(i), y + unitCoord(j), mediator));
                    }

                }
            }
        }


        public int unitCoord(int coord) //den her er translater et coordinat så det giver mening i forhold til vores units !
        {
            int unitCoord = coord * unit;
            return unitCoord;
        }


        public void simpleMaze()
        {


            Random random = new Random();



            for (int i = 0; i < multiplier; i++)
            {

                mediator.AllObjects.Add(new LavaTile(unitCoord(random.Next(unitsAvailableX)), unitCoord(random.Next(unitsAvailableY)), 1, mediator));

            }

            for (int i = unit * 3; i < X - unit * 3; i += unit)
            {
                mediator.AllObjects.Add(new Wall(i, Y - (Y / 3 * 2) - unit, mediator));
                mediator.AllObjects.Add(new Wall(i, Y - Y / 3, mediator));

            }
            mediator.AllObjects.Add(new Wall(unitCoord(3), unitCoord(5), mediator));
            mediator.AllObjects.Add(new Wall(unitCoord(3), unitCoord(9), mediator));
            mediator.AllObjects.Add(new Wall(unitCoord(21), unitCoord(5), mediator));
            mediator.AllObjects.Add(new Wall(unitCoord(21), unitCoord(9), mediator));

            for (int i = 0; i < multiplier; i++)
            {
                mediator.AllObjects.Add(new AsBoost(unitCoord(random.Next(unitsAvailableX)), unitCoord(random.Next(unitsAvailableY)), mediator));
                mediator.AllObjects.Add(new MsBoost(unitCoord(random.Next(unitsAvailableX)), unitCoord(random.Next(unitsAvailableY)), mediator));
                mediator.AllObjects.Add(new HpBoost(200 / multiplier, unitCoord(random.Next(unitsAvailableX)), unitCoord(random.Next(unitsAvailableY)), mediator));
            }


        }



        public void roomBoarders()
        {

            

            Random random = new Random();

            int wallSpace = random.Next(1, 23);
            int doorDifference = random.Next(1, 23);
            Debug.WriteLine("Wallspace" + wallSpace);

            for (int i = 0; i < unitsAvailableX; i++)
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

                mediator.itemToBeAdded.Add(new Wall(unitPosX, 0, mediator));
                mediator.itemToBeAdded.Add(new Wall(unitPosX, this.Y - unit, mediator));


               

                prevUnitPosX = unitPosX;
                unitPosX = unitPosX + unit;
            }

            for (int i = 0; i < unitsAvailableY; i++)
            {

                mediator.itemToBeAdded.Add(new Wall(0, unitPosY, mediator));
                mediator.itemToBeAdded.Add(new Wall(this.X - unit, unitPosY, mediator));

                prevUnitPosY = unitPosY;
                unitPosY = unitPosY + unit;
                

            }
            mediator.itemToBeAdded.Add(new Door(unitCoord(0),unitCoord(7),mediator,false));
            mediator.itemToBeAdded.Add(new Door(unitCoord(24), unitCoord(7), mediator,true));
        }

        


    }
}
