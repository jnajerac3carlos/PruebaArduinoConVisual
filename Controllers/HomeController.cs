using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO.Ports;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult move()
        {
            using (SerialPort serialPort = new SerialPort("COM3", 9600))  // Reemplaza "COM3" con el puerto donde está conectado tu Arduino
            {
                serialPort.Open();
                if (serialPort.IsOpen)
                {
                    serialPort.WriteLine("180");
                }
                serialPort.Close();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View();
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
}