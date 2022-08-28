using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset_deprecation_calc
{
    public class Clientdata
    {
        public string Name { get; set; }
        public List<Asset> assets = new List<Asset>();

        public Clientdata(string name)
        {
            Name = name;
        }
    }

    public class Asset
    {
        public string Name { get; set; }
        public double cost { get; set; }
        public string Description { get; set; }
        public double Salvagevalue { get; set; }
        public int LifeSpan { get; set; }
        public DateTime DatePurchased { get; set; }
    }
}
