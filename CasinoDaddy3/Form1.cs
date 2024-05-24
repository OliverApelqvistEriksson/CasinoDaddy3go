using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CasinoDaddy3
{
    public partial class Form1 : Form
    {
        private RutBoard rutBoard; // Startar rutBoard
        private MoneyBoard moneyBoard; // startar moneyboard
        private MoneyKeep moneyKeep; // startar moneykeep


        public Form1()
        {
            InitializeComponent();
            rutBoard = new RutBoard(this); // fixar upp ny rutBoard
            moneyBoard = new MoneyBoard(this); // instansierar
            moneyKeep = new MoneyKeep(); //sätter upp spargrisen så att man kan registrera pengar.
            moneyBoard.setMoneyBox(moneyKeep.getMoney().ToString()); //skriver ut pengarna
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void changeMoneyTextBox(string text) //den här metoden kommunicerar med MoneyBoard för att ändra pengarna som syns på Board.
        {
            moneyBox.Text = text; //det den gör är att den ändrar moneyBox-texten.
        }

        private void spinButton_Click(object sender, EventArgs e) //spinbutton_click startar slotmaskinens spel.
        {
            spinButton.Enabled = false; // slå av knapp.

            moneyKeep.changeMoney("spin"); // Kostar att spela.

            int[] slots = rutBoard.spinAndGetSlots(); // fixa rutor
            ComboDeterminer comboDeterminer = new ComboDeterminer(slots); // starta denna som ska kunna bestämma combos
            List<int> combos = comboDeterminer.comboCheck(); //får ut lista på combos.

            for (int i = 0; i < combos.Count; i++ ) { moneyKeep.changeMoney("win"); } //för varje gång man får en kombo får man en viss mängd pengar.
            
            moneyBoard.setMoneyBox(moneyKeep.getMoney().ToString()); //moneyBoard kommunicerar med Form och skriver ut vad moneyKeep (spargrisen) har för pengar.
            spinButton.Enabled = true; //sedan kan man spela igen, så knappen går att trycka igen.
        }

        private void moneyInsertButton_Click(object sender, EventArgs e) //lägger till summa pengar, och skriver ut mängd pengar.
        {
            moneyKeep.changeMoney("add");
            moneyBoard.setMoneyBox(moneyKeep.getMoney().ToString());
        }

        private void takeOutButton_Click(object sender, EventArgs e) //tar ut summa pengar, och skriver ut ny mängd pengar
        {
            moneyKeep.changeMoney("takeOut");
            moneyBoard.setMoneyBox(moneyKeep.getMoney().ToString());
        }

        
    }
}
