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


        private string pictureIntro = "C:\\Users\\OliverApelqvistEriks\\source\\repos\\casinoDaddy2\\images\\"; //alla bilder ligger i en fil på datorn, vilket gör att man enkelt kan använda denna för att korta ned strings i koden. 
        private string startImage = "red.jpg"; //startbilden på slotmaskinen
        private List<string> animationPictures = new List<string>() { "1.png", "2.png", "3.png" }; // bilder som inkluderas i animationen, är endast dessa just nu för simplisitet men bör kunna vara vilka som helst (helst några som ser ut som ett "bildspel")
        private List<string> pictures = new List<string>() { "1.png", "2.png", "3.png", "4.png", "5.png" }; //bilderna som randomisas i slots:en . Dessa två är listor för att man enkelt ska kunna addera eller ta bort bilder.

        private void setImage(int slotNumber, string image) // sätter en av slots-en (enligt slotNumret) till en av bilderna (som länkas i form av en string)
        { 
            try // det den gör är att den ställer in bilden i Form(design)
            {
                System.Drawing.Image slotBild = System.Drawing.Image.FromFile(image); //Den tar string-en och hittar bilden länkad genom den (path till en fil)
                PictureBox bildBox = (PictureBox)parentForm.Controls.Find("slot" + (slotNumber).ToString(), true)[0]; //Sedan hittar den en pictureBox med namnet slot - följt av ett nummer.
                bildBox.Image = slotBild; //och sist skickar den den path-ade bilden till bildBoxen.
            }
            catch (Exception) // om den inte funkar så visar den vilken slot den inte funkar på
            {
                MessageBox.Show("fel i slots-generering på " + (slotNumber).ToString());
            }
        }

        private void setImages(string image) //sätter varje bild, väldigt bra för introt och animationerna
        {
            for (int y = 1; y <= 15; y++)
            {
                string bild = image;
                setImage(y, bild);
            }
        }

        public RutBoard(Form1 form) //när rutBoard instansieras skapas en variabel för parentForm, vilket tillåter RutBoard att ändra i design.
        {
            parentForm = form;
            setImages((pictureIntro + startImage)); //sedan sätts bilderna till startImage (den röda).
        }

        private async Task runAnimation() // fungerar ej för tillfället, behöver kunna delaya bilder, är dock inte prio 1.
        {
            for (int i = 0; i < animationPictures.Count; i++)
            {
                setImages(pictureIntro + animationPictures[i]);
                await Task.Delay(100); 
            }
        }

        private void winAnimation(List<int> comboNumbers ) //behöver få in argument att behandla, inte klar än.
        {
            //borde dock vara mycket enklare pga att man kan köra den här efter allt annat, vilket alltså inte ger interference vilket gör att man kanske kan använda Thread.sleep eller den andra.
        }


        public int[] spinAndGetSlots() // kan behöva lägga in för att disabla knappen under spin, om det tar lång tid.
        {
            int[] rutBoardIds = new int[15];

 //           Task startAnimation = runAnimation(); (fungerar inte än)
   //         startAnimation.Wait();

            Random random = new Random(); // random slots-generering (numren)           
            for (int x = 0; x < 15; x++) //Den gör 15 random slots
            {
                rutBoardIds[x] = random.Next(pictures.Count()); //den gör ett random-nummer upp till antalet bilder 
                setImage(x+1, pictureIntro + pictures[rutBoardIds[x]]); //sedan fixar den varje bild
            }
            return rutBoardIds; //och den returnerar en array av bilder, eftersom det behövs för att bestämma combos.
        }
    }

}
