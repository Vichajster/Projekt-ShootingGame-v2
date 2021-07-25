using Mapa.MapaDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mapa
{
    public partial class Form1 : Form
    {

        //zastąp pojedynczą drogę listą dróg
        List<Droga> drogi = new List<Droga>();
        SpecialForce Wojownik;
        List<SpecialForce> Soldiers;
        public Form1()
        {
            Random rd = new Random(this.GetHashCode());
            Soldiers = new List<SpecialForce>();
            for (int i = 0; i < 40; i++)
            {
                Soldiers.Add(new SpecialForce() { X = rd.Next(-500, 500), Y = rd.Next(-500, 500) });
            }

            SpecialForce wojownik = Wojownik;
            Wojownik = new SpecialForce();
            Wojownik.X = 400;
            Wojownik.Y = 400;
           
         
            LadujDane();
            InitializeComponent();
        }

        private void LadujDane()
        {

            MapaDataSet mapa = new MapaDataSet();
            UliceTableAdapter uliceTA = new UliceTableAdapter();
            PunktyUlicyTableAdapter punktyTA = new PunktyUlicyTableAdapter();

            uliceTA.Fill(mapa.Ulice);
            foreach (var UlicaRow in mapa.Ulice)
            {
                Droga nowa = new Droga();

                nowa.Nazwa = UlicaRow.Nazwa;

                foreach (var punktRow in punktyTA.GetDataBystret())
                {
                    nowa.Punkty.Add(new PointF(punktRow.X, punktRow.Y));
                }


                drogi.Add(nowa);

            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TranslateTransform(Width/2 , Height /2 );
            e.Graphics.ScaleTransform(skala, skala);
            e.Graphics.TranslateTransform(-(float)Wojownik.X, -(float)Wojownik.Y);
            drogi.ForEach(u => u.Rysuj(e.Graphics));

            Wojownik.Rysuj(e.Graphics);
            
            sw.Stop();
            Text = "FPS:" + (1 / sw.Elapsed.TotalSeconds).ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {



            

            Wojownik.Dzialaj(0.04);
            Rectangle r = new Rectangle((int)(skala * (Wojownik.X - 40)), (int)(skala * (Wojownik.Y - 40)), (int)skala * 80, (int)skala * 80);

            //Invalidate(r);
            Invalidate(this.ClientRectangle);
        }

        float skala = 2;
        string facing = "up";
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                Wojownik.Lewo = true;
                facing = "left";
               
            }
            if (e.KeyCode == Keys.Right)
            {
                Wojownik.Prawo = true;
                 facing = "right";
            }
            
            if (e.KeyCode == Keys.Up) { 
                Wojownik.Gora = true;
                facing = "up";
            }

            if (e.KeyCode == Keys.Down)
            {
                Wojownik.Dol = true;
                facing = "down";
            }
            if (e.KeyCode == Keys.Space && e.KeyCode != Keys.Left)
            {
                Strzelaj(facing);
            };
            if (e.KeyCode == Keys.Space && e.KeyCode != Keys.Right)
            {
                Strzelaj(facing);
            }; 
            if (e.KeyCode == Keys.Space && e.KeyCode != Keys.Up)
            {
                Strzelaj(facing);
            }; 
            if (e.KeyCode == Keys.Space && e.KeyCode != Keys.Down)
            {
                Strzelaj(facing);
            }; 
            if (e.KeyCode == Keys.PageUp) { skala *= 2; Refresh(); }
            if (e.KeyCode == Keys.PageDown) { skala /= 2; Refresh(); }
        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) Wojownik.Lewo = false;
            if (e.KeyCode == Keys.Right) Wojownik.Prawo = false;
            if (e.KeyCode == Keys.Up) Wojownik.Gora = false;
            if (e.KeyCode == Keys.Down) Wojownik.Dol = false;
         
        


        }
        private void Strzelaj(string direction)
        {
            Naboje StrzelajNabojem = new Naboje();
            StrzelajNabojem.direction = direction;
      
            
                      StrzelajNabojem.bulletLeft = (int)(Wojownik.X*0.8 );
            StrzelajNabojem.bulletTop = (int)(Wojownik.Y / 2.2);
            StrzelajNabojem.MakeBullet(this);
            Refresh();
        }
    }
}
