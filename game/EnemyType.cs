using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    abstract class EnemyType
    {

        public abstract Region FormEnemy();

        public abstract void MoveEnemy(Player player, int count);

        public abstract HatchBrush HatchBrush { get; set; }

        public abstract Boolean GetNotKilledEnemy();

        public abstract bool Life { get; set; }

        public abstract Region Region { get; set; }

        public abstract Size Size { get; set; }
    }
}
