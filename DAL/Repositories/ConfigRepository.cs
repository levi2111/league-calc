using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ConfigRepository : IConfigRepository
    {
        private readonly AppDbContext _context;

        public ConfigRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Config?> GetByID(string id) =>
            await _context.Configurations.FindAsync(id);

        public async Task<string> Add(Config config)
        {
            await _context.Configurations.AddAsync(config);
            await _context.SaveChangesAsync();
            return config.ID;

        }
        public async Task<bool> Update(Config config)
        {
            var existing = await _context.Configurations.FindAsync(config.ID);
            if (existing == null)
                return false;

            _context.Entry(existing).CurrentValues.SetValues(config);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateOrCreate(Config config)
        {
            var existing = await _context.Configurations.FindAsync(config.ID);

            if (existing == null)
            {
                await _context.Configurations.AddAsync(config);
            }
            else
            {
                _context.Entry(existing).CurrentValues.SetValues(config);
            }

            await _context.SaveChangesAsync();
            return true;
            // only returns true atm
        }

        public async Task<bool> DeleteByID(string id)
        {
            var champ = await _context.Configurations.FindAsync(id);
            if (champ == null) return false;

            _context.Configurations.Remove(champ);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
