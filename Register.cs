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
    public partial class Register : Form
    {
        Secrets secrets = new Secrets();
        HttpClient AccRetriever = new HttpClient();
        Login login;
        public Register(Login loginPage)
        {
            login = loginPage;
            AccRetriever.DefaultRequestHeaders.Add("X-Master-Key", secrets.MasterKey);
            AccRetriever.DefaultRequestHeaders.Add("X-Access-Key", secrets.ApiKey);
            AccRetriever.DefaultRequestHeaders.Add("X-Bin-Meta", "false");
            InitializeComponent();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var key = secrets.key;

            if (txtPass.Text == "" || txtUsername.Text == "")
            {
                MessageBox.Show("Please enter a password and username");
                return;
            }
            string pass = AesOperation.EncryptString(key, txtPass.Text);

            string accs = "";
            try
            {
                accs = await AccRetriever.GetStringAsync(secrets.LoginsBin + "/latest");
            }
            catch (HttpRequestException) { }

            Dictionary<string, string> logins = JsonConvert.DeserializeObject<Dictionary<string, string>>(accs);

            logins.Add(txtUsername.Text, pass);

            try
            {
                StringContent requests = new StringContent(JsonConvert.SerializeObject(logins));
                requests.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                await AccRetriever.PutAsync(secrets.LoginsBin, requests);
            }
            catch (HttpRequestException) { }

            string Clientdata = "";
            try
            {
                Clientdata = await AccRetriever.GetStringAsync(secrets.InfoBin + "/latest");
            }
            catch (HttpRequestException) { }

            Dictionary<string,Clientdata> ClientdataDictionary = JsonConvert.DeserializeObject<Dictionary<string,Clientdata>>(Clientdata);

            ClientdataDictionary.Add(txtUsername.Text, new Clientdata(txtUsername.Text));

            try
            {
                StringContent requests = new StringContent(JsonConvert.SerializeObject(ClientdataDictionary));
                requests.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                await AccRetriever.PutAsync(secrets.InfoBin, requests);
            }
            catch (HttpRequestException) { }

            login.Show();
            this.Close();
        }
    }
}
