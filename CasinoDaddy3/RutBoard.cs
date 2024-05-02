using CasinoDaddy3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace CasinoDaddy3
{
    internal class RutBoard
    {
        private Form1 parentForm;

        public void setImage(int slotNumber, string image) {
            try
            {
                System.Drawing.Image slotBild = System.Drawing.Image.FromFile(image);
                PictureBox bildBox = (PictureBox)parentForm.Controls.Find("slot" + (slotNumber).ToString(), true)[0];
                bildBox.Image = slotBild;
            }
            catch (Exception)
            {
                MessageBox.Show("fel i slots-generering på " + (slotNumber).ToString());
            }
        }

        public RutBoard(Form1 form) {
            parentForm = form;
            string startImage = "C:\\Users\\OliverApelqvistEriks\\source\\repos\\casinoDaddy2\\images\\red.jpg";
            for (int i = 1; i <= 15; i++) {
                setImage(i, startImage);
            }
        }

        public void runAnimation()
        {
            string pictureIntro = "C:\\Users\\OliverApelqvistEriks\\source\\repos\\casinoDaddy2\\images\\";
            List<string> spinPictures = new List<string>() { "red.jpg", "1.png", "2.png", "3.png" };
            for (int x = 0; x < 4; x++) // Change loop condition from <= 4 to < 4
            {
                Console.WriteLine(x);
                for (int y = 1; y <= 15; y++)
                {
                    setImage(y, (pictureIntro + spinPictures[x]));
                }
                Thread.Sleep(100);
            }
        }


        public void spin() // kan behöva lägga in för att disabla knappen under spin, om det tar lång tid.
        {
            string pictureIntro = "C:\\Users\\OliverApelqvistEriks\\source\\repos\\casinoDaddy2\\images\\";
            List<string> pictures = new List<string>() {"1.png", "2.png", "3.png"};
            
            Random random = new Random();

            // random slots-generering (numren)           
            

            






        }
    }

}
