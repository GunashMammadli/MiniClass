using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniStore.Context;
using MiniStore.Models;
using MiniStore.ViewModels;
using System.Diagnostics;

namespace MiniStore.Controllers
{
    public class HomeController : Controller
    {
        StoreDbContext _context { get; }

        public HomeController(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            AllList allList = new AllList();
            var sliders = await _context.Sliders.ToListAsync();
            var cards = await _context.Cards.ToListAsync();
            allList.cards = cards;
            allList.sliders = sliders;
            return View(allList);
        }
    }
}
