using Domian.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class ReactivitiesContext : DbContext
    {
        #region Constructor

        public ReactivitiesContext(DbContextOptions<ReactivitiesContext> options) : base(options)
        {
        }

        #endregion

        public DbSet<Activity> Activities { get; set; }

        
    }
}
