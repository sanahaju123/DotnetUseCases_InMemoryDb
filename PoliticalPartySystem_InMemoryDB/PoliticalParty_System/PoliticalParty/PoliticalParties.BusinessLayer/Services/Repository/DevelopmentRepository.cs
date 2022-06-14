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
            try
            {
                var result = _politicalPartiesDbContext.Developments.
                Where(x => x.PoliticalLeaderId==politicalLeaderId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Development> FindDevelopmentById(long developmentId)
        {
            try
            {
                return await _politicalPartiesDbContext.Developments.FindAsync(developmentId);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<IEnumerable<Development>> ListAllDevelopment()
        {
            try
            {
                var result = _politicalPartiesDbContext.Developments.
                OrderByDescending(x => x.DevelopmentId).Take(10).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Development> Register(Development development)
        {
            try
            {
                var result = await _politicalPartiesDbContext.Developments.AddAsync(development);
                await _politicalPartiesDbContext.SaveChangesAsync();
                return development;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Development> UpdateDevelopment(RegisterDevelopmentViewModel model)
        {
            var development = await _politicalPartiesDbContext.Developments.FindAsync(model.DevelopmentId);
            try
            {
                development.Title = model.Title;
                development.Activity = model.Activity;
                development.Budget = model.Budget;
                development.PoliticalLeaderId = model.PoliticalLeaderId;
                development.ActivityMonth = model.ActivityMonth;
                development.ActivityYear = model.ActivityYear;
                development.IsDeleted = model.IsDeleted;

                _politicalPartiesDbContext.Developments.Update(development);
                await _politicalPartiesDbContext.SaveChangesAsync();
                return development;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}