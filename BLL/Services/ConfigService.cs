using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ConfigService
    {
        private readonly IConfigRepository _configRepository;
        private readonly IBaseChampionRepository _baseChampionRepository;
        private readonly IItemRepository _itemRepository;

        public ConfigService(IConfigRepository configRepository,
            IBaseChampionRepository baseChampionRepository, IItemRepository itemRepository)
        {
            _configRepository = configRepository;
            _baseChampionRepository = baseChampionRepository;
            _itemRepository = itemRepository;
        }

        public async Task<Config> GetConfigByID(string id)
        {
            return await _configRepository.GetByID(id);
        }

        public async Task<bool> UpdateConfig(Config config)
        {
            return await _configRepository.Update(config);
        }

        public async Task<bool> UpdateOrCreateConfig(Config config)
        {
            return await _configRepository.UpdateOrCreate(config);
        }

        public async Task<string> Add(Config config)
        {
            await _configRepository.Add(config);
            return config.ID;
        }

        public async Task<Champion?> GetChampionByID(string id)
        {
            Config? config = await _configRepository.GetByID(id);
            if (config == null) return null;

            string champName = config.ChampionName;
            string patch = config.Patch;
            BaseChampion baseChamp = await _baseChampionRepository.GetByName(champName);
            //BaseChampion baseChamp = await _baseChampionRepository.GetByNameAndPatch(champName, patch);
            Champion champ = new(baseChamp);

            List<int>? itemIDs = config.ItemIDs;
            int level = config.Level;
            int qRank = config.QRank ?? 0;
            int wRank = config.WRank ?? 0;
            int eRank = config.ERank ?? 0;
            int rRank = config.RRank ?? 0;

            if (itemIDs != null)
            {
                foreach (int itemID in itemIDs)
                {
                    champ.Inventory.AddItem(await _itemRepository.GetItemByIdAndPatch(itemID, patch));
                }
            }

            champ.Level = level;
            //champ.Q.CurrentRank = qRank;
            //champ.W.CurrentRank = wRank;
            //champ.E.CurrentRank = eRank;
            //champ.R.CurrentRank = rRank;

            return champ;
        }
    }
}
