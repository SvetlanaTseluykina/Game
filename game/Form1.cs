using System;
using System.Drawing;
using System.Windows.Forms;

namespace game
{

    public partial class Form1 : Form
    {
        private int nMAX;
        private const bool LASER_OFF = false;
        private Player player;
        private Bitmap imageP;
        private int result = 0;
        private Enemy ufo;
        private Enemy asteroid;
        private const int PLAYER_WIDTH = 100;
        private const int PLAYER_HEIGHT = 100;
        private PlayForm playForm;
        private int count = 0;
        private const int COUNT_MAX = 3;
        private int timer1Tick;
        private int timer3Tick;
        private const int TIMER2_TICK = 5000;

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(int nMAX, int timer1Tick, int timer3Tick, PlayForm playForm, Player player)
        {
            InitializeComponent();
            this.nMAX = nMAX;
            this.timer1Tick = timer1Tick;
            timer1.Interval = this.timer1Tick;
            this.playForm = playForm;
            this.timer3Tick = timer3Tick;
            timer3.Interval = this.timer3Tick;
            timer2.Interval = TIMER2_TICK;
            this.player = player;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Graphics = CreateGraphics();
            BackColor = BrushColor.FonColor;
            imageP = new Bitmap(imageList1.Images[0], PLAYER_WIDTH, PLAYER_HEIGHT);
            ufo = new Enemy(new Ufo[nMAX], nMAX);
            asteroid = new Enemy(new Asteroid[nMAX], nMAX);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            timer1.Interval = timer1Tick;
            timer2.Interval = TIMER2_TICK;
            timer3.Interval = timer3Tick;
            player.SetUpPlayer(this);
            player.ShowPlayer(this, this.Width / 2, this.Height - 150);
            textBox2.Text = player.Life.ToString();
            ufo.EnemyBatch(this, "Ufo");
            asteroid.EnemyBatch(this, "Asteroid");
            timer1.Start();
            timer2.Start();
            timer3.Start();
            btnStop.Enabled = true;
            btnLaser.Enabled = true;
            btnStart.Enabled = false;
            //btnExit.Enabled = false;
        }

        private void BtnLaser_Click(object sender, EventArgs e)
        {
            if (GetLaser())
            {
                SetLaser(false);
                btnLaser.Text = "turn on laser";
            }
            else
            {
                SetLaser(true);
                btnLaser.Text = "turn off laser";
            }
        }

        private void ClearBackground()
        {
            Graphics.Clear(BackColor);
        }

        private void ToStart()
        {
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            int percent = result * 100 / (ufo.DeltaN * ufo.NGeneration + asteroid.DeltaN * asteroid.NGeneration);
            string msg = "Killed " + result.ToString() + " enemies, your result in this game is " + percent.ToString() + "%";
            if (player.Life <= 0 || percent < 51)
            {
                MessageBox.Show("You lose! " + msg, "Your result", MessageBoxButtons.OK);
            }
            else
            {
                player.Score += result;
                MessageBox.Show("Congrats! You win! " + msg +
                " Total result is " + player.Score, "Your result", MessageBoxButtons.OK);
            }
            player.ShowPlayer(this, this.Width / 2, this.Height - 150);
            ufo.SetN(0);
            asteroid.SetN(0);
            btnStart.Enabled = true;
            btnExit.Enabled = true;
            btnLaser.Text = "turn on laser";
            btnLaser.Enabled = false;
            btnStop.Enabled = false;
            result = 0;
            textBox1.Text = " ";
            textBox2.Text = " ";
            ufo = new Enemy(new Ufo[nMAX], nMAX);
            asteroid = new Enemy(new Asteroid[nMAX], nMAX);
            SetLaser(false);
            ClearBackground();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            var res = MessageBox.Show("PAUSE", "pause", MessageBoxButtons.OK);
            if (res == DialogResult.OK)
            {
                timer1.Enabled = true;
                timer2.Enabled = true;
                timer3.Enabled = true;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            ClearBackground();
            result += ufo.CountKilledEnemies();
            result += asteroid.CountKilledEnemies();
            if (player.Life <= 0)
            {
                ToStart();
            }
            else if (result + ufo.CountNotKilledEnemies() + asteroid.CountNotKilledEnemies() == ufo.GetMaxEnemies() + asteroid.GetMaxEnemies())
            {
                ToStart();
            }
            else
            {
                if (count == COUNT_MAX)
                {
                    count = 0;
                }
                else
                {
                    count++;
                }
                ufo.ShowEnemies(this, player, count);
                asteroid.ShowEnemies(this, player, count);
                textBox1.Text = result.ToString();
                textBox2.Text = player.Life.ToString();
         
            }
            
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            ufo.KGeneration++;
            asteroid.KGeneration++;
            timer2.Interval -= 100;
            if (ufo.KGeneration < ufo.NGeneration && asteroid.KGeneration < asteroid.NGeneration)
            {
                ufo.EnemyBatch(this, "Ufo");
                asteroid.EnemyBatch(this, "Asteroid");
            }
            else
            {
                timer2.Stop();
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (player != null)
                {
                    if (btnStart.Enabled)
                    {
                        player.ShowPlayer(this, ActiveForm.Width / 2, ActiveForm.Height - 150);
                    }
                    else
                    {
                        player.ShowPlayer(this, e.X, e.Y);
                    }
                }
                if (GetLaser())
                {
                    Graphics.DrawLine(player.LaserPen, player.GetPoint.X + player.GetSize.Width / 2,
                        player.GetPoint.Y, player.GetPoint.X + player.GetSize.Width / 2, 0);
                    ufo.KilledEnemies(this, e.X, e.Y);
                    asteroid.KilledEnemies(this, e.X, e.Y);
                }
            }
            catch(Exception)
            {
                
            }
            
        }

        public Bitmap GetBitmap()
        {
            return imageP;
        }

        public BrushColor BrushColor { get; set; } = new BrushColor();

        public Graphics Graphics { get; private set; }

        private bool laser = LASER_OFF;

        public bool GetLaser()
        {
            return laser;
        }

        private void SetLaser(bool value)
        {
            laser = value;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            playForm.Visible = true;
            Close();
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            if (ufo.GetN() > 0)
            {
                Random random = new Random();
                int index = random.Next(0, ufo.GetN());
                Ufo oneUfo = (Ufo)ufo.GetEnemyTypeByIndex(index);
                Graphics.DrawLine(oneUfo.BlusterPen, oneUfo.GetPoint().X + oneUfo.Size.Width / 2, oneUfo.GetPoint().Y + oneUfo.Size.Height, oneUfo.GetPoint().X + oneUfo.Size.Width / 2, ActiveForm.Height);
                oneUfo.Bluster = true;
                Rectangle rectangle = new Rectangle(oneUfo.GetPoint().X + oneUfo.Size.Width / 4,
                                                    oneUfo.GetPoint().Y + oneUfo.Size.Height,
                                                    oneUfo.Size.Width / 2,
                                                    ActiveForm.Height);
                if (player.GetRegion().IsVisible(rectangle, Graphics) && oneUfo.Bluster)
                {
                    player.Life--;
                }
                oneUfo.Bluster = false;
            }       
        }
    }
}
