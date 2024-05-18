using System;
using System.Collections.Generic;

namespace CasinoDaddy3
{
    internal class ComboDeterminer
    {
        private int[] rutBoardValues = new int[15];

        

        List<int[]> slotCombos = new List<int[]>
        {
            new int[] {1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            new int[] {0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0},
            new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1},
            new int[] {1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0},
            new int[] {0, 2, 0, 0, 0, 0, 2, 0, 0, 0, 0, 2, 0, 0, 0},
            new int[] {0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0},
            new int[] {0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0},
            new int[] {0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1},

        };

        private int getValueHeight() 
        {
            int valueHeight = 0;
            for (int i = 0; i < rutBoardValues.Length; i++) 
            {
                if (rutBoardValues[i] > valueHeight)
                {
                    valueHeight = rutBoardValues[i] + 1;
                }
            }

            return valueHeight;
        }

        public List<int> comboCheck()
        {
            List<int> allaCombos = new List<int>();
            int height = getValueHeight(); // returnerar höjdvärdet på rutBoard

            for (int k = 0; k < height; k++)
            {
                for (int x = 0; x < slotCombos.Count; x++) //för varje combo i listan...
                {
                    bool comboSant = true;

                    for (int j = 0; j < slotCombos[x].Length; j++) //checkar den för varje del i listan i slotCombos...
                    {
                        if (slotCombos[x][j] != 0) //att om slotcombons listas nummer inte är noll
                        {
                            if (rutBoardValues[j] != k) // och om rutBoardValues inte motsvarar slotCombos
                            {
                                comboSant = false;
                                break;
                            }
                        }
                    }

                    if (comboSant == true)
                    {
                        Console.WriteLine("combo" + x);
                        allaCombos.Add(x);
                    }
                }
            }

            return allaCombos;
        }


        public ComboDeterminer(int[] values) //den tar in alla 15 värden i en int[15]
        {
            for (int i = 0; i < 15; i++) // den skriver in dem i den nya variabeln rutBoardValues
            {
                rutBoardValues[i] = values[i];
            }
            // Console.WriteLine(string.Join(",", rutBoardValues)); //den visar alla nummer i console för lättare felsökning.
        
            comboCheck();
        }
    }
}
