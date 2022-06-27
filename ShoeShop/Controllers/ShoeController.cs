//using ShoeShop.Core.Models;
using ShoeShop.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ShoeShop.Core.Interfaces;

namespace ShoeShop.Controllers
{
    [Route("/shoes")]
    public class ShoeController : Controller
    {
        private readonly IShoeRepository _shoeRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ShoeController(IShoeRepository shoeRepository, ICategoryRepository categoryRepository)
        {
            _shoeRepository = shoeRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet("{category?}")]
        public async Task<IActionResult> List(string category, string desc)
        {
            var selectedCategory = !string.IsNullOrWhiteSpace(category) ? category : null;
            //var 
            ////////CATEGORY DESCRIPTION///////////
            var selectedCatDesc = !string.IsNullOrWhiteSpace(desc) ? desc : null;
            ShoesListViewModel shoesListViewModel = new ShoesListViewModel
            {
                Shoes = await _shoeRepository.GetShoes(selectedCategory),
                CurrentCategory = selectedCategory ?? "Усе усе наше взуття :)",
                ////////CATEGORY DESCRIPTION///////////
                Description = selectedCatDesc
            };
            return View(shoesListViewModel);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var shoe = await _shoeRepository.GetShoeById(id);
            return View(shoe);
        }
    }
}
