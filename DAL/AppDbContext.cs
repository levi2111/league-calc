using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using System.Text.Json;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Config> Configurations { get; set; } = null!;
        public DbSet<BaseChampion> BaseChampions { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);

            // ignore basechampion until configured
            modelBuilder.Ignore<BaseChampion>();

            modelBuilder.Entity<Config>()
                .Property(e => e.ItemIDs)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, options),
                    v => JsonSerializer.Deserialize<List<int>>(v, options) ?? new List<int>()
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
