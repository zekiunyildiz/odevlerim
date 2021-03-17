using Microsoft.EntityFrameworkCore;
using MyProject.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {

        }


        public DbSet<FootballTeam> FootballTeam { get; set; }

    }
}
