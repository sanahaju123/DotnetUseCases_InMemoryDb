using Online_Auction.BusinessLayer.Interfaces;
using Online_Auction.BusinessLayer.Services.Repository;
using Online_Auction.BusinessLayer.ViewModels;
using Online_Auction.DataLayer;
using Online_Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Auction.BusinessLayer.Services
{
    public class ProductServices:IProductServices
    {
        private readonly IProductRepository _productRepository;
        public ProductServices(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> FindProductById(long productId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryId(long categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProductBySellerId(long sellerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> ListAllProducts()
        {
            throw new NotImplementedException();
        }

        public async Task<Product> Register(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> UpdateProduct(RegisterProductViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
