﻿using System.Windows.Forms;

namespace ProductCatalog.Model.Entity
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }



        public ListViewItem.ListViewSubItem ToListViewSubItem()
        {
        
            return new ListViewItem.ListViewSubItem(null, $"{ProductId}");
        }
    }
}
