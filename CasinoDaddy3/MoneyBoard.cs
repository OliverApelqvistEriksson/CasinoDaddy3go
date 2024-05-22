using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CasinoDaddy3
{
    internal class MoneyBoard //kanske är onödig, det enda den gör är att den tar in Form1 och sätter ett värde på moneyBox().
    {
        private Form1 parentForm = null;

        public MoneyBoard(Form1 form)
        {
            parentForm = form;
        }

        public void setMoneyBox(string text)
        {
            parentForm.changeMoneyTextBox(text);
        }
        
    }
}
