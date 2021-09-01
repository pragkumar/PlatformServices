using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrePopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());

            }
        }

        private static void SeedData(AppDbContext context)
        {
            if(!context.Platforms.Any())
            {
                Console.WriteLine("-->Seeding Data<--");
                context.Platforms.AddRange(
                    new Models.Platform() { Name="Prag",Publisher="Microsoft", Cost="Free"},
                    new Models.Platform() { Name = "Naincy",Publisher = "AWS", Cost = "10$"}


                    );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("-->We already have Data<--");
            }
        }
    }
}
