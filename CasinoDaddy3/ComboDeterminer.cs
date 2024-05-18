using System;
using System.Collections.Generic;

namespace CasinoDaddy3
{
    internal class ComboDeterminer
    {
        private int[] rutBoardValues = new int[15];

        public ComboDeterminer(int[] values) //den tar in alla 15 värden i en int[15]
        {
            for (int i = 0; i < 15; i++) // den skriver in dem i den nya variabeln rutBoardValues
            {
                rutBoardValues[i] = values[i];
            }
            Console.WriteLine(string.Join(",", rutBoardValues)); //den visar alla nummer i console för lättare felsökning.
        }

        List<int[]> slotCombos = new List<int[]>
        {
            new int[] {1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            new int[] {0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0},
            new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1},
            new int[] {1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0},
            new int[] {0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0},
            new int[] {0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1}
        };

        private int valueHeightChecker() 
        {
            int valueHeight = 0;
            for (int i = 0; i < rutBoardValues.Length; i++) 
            {
                if (rutBoardValues[i] > valueHeight)
                {
                    valueHeight = rutBoardValues[i];
                }
            }

            return valueHeight;
        }
        public void comboCheck()
        {
            int height = valueHeightChecker();

            for (int x = 0; x< slotCombos.Count;)
            for (int i = 0; i < height; i++) //för alla möjliga värden i rutBoard...
            {
                for (int j = 0;) //fixa här
            }

        }
    }
}
