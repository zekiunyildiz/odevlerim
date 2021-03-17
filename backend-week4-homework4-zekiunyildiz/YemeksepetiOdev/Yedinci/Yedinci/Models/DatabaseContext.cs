using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Yedinci.Models;

namespace Yedinci.Models
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<FootballPlayer> FootballPlayers { get; set; }

    }
    
}
