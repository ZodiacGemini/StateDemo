using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StateDemo.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StateDemo.Controllers
{
    public class SettingsController : Controller
    {
        StateManager stateManager;

        public SettingsController(IMemoryCache cache)
        {
            this.stateManager = new StateManager(this, cache);

        }
        // GET: /<controller>/
        public IActionResult Display()
        {
            var viewModel = new SettingsDisplayVM();
            viewModel.StatusMessage = stateManager.StatusMessage;
            viewModel.CompanyName = stateManager.CompanyName;
            viewModel.SupportEmail = stateManager.SupportEmail;

            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SettingsCreateVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            stateManager.StatusMessage = "Dina värden har sparats";
            stateManager.SupportEmail = viewModel.SupportEmail;
            stateManager.CompanyName = viewModel.CompanyName;

            return RedirectToAction(nameof(Display));
        }
    }
}
