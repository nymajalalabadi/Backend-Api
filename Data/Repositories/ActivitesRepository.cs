using Data.Context;
using Domian.Entities.User;
using Domian.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ActivitesRepository : IActivitesRepository
    {
        #region Constructor

        private readonly ReactivitiesContext _context;

        public ActivitesRepository(ReactivitiesContext context)
        {
            _context = context;
        }

        #endregion

        #region Activites

        public async Task<List<Activity>> GetAllActivitiesAsync()
        {
            return await _context.Activities.ToListAsync();
        }

        public async Task<Activity?> GetActivityByIdAsync(Guid id)
        {
            return await _context.Activities.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task CreateActivityAsync(Activity activity)
        {
            await _context.Activities.AddAsync(activity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateActivityAsync(Activity activity)
        {
            _context.Activities.Update(activity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteActivityAsync(Guid id)
        {
            var activity = await _context.Activities.FindAsync(id);

            if (activity != null)
            {
                _context.Activities.Remove(activity);
                await _context.SaveChangesAsync();
            }
        }

        #endregion
    }
}
