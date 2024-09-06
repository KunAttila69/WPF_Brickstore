using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp11
{
    internal class Lego
    {
        string itemID;
        string itemName;
        string categoryName;
        string colorName;
        int qty;

        public Lego(string itemID, string itemName, string categoryName, string colorName, int qty)
        {
            this.itemID = itemID;
            this.itemName = itemName;
            this.categoryName = categoryName;
            this.colorName = colorName;
            this.qty = qty;
        }

        public string ItemID { get => itemID; set => itemID = value; }
        public string ItemName { get => itemName; set => itemName = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }
        public string ColorName { get => colorName; set => colorName = value; }
        public int Qty { get => qty; set => qty = value; }
    }
}
