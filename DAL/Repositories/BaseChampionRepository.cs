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
    public class BaseChampionRepository : IBaseChampionRepository
    {
        private readonly AppDbContext _context;

        public BaseChampionRepository(AppDbContext context)
        {
            _context = context;
        }

        // gets from latest patch
        public async Task<BaseChampion?> GetByName(string name) =>
            await _context.BaseChampions.FindAsync(name);
        public async Task<BaseChampion?> GetByNameAndPatch(string name, string patch) =>
            await _context.BaseChampions.FindAsync(name, patch);
        // gets from latest patch
        public async Task<IReadOnlyList<BaseChampion>> GetAll() =>
            await _context.BaseChampions.ToListAsync();
        public async Task<IReadOnlyList<BaseChampion>> GetAllByPatch(string patch) =>
            await _context.BaseChampions.Where(c => c.Patch == patch).ToListAsync();
        public async Task Add(BaseChampion champion) =>
            await _context.SaveChangesAsync();
        public async Task DeleteByName(string name)
        {
            var entity = await _context.BaseChampions.FindAsync(name);
            if (entity != null)
            {
                _context.BaseChampions.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteByNameAndPatch(string name, string patch) =>
            await _context.BaseChampions.FindAsync(name);
    }
}
