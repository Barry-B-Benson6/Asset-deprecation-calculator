using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;

using EncryptionDecryptionUsingSymmetricKey;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Asset_deprecation_calc
{
    public partial class InputForm : Form
    {
        Secrets secrets = new Secrets();
        MainForm home;
        HttpClient AssetRetriever = new HttpClient();
        public InputForm(MainForm frm)
        {
            InitializeComponent();
            AssetRetriever.DefaultRequestHeaders.Add("X-Master-Key", secrets.MasterKey);
            AssetRetriever.DefaultRequestHeaders.Add("X-Access-Key", secrets.ApiKey);
            AssetRetriever.DefaultRequestHeaders.Add("X-Bin-Meta", "false");
            home = frm;
        }

        private async void BtnAddAsset_Click(object sender, EventArgs e)
        {
            string assetName;
            double salvageCost;
            int lifeSpan;
            DateTime datePurchased;
            string description;
            double Cost;
            try
            {
                assetName = txtName.Text;
                salvageCost = double.Parse(txtSalvageCost.Text);
                lifeSpan = int.Parse(txtLifeSpan.Text);
                datePurchased = DatePicker.Value;
                description = txtDescription.Text;
                Cost = double.Parse(txtCost.Text);
            }
            catch
            {
                MessageBox.Show("Please check all information is inputted correctly");
                return;
            }

            Asset assetToAdd = new Asset();
            assetToAdd.cost = Cost;
            assetToAdd.Name = assetName;
            assetToAdd.DatePurchased = datePurchased;
            assetToAdd.Salvagevalue = salvageCost;
            assetToAdd.LifeSpan = lifeSpan;
            assetToAdd.Description = description;

            string Clientdata = "";
            try
            {
                Clientdata = await AssetRetriever.GetStringAsync(secrets.InfoBin + "/latest");
            }
            catch (HttpRequestException) { }

            Dictionary<string,Clientdata> data = JsonConvert.DeserializeObject<Dictionary<string,Clientdata>>(Clientdata);

            Console.WriteLine(home.Username);
            Console.WriteLine(data[home.Username].assets);

            data[home.Username].assets.Add(assetToAdd);

            try
            {
                StringContent requests = new StringContent(JsonConvert.SerializeObject(data));
                requests.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                await AssetRetriever.PutAsync(secrets.InfoBin, requests);
            }
            catch (HttpRequestException) { }

            txtCost.Clear();
            txtDescription.Clear();
            txtLifeSpan.Clear();
            txtName.Clear();
            txtSalvageCost.Clear();

            MessageBox.Show("Asset added");
        }
    }
}
