using System;
using System.Collections.Generic;

namespace CasinoDaddy3
{
    internal class ComboDeterminer
    {
        private int[] rutBoardValues = new int[15]; //eftersom det bara finns 15 slots går det bra med en array.

        

        List<int[]> slotCombos = new List<int[]> //här skrivs alla arrays på combos i en lista (en lista så att det blir extra lätt att lägga till.)
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

        private int getValueHeight() //varje bild har ett nummer, vilket betyder att man kan urskilja rutornas bilder (och med det se om de är samma). Detta får man genom arrayen som skickas till konstruktorn.
        {
            int valueHeight = 0; 
            for (int i = 0; i < rutBoardValues.Length; i++) // Det den här gör är att den hittar den högsta punkten för allas siffror, för att sedan kunna gå igenom alla de siffrorna.
            {
                if (rutBoardValues[i] > valueHeight)
                {
                    valueHeight = rutBoardValues[i] + 1;
                }
            }
            return valueHeight;
        }

        public List<int> comboCheck() // ger ut alla kombos som ligger på rutBoard.
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

                    if (comboSant == true) // om alla siffror är likadana i varje rutboard-värde så läggs den till i listan av kombos.
                    {
                        Console.WriteLine("combo" + x);
                        allaCombos.Add(x);
                    }
                }
            }
            return allaCombos; // här ges en lista (int) på alla combos ut.
        }


        public ComboDeterminer(int[] values) //den tar in alla 15 värden i en int[15] (alltså rutboards rutor)
        {
            for (int i = 0; i < 15; i++) // den skriver in dem i den nya variabeln rutBoardValues
            {
                rutBoardValues[i] = values[i]; // genom detta ger konstruktorn ut de viktiga siffrorna för rutBoard.
            }
        
        }
    }
}
