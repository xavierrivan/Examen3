using Android.Content;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Examen3.Models;
using Examen3.Models;

namespace Examen3.Services
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=countries.db");
        }
    }
}
