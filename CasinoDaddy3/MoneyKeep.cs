using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoDaddy3
{
    internal class MoneyKeep //moneykeep håller koll på pengarna man har. Den regulerar även genom alterMoney() hur mycket man vinner och förlorar.
    {
        private int money = 50;
        public void alterMoney(string action, int value) 
        {
            if (action == "a") 
            {
                money += value;
            }
            if (action == "s") { money -= value; }
        }

        public int getMoney() //se pengavärde
        { 
            return money;
        }

    }
}
