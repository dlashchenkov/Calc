using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc.Data
{
    public class ContainerConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CalcDBContext>(options => {
                options.UseSqlServer(
                    connection
                    )
                .ConfigureWarnings(builder =>
                {
                    builder.Ignore(CoreEventId.PossibleIncorrectRequiredNavigationWithQueryFilterInteractionWarning);
                });
            });

            services.AddScoped<IRepository, Repository>();
        }
    }
}
