﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoDaddy3
{
    internal class MoneyKeep //moneykeep håller koll på pengarna man har. Den regulerar även genom alterMoney() hur mycket man vinner och förlorar.
    {
        private int money = 50;
        private int spinCost = 1;
        private int reward = 5;
        private int insert = 10;
        private int takeOut = 5;
      
        private void alterMoney(string action, int value) // en privat funktion som här inne ändrar pengarna.
        {
            if (action == "a") //a för add
            {
                money += value; 
            }
            if (action == "s") 
            { 
                money -= value; 
            }// s för subtract
        }

        public void changeMoney(string change) // en massa "call-signs" för att ändra pengar väldigt enkelt på andra ställen i andra klasser.
        { 
            if (change == "spin") { alterMoney("s", spinCost); } //varje gång man spin-ar
            if (change == "win") { alterMoney("a", reward); } //om man vinner (får en combo)
            if (change == "add") { alterMoney("a", insert); } // om man vill lägga in pengar
            if (change == "takeOut") { alterMoney("s", takeOut); } //Om man vill ta ut pengar.
        }

        public int getMoney() //se pengavärde
        { 
            Console.WriteLine(money);
            return money;
        }

    }
}
