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
            return await _developmentRepository.DevelopmentPlansByPoliticalLeaderId(politicalLeaderId);
        }
        public async Task<Development> FindDevelopmentById(long DevelopmentId)
        {
            return await _developmentRepository.FindDevelopmentById(DevelopmentId);
        }

        public async Task<IEnumerable<Development>> ListAllDevelopment()
        {
            return await _developmentRepository.ListAllDevelopment();
        }

        public async Task<Development> Register(Development Development)
        {
            return await _developmentRepository.Register(Development);
        }

        public async Task<Development> UpdateDevelopment(RegisterDevelopmentViewModel model)
        {
            return await _developmentRepository.UpdateDevelopment(model);
        }
    }
}
