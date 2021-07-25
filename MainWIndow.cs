using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mapa
{
    public partial class MainWIndow : Form
    {
     
        public MainWIndow()
        {
            InitializeComponent();
        }

        private void pomocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        double obliczone;
        bool loading;
        private void Oblicz()
        {
            loading = true;
            double wynik = 0;
            for (int i = 0; i < 100000000; i++)
            {
                wynik = +Math.Sin((double)i / 100000);
                if( i%1000000==0)
                {
                    progressBarL.Value = i / 1000000;
                    UstawPostep(i / 1000000);
                }
            }
            obliczone = wynik;
            loading = false;

        }
      private void UstawPostep(int procent)
        {
            if(progressBarL.InvokeRequired)
            {
                Action<int> a = UstawPostep;
                progressBarL.Invoke(a, procent);
            }
            else
            {
                progressBarL.Value = procent;
            }
        }

        private void NowaGra_Click(object sender, EventArgs e)
        {
            Form1 document = new Form1();

            document.Show();
        }

        private void progressBarL_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(Oblicz);
            t.IsBackground = true;
            t.Start();
        }
    }
}
