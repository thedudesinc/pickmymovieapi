using Microsoft.EntityFrameworkCore;
using PickMyMovieApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickMyMovieApi.Data
{
    public class PickMyMovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Startup.ConnectionString);
        }
    }
}
