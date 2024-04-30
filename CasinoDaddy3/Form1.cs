using System;
using System.Windows.Forms;

namespace CasinoDaddy3
{
    public partial class Form1 : Form
    {
        private RutBoard rutBoard; // Declare RutBoard variable at the class level

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rutBoard = new RutBoard(this); // Instantiate RutBoard properly
        }

        private void slot11_Click(object sender, EventArgs e)
        {
            // Implement slot11_Click event handler if needed
        }

        private void spinButton_Click(object sender, EventArgs e)
        {
            rutBoard.spin(); // Call rutBoard.spin() method
        }
    }
}
