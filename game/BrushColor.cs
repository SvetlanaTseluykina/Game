using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace game
{
    public class BrushColor
    {
        private readonly Color laserColor;

        public Color FonColor { get; set; }

        public Color KilledEnemy { get; }

        public Color DashUfo { get; }
        public Color AsteroidColor
        {
            get;
        }

        public BrushColor() {
            FonColor = Color.Black;
            laserColor = Color.Red;
            KilledEnemy = Color.Red;
        }
        public Color RandomColor(int rch)
        {
            int r;
            int g;
            int b;
            byte[] bytes = new byte[3];
            Random random = new Random(rch);
            random.NextBytes(bytes);
            r = Convert.ToInt16(bytes[0]);
            g = Convert.ToInt16(bytes[1]);
            b = Convert.ToInt16(bytes[2]);
            return Color.FromArgb(r, g, b);
        }

        public Color GetLaserColor()
        {
            return laserColor;
        }


        public HatchBrush NewEnemyBrush(int rch)
        {
            return new HatchBrush(HatchStyle.DashedUpwardDiagonal, DashUfo, RandomColor(rch));
        }
    }
}
