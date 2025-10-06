using Domian.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian.Interfaces
{
    public interface IActivitesRepository
    {
        #region Activites

        Task<List<Activity>> GetAllActivitiesAsync();

        Task<Activity?> GetActivityByIdAsync(Guid id);

        Task CreateActivityAsync(Activity activity);

        Task UpdateActivityAsync(Activity activity);

        Task DeleteActivityAsync(Guid id);

        #endregion
    }
}
