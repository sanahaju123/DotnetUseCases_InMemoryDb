using PoliticalParties.BusinessLayer.Interfaces;
using PoliticalParties.BusinessLayer.Services.Repository;
using PoliticalParties.BusinessLayer.ViewModels;
using PoliticalParties.DataLayer;
using PoliticalParties.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalParties.BusinessLayer.Services
{
    public class DevelopmentServices : IDevelopmentServices
    {
        private readonly IDevelopmentRepository _developmentRepository;
        private readonly PoliticalPartiesDbContext _politicalPartiesDbContext;
        public DevelopmentServices(IDevelopmentRepository developmentRepository, PoliticalPartiesDbContext politicalPartiesDbContext)
        {
            _developmentRepository = developmentRepository;
            _politicalPartiesDbContext = politicalPartiesDbContext;
        }

        public async Task<IEnumerable<Development>> DevelopmentPlansByPoliticalLeaderId(long politicalLeaderId)
        {
            throw new NotImplementedException();
        }
        public async Task<Development> FindDevelopmentById(long DevelopmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Development>> ListAllDevelopment()
        {
            throw new NotImplementedException();
        }

        public async Task<Development> Register(Development Development)
        {
            throw new NotImplementedException();
        }

        public async Task<Development> UpdateDevelopment(RegisterDevelopmentViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
