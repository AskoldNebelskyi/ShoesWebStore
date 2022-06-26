using ShoeShop.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeShop.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
    }
}
