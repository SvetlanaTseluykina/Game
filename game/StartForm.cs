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
    public partial class StartForm : Form
    {
        private Dictionary<string, string> loginMap = new Dictionary<string, string>();
        private List<Player> playersStatistics = new List<Player>();

        public StartForm()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;
        }

        private void SetUpGame(Player player)
        {
            PlayForm playForm = new PlayForm(player, this);
            playForm.Show();
            this.Visible = false;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrWhiteSpace(textBox1.Text) 
                || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorProvider1.SetError(BtnLogin, "Enter correct data!");
            }
            else
            {
                if (loginMap.ContainsKey(textBox2.Text))
                {
                    if (loginMap.ContainsValue(textBox1.Text))
                    {
                        for (int i = 0; i < playersStatistics.Count(); i++)
                        {
                            if (playersStatistics[i].GetName == textBox1.Text)
                            {
                                Player player = playersStatistics[i];
                                SetUpGame(player);
                                break;
                            }
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(BtnLogin, "Enter correct login!");
                    }
                }
                else if (loginMap.ContainsValue(textBox1.Text))
                {
                    errorProvider1.SetError(BtnLogin, "Enter correct password!");
                }
                else
                {
                    Player player = new Player(textBox1.Text);
                    loginMap.Add(textBox2.Text, textBox1.Text);
                    playersStatistics.Add(player);
                    SetUpGame(player);
                }
            }
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private int ComparePlayer (Player player1, Player player2)
        {
            if (player1.Score < player2.Score)
            {
                return 1;
            }
            else if (player1.Score == player2.Score)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        private void BtnStat_Click(object sender, EventArgs e)
        {
            playersStatistics.Sort(ComparePlayer);
            richTextBox1.Text = "";
            for (int i = 0; i < playersStatistics.Count(); i++)
            {
                string res = playersStatistics[i].GetName + " " + playersStatistics[i].Score;
                richTextBox1.Text += res + "\n";
            }
        }

        private void BtnForgot_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(BtnLogin, "");
            ForgotPassword forgotPassword = new ForgotPassword(loginMap, this);
            forgotPassword.Show();
            this.Visible = false;
        }
    }
}
