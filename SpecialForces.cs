using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapa
{
    class SpecialForce

    {
        bool lewo, prawo, gaz, hamulec;
        double speed = 5;

        public double X { get; set; }
        public double Y { get; set; }
        public double V { get; set; }
        public double Kierunek { get; set; }
        public bool Lewo { get => lewo; set => lewo = value; }
        public bool Prawo { get => prawo; set => prawo = value; }
        public bool Gora { get => gaz; set => gaz = value; }
        public bool Dol { get => hamulec; set => hamulec = value; }

        Image obraz;
        public SpecialForce()
        {
            obraz = Bitmap.FromFile(@"Images\up.png");

        }
        public void Rysuj(Graphics g)
        {
            var m = g.Transform;
            g.TranslateTransform((float)X, (float)Y);
     
          
            g.ScaleTransform(0.5f, 0.5f);
            g.DrawImage(obraz, -obraz.Width / 2, -(float)obraz.Height/2);
            g.Transform = m;
        }
   
        public void Dzialaj(double dt)
        {
           
           
            if (lewo)
            {

               X-= speed;
                obraz = Bitmap.FromFile(@"Images\left.png");
                    
            }
            
            if (prawo)
            {
                 X += speed;
                obraz = Bitmap.FromFile(@"Images\right.png");
            }
            if (Gora)
            {
                Y -= speed;
                obraz = Bitmap.FromFile(@"Images\up.png");
            }
            if (Dol)
            {
                Y += speed;
                obraz = Bitmap.FromFile(@"Images\down.png");
            }
   
        }
        

    }
}
