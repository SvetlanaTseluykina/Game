using System;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace game
{
    class Enemy
    {
        private const int nGeneration = 10;
        private int n;
        private readonly EnemyType[] enemy;
        private int maxEnemy;

        public Enemy(EnemyType[] enemyType, int maxEnemy) 
        {
            this.maxEnemy = maxEnemy;
            DeltaN = this.maxEnemy / nGeneration;
            KGeneration = 0;
            n = 0;
            enemy = enemyType;
        }

        public int GetMaxEnemies()
        {
            return maxEnemy;
        }
        public void SetN(int value)
        { n = value; }

        public int GetN()
        {
            return n;
        }

        public int KGeneration { get; set; }

        public int DeltaN { get; }

        public int NGeneration
        {
            get { return nGeneration; }
        }
      
        public void ShowEnemies(Form1 form1, Player player, int count)
        {
            for (int i = 0; i < n; i++)
            {
                if (player.Life == 0)
                {
                    break;
                }
                enemy[i].MoveEnemy(player, count);
                form1.Graphics.FillRegion(enemy[i].HatchBrush, enemy[i].Region);
            }
        }
        
        public void EnemyBatch(Form1 form1, string enemyType)
        {
            int copyN = n;
            n += DeltaN;
            int rch;
            Random random = new Random();
            for (int i = copyN; i < n; i++)
            {
                rch = random.Next();
                if (enemyType.Equals("Ufo"))
                {
                    enemy[i] = new Ufo(form1, rch);
                }
                else if (enemyType.Equals("Asteroid"))
                {
                    enemy[i] = new Asteroid(form1, rch);
                }
                form1.Graphics.FillRegion(enemy[i].HatchBrush, enemy[i].Region);
            }

        }
        public void KilledEnemies(Form1 form1, int x, int y)
        {
            for (int i = 0; i < n; i++)
            {
                Rectangle rectangle = new Rectangle(x - enemy[i].Size.Width / 4, 0, enemy[i].Size.Width / 4 - 2, y);
                if (enemy[i].Region.IsVisible(rectangle, form1.Graphics) && form1.GetLaser())
                {
                    enemy[i].HatchBrush = new HatchBrush(HatchStyle.DarkHorizontal, form1.BrushColor.KilledEnemy, form1.BrushColor.KilledEnemy);
                    form1.Graphics.FillRegion(enemy[i].HatchBrush, enemy[i].Region);
                    enemy[i].Life = false;
                }
            }
        }
        public int CountKilledEnemies()
        {
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                if (!enemy[i].Life)
                    k++;
            }
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (!enemy[j].Life)
                    {
                        for (int copyJ = j; copyJ < (n - 1); copyJ++)
                            enemy[copyJ] = enemy[copyJ + 1];
                        break;
                    }
                }
                n--;
            }
            return k;
        }

        public int CountNotKilledEnemies()
        {
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (enemy[i].GetNotKilledEnemy())
                {
                    count++;
                }
            }
            return count;
        }

        public EnemyType GetEnemyTypeByIndex(int index)
        {
            return enemy[index];
        }

    }
}
