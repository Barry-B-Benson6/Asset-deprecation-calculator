using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asset_deprecation_calc
{
    public partial class ViewAssets : Form
    {
        Clientdata data;
        public ViewAssets(Clientdata clientdata)
        {
            data = clientdata;
            InitializeComponent();
        }

        private void ViewAssets_Load(object sender, EventArgs e)
        {
            AssetListBox.Items.Clear();
            data.assets.ForEach(asset =>
            {
                AssetListBox.Items.Add(asset.Name);
            });
            AssetListBox.SelectedIndex = 0;
        }

        private void AssetListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Asset selectedAsset = data.assets[AssetListBox.SelectedIndex];

            lblAssetName.Text = selectedAsset.Name;

            double monthlyDeprication = ((selectedAsset.cost - selectedAsset.Salvagevalue)/selectedAsset.LifeSpan)/12;

            lblMonthlyDeprication.Text = "Monthly Deprication: $" + monthlyDeprication;

            lblDescription.Text = "Asset Description";
            txtDescription.Text = selectedAsset.Description;
            lblDatePurchased.Text = "Date Purchased: " + selectedAsset.DatePurchased.ToString();
            lblDateOfEndOfLife.Text = "End of useful life: " + selectedAsset.DatePurchased.AddYears(selectedAsset.LifeSpan).ToString();
        }
    }
}
