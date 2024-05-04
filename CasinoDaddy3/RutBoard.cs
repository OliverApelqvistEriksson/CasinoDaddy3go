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
using System.Security.Cryptography.X509Certificates;


namespace CasinoDaddy3
{
    internal class RutBoard
    {
        private Form1 parentForm;

        string pictureIntro = "C:\\Users\\OliverApelqvistEriks\\source\\repos\\casinoDaddy2\\images\\";
        string startImage = "C:\\Users\\OliverApelqvistEriks\\source\\repos\\casinoDaddy2\\images\\red.jpg";
        List<string> spinPictures = new List<string>() { "1.png", "2.png", "3.png", "red.jpg" };
        List<string> pictures = new List<string>() { "1.png", "2.png", "3.png" };

        //  List <int[]> combos = new List<int[]>()

        private void setImage(int slotNumber, string image) {
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

        private void setImages(string image)
        {
            for (int y = 1; y <= 15; y++)
            {
                string bild = image;
                setImage(y, bild);
            }
        }

        public RutBoard(Form1 form) {
            parentForm = form;
            setImages(startImage);
        }

        private void runAnimation() // fungerar ej för tillfället, behöver kunna delaya bilder, är dock inte prio 1.
        {

            for (int x = 0; x < 4; x++)
            {
                Console.WriteLine(x);
                setImages(pictureIntro + spinPictures[x]);
            }
        }

        private void winAnimation() //behöver få in argument att behandla, prio 2.
        {
        }


        public int[] spinAndGetSlots() // kan behöva lägga in för att disabla knappen under spin, om det tar lång tid.
        {
            int[] rutBoardIds = new int[15];

            Random random = new Random(); // random slots-generering (numren)           
            for (int x = 1; x <= 15; x++)
            {
                rutBoardIds[x-1] = random.Next(pictures.Count());
                setImage(x, pictureIntro + pictures[rutBoardIds[x-1]]);
            }
            return rutBoardIds; 
        }
    }

}
