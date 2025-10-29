using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DAL.Repositories
{
    public class ChampionJsonRepository// : IChampionRepository
    {
        private string _folderLocation;

        public ChampionJsonRepository(string folderLocation)
        {
            _folderLocation = folderLocation;
        }

        // gets from latest patch
        //public async Task<Champion?> GetByName(string name) =>
        //    await _context.Champions.FindAsync(name);
        //public async Task<Champion?> GetByNameAndPatch(string name, string patch) =>
        //    await _context.Champions.FindAsync(name, patch);
        //// gets from latest patch
        //public async Task<IReadOnlyList<Champion>> GetAll() =>
        //    await _context.Champions.ToListAsync();
        //public async Task<IReadOnlyList<Champion>> GetAllByPatch(string patch) =>
        //    await _context.Champions.ToListAsync(patch);
        //public async Task Add(Champion champion) =>
        //    await _context.SaveChangesAsync(champion);
        //public async Task DeleteByName(string name)
        //{
        //    var entity = await _context.Champions.FindAsync(name);
        //    if (entity != null)
        //    {
        //        _context.Champions.Remove(entity);
        //        await _context.SaveChangesAsync();
        //    }
        //}
        //public async Task DeleteByNameAndPatch(string name, string patch) =>
        //    await _context.Champions.FindAsync(name);
    }
}
