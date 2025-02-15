using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using People.Domain.Entities;

namespace People.Infrastructure.Persistence
{
    public class PeopleDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public PeopleDbContext(DbContextOptions options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Company>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<Person> People { get; set; }
    }
}
