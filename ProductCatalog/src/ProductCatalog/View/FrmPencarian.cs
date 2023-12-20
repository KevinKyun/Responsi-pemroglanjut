using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace ProductCatalog.View
{
    public partial class FrmPencarian : Form
    {
        private const string BaseUrl = "http://responsi.coding4ever.net:5555/";
        private readonly RestClient _restClient;

        public FrmPencarian()
        {
            InitializeComponent();
            InisialisasiListView();
            cmbFilter.SelectedIndex = 0;
            _restClient = new RestClient(BaseUrl);
        }

        private void InisialisasiListView()
        {
            lvwProduct.View = System.Windows.Forms.View.Details;
            lvwProduct.FullRowSelect = true;
            lvwProduct.GridLines = true;

            lvwProduct.Columns.Add("No.", 40, HorizontalAlignment.Center);
            lvwProduct.Columns.Add("Product Id", 120, HorizontalAlignment.Left);
            lvwProduct.Columns.Add("Product Name", 200, HorizontalAlignment.Left); 
            lvwProduct.Columns.Add("Stock", 40, HorizontalAlignment.Center);
            lvwProduct.Columns.Add("Price", 70, HorizontalAlignment.Right);
            lvwProduct.Columns.Add("Category", 100, HorizontalAlignment.Left); 
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            string filterValue = txtKeyword.Text;
            string filterField = cmbFilter.SelectedItem.ToString();

            List<Product> products = SearchProducts(filterField, filterValue);

            TampilkanData(products);
        }

        private void TampilkanData(List<Product> products)
        {
            Console.WriteLine($"Jumlah produk: {products.Count}"); 
            lvwProduct.Items.Clear();

            foreach (var product in products)
            {
                ListViewItem item = new ListViewItem(product.ProductId.ToString());
                item.SubItems.Add(product.ProductName);
                item.SubItems.Add(product.Stock.ToString());
                item.SubItems.Add(product.Price.ToString("C"));
                item.SubItems.Add(product.Category);
                lvwProduct.Items.Add(item);
            }
        }

        private List<Product> SearchProducts(string filterField, string filterValue)
        {
            var request = new RestRequest("api/product", Method.GET);
            request.AddParameter(filterField, filterValue);

            var response = _restClient.Execute<List<Product>>(request);

            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine($"Response Content: {response.Content}");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Data ?? new List<Product>();
            }
            else
            {
                MessageBox.Show($"Error: {response.StatusCode}");
                return new List<Product>();
            }
        }


        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
      
        }

        private void FrmPencarian_Load(object sender, EventArgs e)
        {
    
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
  
        }

        private void lvwProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public class Product
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int Stock { get; set; }
            public decimal Price { get; set; }
            public string Category { get; set; }
        }
    }
}
