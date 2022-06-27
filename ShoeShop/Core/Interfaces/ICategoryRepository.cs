using ShoeShop.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeShop.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories(string category = null /*, added second parameter string desc = null*/);
        //Task<IEnumerable<Category>> GetCategoryDesc(string category = null);
    }
}
