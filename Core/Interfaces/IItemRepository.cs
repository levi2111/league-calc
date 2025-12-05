using Core.Models;
using Core.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IItemRepository
    {
        Task<IReadOnlyList<Item>> GetAll(); // default latest patch
        Task<Item> GetItemByIdAndPatch(int id, string patch);
    }
}
