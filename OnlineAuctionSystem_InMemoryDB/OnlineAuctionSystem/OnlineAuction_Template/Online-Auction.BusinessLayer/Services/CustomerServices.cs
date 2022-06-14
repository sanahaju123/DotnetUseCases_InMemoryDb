using Online_Auction.BusinessLayer.Interfaces;
using Online_Auction.BusinessLayer.Services.Repository;
using Online_Auction.BusinessLayer.ViewModels;
using Online_Auction.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Auction.BusinessLayer.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerServices(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Bids>> AllBidsByProductId(long productId)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> FindCustomerById(long customerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> ListAllCustomers()
        {
            throw new NotImplementedException();
        }

        public async Task<Bids> PlaceBid(Bids bids)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> Register(Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> UpdateCustomer(RegisterCustomerViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
