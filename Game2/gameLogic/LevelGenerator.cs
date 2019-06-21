using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2.gameLogic
{
    class LevelGenerator
    {
        private Mediator mediator;

        private int[,] generatedLevelSlice = new int[,]
        {
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        };

        public LevelGenerator(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public int[,] resetArrayToZero(int[,] array)
       {

           int uBound0 = array.GetUpperBound(0);
           int uBound1 = array.GetUpperBound(1);

            for (int i = 0; i < uBound0; i++)
           {
               for (int j = 0; j < uBound1 ; j++)
               {
                   array[i, j] = 0;
               }
           }
           return array;
       }

        public int[,] takeArray()
        {
            return generatedLevelSlice;
        }

        public void swapElements(int[,] array, int ElementOneIndex, int ElementOneIndexTwo, int ElementTwoIndex, int ElementTwoIndexTwo)
        {
            int temp = array[ElementOneIndex, ElementOneIndexTwo];
            array[ElementOneIndex, ElementOneIndexTwo] = array[ElementTwoIndex, ElementTwoIndexTwo];
            array[ElementTwoIndex, ElementTwoIndexTwo] = temp;

        }

    }
}
