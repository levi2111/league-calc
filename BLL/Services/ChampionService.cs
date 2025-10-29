using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;

namespace BLL.Services
{
    public class ChampionService
    {
        private readonly IChampionRepository _championRepository;

        public ChampionService(IChampionRepository championRepository)
        {
            _championRepository = championRepository;
        }

        // defaults to latest patch
        public async Task<BaseChampion?> GetChampionByName(string name)
        {
            return await _championRepository.GetByName(name);
        }

        public async Task<BaseChampion?> GetChampionByNameAndPatch(string name, string patch)
        {
            return await _championRepository.GetByNameAndPatch(name, patch);
        }

        // defaults to latest patch
        public async Task<IReadOnlyList<BaseChampion?>> GetAllChampions()
        {
            return await _championRepository.GetAll();
        }

        public async Task<IReadOnlyList<BaseChampion?>> GetAllChampionsByPatch(string patch)
        {
            return await _championRepository.GetAllByPatch(patch);
        }

        public async Task AddChampion(BaseChampion champion)
        {
            await _championRepository.Add(champion);
        }

        public async Task DeleteChampionByName(string name)
        {
            await _championRepository.DeleteByName(name);
        }

        public async Task DeleteChampionByNameAndPatch(string name, string patch)
        {
            await _championRepository.DeleteByNameAndPatch(name, patch);
        }
    }
}
