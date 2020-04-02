using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace game
{
    class Ufo : EnemyType
    {

        private Point point;
        private Size size;
        private int veloX;
        private readonly int veloY;
        private bool notKilled = false;
        private bool bluster = false;

        public Ufo(Form1 form1, int rch)
        {
            Random random = new Random(rch);
            point.X = random.Next(10, form1.Width - 100);
            point.Y = random.Next(10, form1.Height / 10);
            size.Width = random.Next(20, 50);
            size.Height = size.Width * 2 / 3;
            veloX = random.Next(10) - 5;
            veloY = random.Next(3, 10);
            HatchBrush = form1.BrushColor.NewEnemyBrush(rch);
            BlusterPen = new Pen(new HatchBrush
                (HatchStyle.DashedUpwardDiagonal, Color.Yellow,
                Color.Yellow), 3);
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
            Point point = new Point();
            Size size = new Size();
            point.X = this.point.X;
            point.Y = this.point.Y + this.size.Height / 4;
            size.Width = this.size.Width;
            size.Height = this.size.Height / 2;
            Rectangle rectangle = new Rectangle(point, size); 
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse(rectangle);
            Region region = new Region(graphicsPath);
            rectangle.X = this.point.X + this.size.Width / 4;
            rectangle.Y = this.point.Y;
            rectangle.Width = this.size.Width / 2;
            rectangle.Height = this.size.Height;
            graphicsPath.AddEllipse(rectangle);
            region.Union(graphicsPath);
            return region;
        }
        
        public override void MoveEnemy(Player player, int count)
        {
            if (point.Y + veloY >= Form1.ActiveForm.Height - 30)
            {
                notKilled = true;
            }
            else
            {
                if (point.X >= Form1.ActiveForm.Width - 50 || point.X < 0)
                {
                    veloX = -veloX;
                }

                point.X += veloX;
                point.Y += veloY;
                Region = FormEnemy();

                if (player.GetPoint.Y <= point.Y 
                    && player.GetPoint.Y + player.GetSize.Height >= size.Height + point.Y 
                    && player.GetPoint.X - player.GetSize.Width <= point.X 
                    && player.GetPoint.X + player.GetSize.Width >= size.Width + point.X 
                    && count == 3)
                {
                    player.Life -= 1;
                }
            }
        }
        public override bool Life { get; set; } = true;

        public Point GetPoint()
        {
            return point;
        }

        public Pen BlusterPen { get; }

        public bool Bluster
        {
            get { return bluster; }
            set { bluster = value; }
        }
    }
}
