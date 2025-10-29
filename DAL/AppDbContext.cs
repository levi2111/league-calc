using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<BaseChampion> Champions { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
