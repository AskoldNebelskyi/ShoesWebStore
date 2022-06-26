﻿using ShoeShop.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ShoeShop.Core.Interfaces;

namespace ShoeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IShoeRepository _shoeRepository;

        public HomeController(IShoeRepository shoeRepository)
        {
            _shoeRepository = shoeRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(new HomeViewModel
            {
                ShoeOfTheWeek = await _shoeRepository.GetShoesOfTheWeek()
            });
        }
    }
}