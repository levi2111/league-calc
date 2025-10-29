using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace BLL.Services
{
    public class ReadOnlyChampionService
    {
        private readonly IReadOnlyChampionRepository _repository;

        public ReadOnlyChampionService(IReadOnlyChampionRepository repository)
        {
            _repository = repository;
        }

        // defaults to latest patch
        public async Task<BaseChampion?> GetChampionByName(string name)
        {
            return await _repository.GetByName(name);
        }

        public async Task<BaseChampion?> GetChampionByNameAndPatch(string name, string patch)
        {
            return await _repository.GetByNameAndPatch(name, patch);
        }

        // defaults to latest patch
        public async Task<IReadOnlyList<BaseChampion?>> GetAllChampions()
        {
            return await _repository.GetAll();
        }

        public async Task<IReadOnlyList<BaseChampion?>> GetAllChampionsByPatch(string patch)
        {
            return await _repository.GetAllByPatch(patch);
        }
    }
}
