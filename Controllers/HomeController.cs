using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using AhorcadORT.Models;
public class HomeController : Controller
{
    private const string ClaveDeSesionJuego = "JuegoEnCurso";

    public IActionResult Index()
    {
        string JuegoSerializado = HttpContext.Session.GetString(ClaveDeSesionJuego);

        if (!string.IsNullOrEmpty(JuegoSerializado))
        {
            Juego JuegoEnMemoria = Objeto.StringToObject<Juego>(JuegoSerializado);
            List<Usuario> ListaDeUsuarios = JuegoEnMemoria.DevolverListaUsuarios();
            ViewBag.ListaDeJugadores = ListaDeUsuarios;
        }
        else
        {
            ViewBag.ListaDeJugadores = new List<Usuario>();
        }

        return View();
    }

    [HttpPost]
    public IActionResult Comenzar(string username, int dificultad)
    {
        Juego JuegoNuevo = new Juego();
        JuegoNuevo.InicializarJuego(username, dificultad);

        string PalabraSeleccionada = JuegoNuevo.CargarPalabra(dificultad);

        string JuegoSerializado = Objeto.ObjectToString<Juego>(JuegoNuevo);
        HttpContext.Session.SetString(ClaveDeSesionJuego, JuegoSerializado);

        ViewBag.NombreDelJugador = username;
        ViewBag.Palabra = PalabraSeleccionada;
        ViewBag.DificultadSeleccionada = dificultad;

        return View("Juego");
    }

    [HttpPost]
    public IActionResult FinJuego(int intentos)
    {
        string JuegoSerializado = HttpContext.Session.GetString(ClaveDeSesionJuego);

        if (string.IsNullOrEmpty(JuegoSerializado))
        {
            return View("Index");
        }

        Juego JuegoEnMemoria = Objeto.StringToObject<Juego>(JuegoSerializado);
        JuegoEnMemoria.FinJuego(intentos);

        string JuegoActualizado = Objeto.ObjectToString<Juego>(JuegoEnMemoria);
        HttpContext.Session.SetString(ClaveDeSesionJuego, JuegoActualizado);

        List<Usuario> ListaDeUsuarios = JuegoEnMemoria.DevolverListaUsuarios();
        ViewBag.ListaDeJugadores = ListaDeUsuarios;

        return View("Index");
    }
}
