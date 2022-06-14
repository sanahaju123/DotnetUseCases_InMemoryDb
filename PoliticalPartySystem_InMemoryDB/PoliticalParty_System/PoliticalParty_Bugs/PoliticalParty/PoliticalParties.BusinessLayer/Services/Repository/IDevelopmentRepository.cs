using PoliticalParties.BusinessLayer.ViewModels;
using PoliticalParties.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliticalParties.BusinessLayer.Services.Repository
{
    public interface IDevelopmentRepository
    {
        Task<Development> Register(Development Development);
        Task<Development> FindDevelopmentById(long DevelopmentId);
        Task<Development> UpdateDevelopment(RegisterDevelopmentViewModel model);
        Task<IEnumerable<Development>> ListAllDevelopment();
        Task<IEnumerable<Development>> DevelopmentPlansByPoliticalLeaderId(long politicalLeaderId);
    }
}
