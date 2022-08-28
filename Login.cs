using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EncryptionDecryptionUsingSymmetricKey;

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Asset_deprecation_calc
{
    public partial class Login : Form
    {
        Secrets secrets = new Secrets();
        
        HttpClient AccRetriever = new HttpClient();
        public Login()
        {
            AccRetriever.DefaultRequestHeaders.Add("X-Master-Key",secrets.MasterKey);
            AccRetriever.DefaultRequestHeaders.Add("X-Access-Key", secrets.ApiKey);
            AccRetriever.DefaultRequestHeaders.Add("X-Bin-Meta", "false");
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var key = secrets.key;

            string pass = AesOperation.EncryptString(key, txtPass.Text);

            string accs = "";
            try
            {
                accs = await AccRetriever.GetStringAsync(secrets.LoginsBin + "/latest");
            }
            catch (HttpRequestException) { }

            Dictionary<string,string> login = JsonConvert.DeserializeObject<Dictionary<string,string>>(accs);

            if (login.ContainsKey(txtUsername.Text))
            {
                if (login[txtUsername.Text] == pass)
                {
                    MessageBox.Show("Hi " + txtUsername.Text);
                    MainForm mainForm = new MainForm(txtUsername.Text);
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect Login");
                }
            }
        }

        private void btnRegister_MouseClick(object sender, MouseEventArgs e)
        {
            Register registerForm = new Register(this);
            registerForm.Show();
            this.Hide();
        }
    }
}
