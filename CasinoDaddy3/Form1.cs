using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace CasinoDaddy3
{
    public partial class Form1 : Form
    {
        private RutBoard rutBoard; // Startar rutBoard

        public Form1()
        {
            InitializeComponent();
            rutBoard = new RutBoard(this); // fixar upp ny rutBoard

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void slot11_Click(object sender, EventArgs e)
        {
            // måste ta bort
        }

        private void spinButton_Click(object sender, EventArgs e)
        {
            spinButton.Enabled = false; // slå av knapp.
            int[] slots = rutBoard.spinAndGetSlots();
            Console.WriteLine(slots);
            ComboDeterminer comboDeterminer = new ComboDeterminer(slots); // starta denna som ska kunna bestämma combos
           // Console.WriteLine(rutBoard.spinAndGetSlots()); // Calla spingrej
            spinButton.Enabled = true;
        }
    }
}
