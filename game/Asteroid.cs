using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace game
{
    class Asteroid : EnemyType
    {

        private Point point;
        private Size size;
        private int veloX;
        private bool notKilled = false;
        private int fl;

        public Asteroid(Form1 form1, int rch)
        {
            Random random = new Random(rch);
            fl = random.Next(0, 2);
            if (fl == 0)
            {
                point.X = random.Next(0, form1.Width / 5);
            }
            else
            {
                point.X = random.Next(form1.Width - 300, form1.Width - 50);
            }
            point.Y = random.Next(30, form1.Height / 2 + 100);
            size.Width = random.Next(20, 50);
            size.Height = size.Width * 2 / 3;
            veloX = random.Next(10) + 5;
            HatchBrush = form1.BrushColor.NewEnemyBrush(rch);
            Region = FormEnemy();
        }

        public override Boolean GetNotKilledEnemy()
        {
            return notKilled;
        }
        public override HatchBrush HatchBrush { get; set; }

        public override Region Region { get; set; } = new Region();

        public override Size Size
        {
            get { return size; }
            set { size = value; }
        }

        public override Region FormEnemy()
        {
            Point point2 = new Point();
            Point point3 = new Point();
            point2.X = point.X + size.Width;
            point2.Y = point.Y;
            point3.X = point.X + size.Width / 2;
            point3.Y = point.Y + size.Height;
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddLine(point.X, point.Y, point2.X, point2.Y);
            graphicsPath.AddLine(point2.X, point2.Y, point3.X, point3.Y);
            graphicsPath.AddLine(point3.X, point3.Y, point.X, point.Y);
            Region region = new Region(graphicsPath);
            return region;
        }

        public override void MoveEnemy(Player player, int count)
        {
            if (point.X >= Form1.ActiveForm.Width || point.X + size.Width < 0)
            {
                notKilled = true;
            }
            else
            {
                if (fl == 0)
                {
                    point.X += veloX;
                }
                else
                {
                    point.X -= veloX;
                }
                Region = FormEnemy();
                if (player.GetPoint.Y <= point.Y && player.GetPoint.Y + player.GetSize.Height >= size.Height + point.Y && player.GetPoint.X - player.GetSize.Width <= point.X && player.GetPoint.X + player.GetSize.Width >= size.Width + point.X && count == 3)
                {
                    player.Life = player.Life - 1;
                }
            }
        }
            
       

        public override bool Life { get; set; } = true;
    }
}
