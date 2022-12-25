using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using VendasBack.Data;

namespace VendasBack.Services
{
    public static class DataBaseManagementService
    {
        //Caso n tenha feito a migration ela ser feita altomaticamente ao iniciar a aplicação
        public static void MigrationInitialisation(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var serviceDb = serviceScope.ServiceProvider
                                 .GetService<VendaContext>();

                serviceDb.Database.Migrate();
            }
        }
    }
}
