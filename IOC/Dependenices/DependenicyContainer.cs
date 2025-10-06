using Application.Services.Interfaces;
using Application.Services.Repositories;
using Data.Repositories;
using Domian.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.Dependenices
{
    public static class DependenicyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region Repository

            services.AddScoped<IActivitesRepository, ActivitesRepository>();

            #endregion

            #region Service

            services.AddScoped<IActivitesService, ActivitesService>();

            #endregion
        }
    }
}
