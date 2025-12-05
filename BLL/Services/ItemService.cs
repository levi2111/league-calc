using Core.Interfaces;
using Core.Models;
using Core.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        // defaults to latest patch
        public async Task<IReadOnlyList<Item>> GetAllItems()
        {
            return await _itemRepository.GetAll();
        }
        public async Task<Item> GetItemByIdAndPatch(int id, string patch)
        {
            return await _itemRepository.GetItemByIdAndPatch(id, patch);
        }
    }
}
