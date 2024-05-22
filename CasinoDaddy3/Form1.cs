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
            moneyKeep = new MoneyKeep();
            moneyBoard.setMoneyBox(moneyKeep.getMoney().ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void changeMoneyTextBox(string text)
        {
            moneyBox.Text = text;
        }

        private void spinButton_Click(object sender, EventArgs e)
        {
            spinButton.Enabled = false; // slå av knapp.

            moneyKeep.changeMoney("spin");

            int[] slots = rutBoard.spinAndGetSlots(); // fixa rutor
            ComboDeterminer comboDeterminer = new ComboDeterminer(slots); // starta denna som ska kunna bestämma combos
            List<int> combos = comboDeterminer.comboCheck(); //får ut lista på combos.

            for (int i = 0; i < combos.Count; i++ ) { moneyKeep.changeMoney("win"); }
            
                moneyBoard.setMoneyBox(moneyKeep.getMoney().ToString());
            spinButton.Enabled = true;

            if (moneyKeep.getMoney() < 0) { kreditAdvarselButton.Enabled = true; kreditAdvarselButton.Visible = true; }

        }

        private void moneyInsertButton_Click(object sender, EventArgs e)
        {
            moneyKeep.changeMoney("add");
            moneyBoard.setMoneyBox(moneyKeep.getMoney().ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            moneyKeep.changeMoney("takeOut");
            moneyBoard.setMoneyBox(moneyKeep.getMoney().ToString());
        }

        private void kreditAdvarselButton_Click(object sender, EventArgs e)
        {
            if (moneyKeep.getMoney() < 0) { kreditAdvarselButton.Enabled = true; kreditAdvarselButton.Visible = true; }
            moneyKeep.changeMoney("add");
            moneyBoard.setMoneyBox(moneyKeep.getMoney().ToString());
            if (moneyKeep.getMoney() > 0) { kreditAdvarselButton.Enabled = false; kreditAdvarselButton.Visible = false; }
        }
    }
}
