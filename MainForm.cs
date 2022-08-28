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
    public partial class MainForm : Form
    {
        Secrets secrets = new Secrets();
        HttpClient AssetRetriever = new HttpClient();
        Form subform;
        public string Username;

        void closing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        public MainForm(string username)
        {
            AssetRetriever.DefaultRequestHeaders.Add("X-Master-Key", secrets.MasterKey);
            AssetRetriever.DefaultRequestHeaders.Add("X-Access-Key", secrets.ApiKey);
            AssetRetriever.DefaultRequestHeaders.Add("X-Bin-Meta", "false");
            Username = username;
            InitializeComponent();
            addNewSubForm(new InputForm(this));
            this.FormClosing += new FormClosingEventHandler(closing);
        }

        public void addNewSubForm(Form frm)
        {
            if (subform != null)
            {
                Display.Controls.Clear();
                subform.Dispose();
            }
            subform = frm;
            subform.Dock = DockStyle.Fill;
            subform.TopLevel = false;
            subform.FormBorderStyle = FormBorderStyle.None;
            subform.Visible = true;
            Display.Controls.Add(subform);
        }

        private void BtnNewAsset_Click(object sender, EventArgs e)
        {
            addNewSubForm(new InputForm(this));
        }

        private async void BtnViewAssets_Click(object sender, EventArgs e)
        {
            string Clientdata = "";
            try
            {
                Clientdata = await AssetRetriever.GetStringAsync(secrets.InfoBin + "/latest");
            }
            catch (HttpRequestException) { }

            Dictionary<string, Clientdata> data = JsonConvert.DeserializeObject<Dictionary<string, Clientdata>>(Clientdata);
            if (data[Username].assets.Count != 0)
            {
                addNewSubForm(new ViewAssets(data[Username]));
            }
            else
            {
                MessageBox.Show("Please add an asset before you start viewing");
                return;
            }
        }
    }
}
