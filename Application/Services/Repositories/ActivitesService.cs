using Application.Services.Interfaces;
using Domian.Entities.User;
using Domian.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories
{
    public class ActivitesService : IActivitesService
    {
        #region Constructor

        private readonly IActivitesRepository _activitesRepository;

        public ActivitesService(IActivitesRepository activitesRepository)
        {
            _activitesRepository = activitesRepository;
        }

        #endregion

        #region Activites

        public async Task<List<Activity>> GetAllActivitiesAsync()
        {
            return await _activitesRepository.GetAllActivitiesAsync();
        }

        public async Task<Activity?> GetActivityByIdAsync(Guid id)
        {
            return await _activitesRepository.GetActivityByIdAsync(id);
        }

        public async Task<bool> CreateActivityAsync(Activity activity)
        {
            if (activity == null)
            {
                return false;
            }

            await _activitesRepository.CreateActivityAsync(activity);

            return true;
        }

        public async Task<bool> UpdateActivityAsync(Activity activity)
        {
            if (activity == null)
            {
                return false;
            }

            var existingActivity = await _activitesRepository.GetActivityByIdAsync(activity.Id);

            if (existingActivity == null)
            {
                return false;
            }

            existingActivity.Title = activity.Title;
            existingActivity.Description = activity.Description;
            existingActivity.Category = activity.Category;
            existingActivity.Date = activity.Date;
            existingActivity.City = activity.City;
            existingActivity.Venue = activity.Venue;

            await _activitesRepository.UpdateActivityAsync(existingActivity);

            return true;
        }

        public async Task<bool> DeleteActivityAsync(Guid id)
        {
            var existingActivity = await _activitesRepository.GetActivityByIdAsync(id);

            if (existingActivity == null)
            {
                return false;
            }

            await _activitesRepository.DeleteActivityAsync(id);
            return true;
        }

        #endregion
    }
}
