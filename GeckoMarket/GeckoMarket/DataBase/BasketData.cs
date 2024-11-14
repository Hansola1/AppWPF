using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GeckoMarket.DataBase
{
    public class BasketData
    {
        public int CatalogID {  get; set; }
        public int TotalCost { get; set; }

        public BasketData(int catalogID, int totalCost)
        {
            CatalogID = catalogID;
            TotalCost = totalCost;
        }
    }
}
