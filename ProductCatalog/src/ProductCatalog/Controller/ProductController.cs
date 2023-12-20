using System.Collections.Generic;
using ProductCatalog.Model.Repository;

namespace ProductCatalog.Controller
{
    public class ProductController
    {
        private ProductRestApiRepository _repository;

        public ProductController()
        {
            _repository = new ProductRestApiRepository();
        }

        public List<ProductRestApiRepository.ProductApiResponse> ReadAll()
        {
            return _repository.ReadAll();
        }

        public List<ProductRestApiRepository.ProductApiResponse> ReadByProductName(string productName)
        {
            return _repository.ReadByProductName(productName);
        }

        public List<ProductRestApiRepository.ProductApiResponse> ReadByCategory(string category)
        {
            return _repository.ReadByCategory(category);
        }

        public ProductRestApiRepository.ProductApiResponse ReadByProductId(string productId)
        {
            return _repository.ReadByProductId(productId);
        }
    }
}
