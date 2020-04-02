using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game
{
    public partial class PlayForm : Form
    {
        int nMax;
        int timer1Tick;
        int timer2Tick;

        public PlayForm()
        {
            InitializeComponent();
        }

        private void PlayForm_Load(object sender, EventArgs e)
        {

        }

        private void SetGame (int nMax, int timerTick)
        {
            timer2Tick = timer1Tick - 20;
            Form1 form = new Form1(nMax, timerTick, timer2Tick, this);
            form.Show();
            this.Visible = false;
        }

        private void BtnEasy_Click(object sender, EventArgs e)
        {
            nMax = 20;
            timer1Tick = 500;
            SetGame(nMax, timer1Tick);
        }

        private void BtnMiddle_Click(object sender, EventArgs e)
        {
            nMax = 30;
            timer1Tick = 400;
            SetGame(nMax, timer1Tick);
        }

        private void BtnHard_Click(object sender, EventArgs e)
        {
            nMax = 50;
            timer1Tick = 200;
            SetGame(nMax, timer1Tick);
        }
    }
}
