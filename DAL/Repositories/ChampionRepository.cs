using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ChampionRepository : IChampionRepository
    {
        private readonly AppDbContext _context;

        public ChampionRepository(AppDbContext context)
        {
            _context = context;
        }

        // gets from latest patch
        public async Task<BaseChampion?> GetByName(string name) =>
            await _context.Champions.FindAsync(name);
        public async Task<BaseChampion?> GetByNameAndPatch(string name, string patch) =>
            await _context.Champions.FindAsync(name, patch);
        // gets from latest patch
        public async Task<IReadOnlyList<BaseChampion>> GetAll() =>
            await _context.Champions.ToListAsync();
        public async Task<IReadOnlyList<BaseChampion>> GetAllByPatch(string patch) =>
            await _context.Champions.Where(c => c.Patch == patch).ToListAsync();
        public async Task Add(BaseChampion champion) =>
            await _context.SaveChangesAsync();
        public async Task DeleteByName(string name)
        {
            var entity = await _context.Champions.FindAsync(name);
            if (entity != null)
            {
                _context.Champions.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteByNameAndPatch(string name, string patch) =>
            await _context.Champions.FindAsync(name);
    }
}
