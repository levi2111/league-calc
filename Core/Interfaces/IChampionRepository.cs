using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IChampionRepository
    {
        Task<BaseChampion?> GetByName(string name); // default latest patch
        Task<BaseChampion?> GetByNameAndPatch(string name, string patch);
        Task<IReadOnlyList<BaseChampion>> GetAll(); // default latest patch
        Task<IReadOnlyList<BaseChampion>> GetAllByPatch(string patch);
        Task Add(BaseChampion champion);
        Task DeleteByName(string name);
        Task DeleteByNameAndPatch(string name, string patch);
    }
}
