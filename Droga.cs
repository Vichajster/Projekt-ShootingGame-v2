using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapa
{
   
    class Droga
    {
        public List<PointF> Punkty { get; set; }
        public string Nazwa { get; set; }
     
        Pen asfalt;
        public Droga()
        {
          
            Punkty = new List<PointF>();
     
            asfalt = new Pen(Color.Green, 40);

            asfalt.StartCap = LineCap.Round;
            asfalt.EndCap = LineCap.Round;
            asfalt.LineJoin = LineJoin.Round;


        }
        public void Rysuj(Graphics g)
        {

            g.DrawLines(asfalt, Punkty.ToArray());
          

        }
    }
}
