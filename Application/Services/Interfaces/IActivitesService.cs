using Domian.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IActivitesService
    {
        #region Activites

        Task<List<Activity>> GetAllActivitiesAsync();

        Task<Activity?> GetActivityByIdAsync(Guid id);

        Task<bool> CreateActivityAsync(Activity activity);

        Task<bool> UpdateActivityAsync(Activity activity);

        Task<bool> DeleteActivityAsync(Guid id);

        #endregion
    }
}
