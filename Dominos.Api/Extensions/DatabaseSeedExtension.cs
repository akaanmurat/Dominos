using Dominos.Data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dominos.Api.Extensions
{
    public static class DatabaseSeedExtension
    {
        public static IWebHost InitializeSeedingData(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<DbContext>();
                (context as EfContext).Seed();
            }
            return host;
        }
    }
}