using RestSharp;
using System.Collections.Generic;
using System.Net;

namespace ProductCatalog.Model.Repository
{
    public class ProductRestApiRepository
    {
        private const string BaseUrl = "http://responsi.coding4ever.net:5555/";
        private readonly RestClient _restClient;

        public ProductRestApiRepository()
        {
            _restClient = new RestClient(BaseUrl);
        }

        public List<ProductApiResponse> ReadAll()
        {
            var request = new RestRequest("api/product", Method.GET);
            var response = _restClient.Execute<List<ProductApiResponse>>(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Data;
            }
            else
            {
               
                return new List<ProductApiResponse>();
            }
        }

        public List<ProductApiResponse> ReadByProductName(string productName)
        {
            var request = new RestRequest("api/product", Method.GET);
            request.AddParameter("product_name", productName);

            var response = _restClient.Execute<List<ProductApiResponse>>(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Data;
            }
            else
            {
             
                return new List<ProductApiResponse>();
            }
        }

        public List<ProductApiResponse> ReadByCategory(string category)
        {
            var request = new RestRequest("api/product", Method.GET);
            request.AddParameter("category", category);

            var response = _restClient.Execute<List<ProductApiResponse>>(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Data;
            }
            else
            {
            
                return new List<ProductApiResponse>();
            }
        }

        public ProductApiResponse ReadByProductId(string productId)
        {
            var request = new RestRequest($"api/product/{productId}", Method.GET);
            var response = _restClient.Execute<ProductApiResponse>(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Data;
            }
            else
            {
               
                return null;
            }
        }

        public class ProductApiResponse
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int Stock { get; set; }
            public decimal Price { get; set; }
            public string Category { get; set; }
        }
    }
}
