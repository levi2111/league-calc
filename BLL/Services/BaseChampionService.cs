using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;

namespace BLL.Services
{
    public class BaseChampionService
    {
        private readonly IBaseChampionRepository _baseChampionRepository;

        public BaseChampionService(IBaseChampionRepository championRepository)
        {
            _baseChampionRepository = championRepository;
        }

        // defaults to latest patch
        public async Task<BaseChampion?> GetChampionByName(string name)
        {
            return await _baseChampionRepository.GetByName(name);
        }

        public async Task<BaseChampion?> GetChampionByNameAndPatch(string name, string patch)
        {
            return await _baseChampionRepository.GetByNameAndPatch(name, patch);
        }

        // defaults to latest patch
        public async Task<IReadOnlyList<BaseChampion>> GetAllChampions()
        {
            return await _baseChampionRepository.GetAll();
        }

        public async Task<IReadOnlyList<BaseChampion>> GetAllChampionsByPatch(string patch)
        {
            return await _baseChampionRepository.GetAllByPatch(patch);
        }
    }
}
