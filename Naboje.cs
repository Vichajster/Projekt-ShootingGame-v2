using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mapa
{
    class Naboje
    {
        public string direction;
        public int bulletLeft;
        public int bulletTop;
        private int speed=5;
        private PictureBox bullet = new PictureBox();
        private Timer bulletTimer = new Timer();
        public void MakeBullet(Form form)
        {
            bullet.BackColor = Color.Red;
            bullet.Size = new Size(5, 5);
            bullet.Tag = "Bullet";
            bullet.Left = bulletLeft;
            bullet.Top = bulletTop;
            bullet.BringToFront();
            form.Controls.Add(bullet);

            bulletTimer.Interval = speed;
            bulletTimer.Tick+=new EventHandler(BulletTimerEvent);
            bulletTimer.Start();
        }
        private void BulletTimerEvent(object sender, EventArgs e)
        {
            if (direction == "left")
            {
                bullet.Left -= speed;
            }
                if(direction =="right")
                {
                bullet.Left += speed;
                }
                if(direction=="up")
                {
                bullet.Top -= speed;
            }
            if(direction=="down")
            {
                bullet.Top += speed;
            }
            
        }
    }
}
