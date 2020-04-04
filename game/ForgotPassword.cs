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
    public partial class ForgotPassword : Form
    {
        private Dictionary<string, string> loginMap;
        private StartForm startForm;
        public ForgotPassword(Dictionary<string, string> loginMap, StartForm startForm)
        {
            InitializeComponent();
            this.loginMap = loginMap;
            this.startForm = startForm;
            textBox2.UseSystemPasswordChar = true;
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(BtnConfirm, "");
            if (loginMap.ContainsValue(textBox1.Text))
            {
                foreach(KeyValuePair<string, string> keyValue in loginMap)
                {
                    if (keyValue.Value.Equals(textBox1.Text))
                    {
                        loginMap.Remove(keyValue.Key);
                        loginMap.Add(textBox2.Text, keyValue.Value);
                        break;
                    }
                }
                startForm.Show();
                this.Close();
            }
            else
            {
                errorProvider1.SetError(BtnConfirm, "Incorrect login, try again!");
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            startForm.Show();
            this.Close();
        }
    }
}
