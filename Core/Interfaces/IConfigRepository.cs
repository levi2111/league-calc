using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IConfigRepository
    {
        Task<Config?> GetByID(string id);
        Task<string> Add(Config config);
        Task<bool> Update(Config config);
        Task<bool> UpdateOrCreate(Config config);
        Task<bool> DeleteByID(string id);
    }
}
