using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShoeShop.Core.Interfaces;
using ShoeShop.Core.Models;
using System.Linq;

namespace ShoeShop.Persistence
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShoeShopDbContext _context;

        public CategoryRepository(ShoeShopDbContext context)
        {
            _context = context;
        }


        ////////CATEGORY DESCRIPTION///////////
        public async Task<IEnumerable<Category>> GetCategories(string category = null/*, string desc = null*/)
        {
            var query = _context.Categories
                .Include(c => c.Description)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(category))
            {
                //query = query.Include(c => c.Description);
                query = query.Where(c => c.Name == category);
            }

            return await query.ToListAsync();
        }

    }
}
