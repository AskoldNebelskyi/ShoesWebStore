using ShoeShop.Core.Dto;
using ShoeShop.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeShop.Core.Interfaces
{
    public interface IShoeRepository
    {
        Task<IEnumerable<Shoe>> GetShoes(string category = null);

        ////////CATEGORY DESCRIPTION///////////
        //Task<IEnumerable<Category>> GetCategories(string category = null);


        Task<IEnumerable<Shoe>> GetShoesOfTheWeek();
        Task<Shoe> GetShoeById(int shoeId);

        Task<IEnumerable<ShoeNameIdDto>> GetAllShoesNameId();
        void UpdateShoe(Shoe shoe);
        Task AddShoeAsync(Shoe shoe);
        void Delete(int id);
    }
}
