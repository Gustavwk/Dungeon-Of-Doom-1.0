using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.gameLogic
{
    class Level : IMediator
    {
        public Mediator mediator { get; set; }
        private int level = 0;
        private int multiplier = 0;
        private List<int[,]> levelList = new List<int[,]>();

        public int Multiplier
        {
            get => multiplier;
            set => multiplier = value;
        }

        public List<int[,]> LevelList => levelList;

        public Level()
        {
            initLevels();
        }

        public void initLevels()
        {
            int[,] lavaLoot = new int[,]
            {

                {1,1,1,1,1,0,0,0,1,1,1,1,1},
                {2,0,2,0,1,0,0,0,1,0,2,5,2},
                {2,0,2,2,2,0,0,0,2,2,2,0,2},
                {3,7,0,0,0,8,9,10,0,0,0,0,4},
                {2,0,2,2,2,0,0,0,2,2,2,0,2},
                {2,0,2,0,1,0,0,0,1,0,2,6,2},
                {1,1,1,1,1,0,0,0,1,1,1,1,1}

            };

            int[,] healthBoostFrostBow = new int[,]
            {

                {1,1,1,1,1,1,0,1,1,1,1,1,1},
                {1,2,2,2,2,2,0,2,2,2,2,2,1},
                {1,2,2,2,2,0,0,0,2,2,0,6,1},
                {1,2,8,0,0,0,0,0,0,0,0,6,1},
                {1,2,2,2,2,0,0,0,2,2,0,6,1},
                {1,2,2,2,2,2,0,2,2,2,2,2,1},
                {1,1,1,1,1,1,0,1,1,1,1,1,1}

            };

            int[,] creepSwarm = new int[,]
            {

                {7,7,7,7,7,7,7,7,7,7,7,7,7},
                {7,7,7,7,7,7,7,7,7,7,7,7,7},
                {7,7,7,7,7,7,7,7,7,7,7,7,7},
                {7,7,7,7,7,7,7,7,7,7,7,7,7},
                {7,7,7,7,7,7,7,7,7,7,7,7,7},
                {7,7,7,7,7,7,7,7,7,7,7,7,7},
                {7,7,7,7,7,7,7,7,7,7,7,7,7}

            };

            levelList.Add(lavaLoot);
            levelList.Add(healthBoostFrostBow);
            levelList.Add(creepSwarm);
        }

        #region Level arry template
        /*
         *  int[,] level = new int[,]
            {

                {0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0}

            };
         */
        #endregion
    }
}
