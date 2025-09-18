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
        ViewBag.Username = username;
        ViewBag.Palabra = palabra; 

        return View("Juego");
    }
    [HttpPost] public IActionResult FinJuego(int intentos) {
        Juego.
        return RedirectToAction("Index");

}}
