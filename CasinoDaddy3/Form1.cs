using System;
using System.Windows.Forms;

namespace CasinoDaddy3
{
    public partial class Form1 : Form
    {
        private RutBoard rutBoard; // Startar rutBoard

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rutBoard = new RutBoard(this); // fixar upp ny rutBoard
        }

        private void slot11_Click(object sender, EventArgs e)
        {
            // måste ta bort
        }

        private void spinButton_Click(object sender, EventArgs e)
        {
            spinButton.Enabled = false;
            rutBoard.spinAndGetSlots(); // Calla spingrej
            spinButton.Enabled = true;

        }
    }
}
