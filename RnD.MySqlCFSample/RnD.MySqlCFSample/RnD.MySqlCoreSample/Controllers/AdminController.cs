using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RnD.MySqlCoreSample.Data;
using RnD.MySqlCoreSample.ViewModels;
using System;
using System.Diagnostics;
using System.Linq;

namespace RnD.MySqlCoreSample.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public AdminController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = new AppDbContext();
        }

        public IActionResult Index()
        {
            try
            {
                var students = _context.Students.ToList();
                return View(students);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return View("Error");
        }
    }
}
