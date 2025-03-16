using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeatherApplication.Models;
using WeatherApplication.Services;

namespace WeatherApplication.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    // public IActionResult GetCity(string city)
    // {
    //     WeatherService weatherService = new WeatherService();
    //     var res = weatherService.GetWeatherData(city);
    //     return View("Index", res.Result.JsonData);
    // }

    public async Task<IActionResult> GetCity(string city)
    {
        WeatherService weatherService = new WeatherService();
        var res = await weatherService.GetWeatherData(city);
        
        if (res.IsSuccess)
        {
            return View("Index", res.JsonData); // Pass WeatherModel to the view
        }
        
        ViewBag.ErrorMessage = res.Message; // Handle error case
        return View("Index", null);
    }

    public IActionResult Forcast()
    {
        return View();
    }

    public async Task<IActionResult> GetCityForecast(string city)
    {
        WeatherService weatherService = new WeatherService();
        var res = await weatherService.GetForecastData(city);
        
        if (res.IsSuccess)
        {
            return View("Forcast", res.JsonData); // Pass WeatherModel to the view
        }
        
        ViewBag.ErrorMessage = res.Message; // Handle error case
        return View("Forcast", null);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult HomePage()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
