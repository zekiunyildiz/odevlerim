using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Yedinci.Models;


namespace Yedinci.Models.Contexts
{
    public static class BaseData
    {
        public static async Task InitializeAsync(IServiceProvider service)
        {
            await AddSampleData(service.GetRequiredService<DatabaseContext>());
        }

        private static async Task AddSampleData(DatabaseContext dbContext)
        {
            if (dbContext.FootballPlayers.Any())
            {
                return;
            }

            dbContext.FootballPlayers.Add(new FootballPlayer
            {
                Id = 1,
                FullName = "Yusuf Sarı",
                Team = "Trabzonspor",
                Value = 150000
            });

            dbContext.FootballPlayers.Add(new FootballPlayer
            {
                Id = 2,
                FullName = "Baksetas",
                Team = "Trabzonspor",
                Value = 250000
            });
            dbContext.FootballPlayers.Add(new FootballPlayer
            {
                Id = 2,
                FullName = "Taylan Antalyalı",
                Team = "Galatasaray",
                Value = 380000
            });
            dbContext.FootballPlayers.Add(new FootballPlayer
            {
                Id = 2,
                FullName = "Falcao",
                Team = "Galatasaray",
                Value = 280000
            });
            dbContext.FootballPlayers.Add(new FootballPlayer
            {
                Id = 2,
                FullName = "Ozan Tufan",
                Team = "Fenerbahçe",
                Value = 220000
            });
            await dbContext.SaveChangesAsync();
        }
    }
}
