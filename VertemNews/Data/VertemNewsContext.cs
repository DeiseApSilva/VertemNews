using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VertemNews.Models;

namespace VertemNews.Data
{
    public class VertemNewsContext : DbContext
    {
        public VertemNewsContext (DbContextOptions<VertemNewsContext> options)
            : base(options)
        {
        }

        public DbSet<News> News { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=VertemNews;Trusted_Connection=true;");
        }
    }
}
