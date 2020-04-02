using System.Drawing;
using System.Drawing.Drawing2D;

namespace game
{
    public class Player
    {
        private Point point;
        private Size size;
        private Region region;

        public Player(Form1 form)
        {
            size = form.GetBitmap().Size;
            point.X = 0;
            point.Y = 0;
            Rectangle rectangle = new Rectangle(point, size);
            region = new Region(rectangle);
            LaserPen = new Pen(new HatchBrush
                (HatchStyle.DashedUpwardDiagonal, form.BrushColor.GetLaserColor(),
                form.BrushColor.GetLaserColor()), 5);
        }

        public Region GetRegion()
        {
            return region;
        }

        public int Life { get; set; } = 100;

        public Pen LaserPen { get; }

        public Point GetPoint
        {
            get { return point; }
        }

        public Size GetSize
        {
            get { return size; }
        } 

        public void ShowPlayer(Form1 form, int x, int y)
        {
            form.Graphics.ResetClip();
            form.Graphics.FillRegion(new SolidBrush(form.BackColor), region);
            point.X = x - size.Width / 2;
            point.Y = y;
            Rectangle rectangle = new Rectangle(point, size);
            region = new Region(rectangle);
            form.Graphics.DrawImage(form.GetBitmap(), point);
            form.Graphics.ExcludeClip(region);
        }
    }
}
