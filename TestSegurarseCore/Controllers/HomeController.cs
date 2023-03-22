using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using TestSegurarseCore.Models;
using TestSegurarseCore.Services.Interfaces;

namespace TestSegurarseCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITestEncriptService _testEncriptService;

        public HomeController(ILogger<HomeController> logger, ITestEncriptService testEncriptService)
        {
            _logger = logger;
            _testEncriptService = testEncriptService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EnviarFormulario(Persona persona)
        {
            var result = await _testEncriptService.Test(persona);
            ApiResponse apiResponse = JsonSerializer.Deserialize<ApiResponse>(result);
            ViewBag.Message = apiResponse.result;
            return View("Message");
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    public class ApiResponse
    {
        public string result { get; set; }
    }
}