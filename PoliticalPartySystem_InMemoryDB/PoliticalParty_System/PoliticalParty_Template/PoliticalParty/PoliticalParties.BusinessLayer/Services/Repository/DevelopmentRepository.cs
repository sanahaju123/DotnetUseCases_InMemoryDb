using PoliticalParties.BusinessLayer.ViewModels;
using PoliticalParties.DataLayer;
using PoliticalParties.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalParties.BusinessLayer.Services.Repository
{
    public class DevelopmentRepository : IDevelopmentRepository
    {
        private readonly PoliticalPartiesDbContext _politicalPartiesDbContext;
        public DevelopmentRepository(PoliticalPartiesDbContext politicalPartiesDbContext)
        {
            _politicalPartiesDbContext = politicalPartiesDbContext;
        }

        public async Task<IEnumerable<Development>> DevelopmentPlansByPoliticalLeaderId(long politicalLeaderId)
        {
            throw new NotImplementedException();
        }

        public async Task<Development> FindDevelopmentById(long developmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Development>> ListAllDevelopment()
        {
            throw new NotImplementedException();
        }

        public async Task<Development> Register(Development development)
        {
            throw new NotImplementedException();
        }

        public async Task<Development> UpdateDevelopment(RegisterDevelopmentViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}