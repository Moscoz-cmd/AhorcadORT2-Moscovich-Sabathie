using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AhorcadORT.Models;

namespace AhorcadORT.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.Jugadores = jugadores;
        return View();
    }   
    [HttpPost]public IActionResult Comenzar(string username, int dificultad)
    {
     
        HttpContext.Session.SetString("username", username);
        HttpContext.Session.SetString("palabra", palabra);

        ViewBag.Username = username;
        ViewBag.Palabra = palabra; 

        return View("Juego");
    }
    [HttpPost] public IActionResult FinJuego(int intentos) {

tring username = HttpContext.Session.GetString("username");
        string palabra = HttpContext.Session.GetString("palabra");

        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(palabra))
        {
           

        return RedirectToAction("Index");
    }
}}
