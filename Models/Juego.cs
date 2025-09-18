
using System.Collections.Generic;

namespace AhorcadORT.Models
{
    public class Juego
    {
        public List<Palabra> ListaPalabras;
        public List<Usuario> ListaJugadores;
        public Usuario JugadorActual ;


private void LlenarListaPalabras()
{
    ListaPalabras = new List<Palabra>();

    // Dificultad 1
    ListaPalabras.Add(new Palabra { Texto = "sol", Dificultad = 1 });
    ListaPalabras.Add(new Palabra { Texto = "pan", Dificultad = 1 });
    ListaPalabras.Add(new Palabra { Texto = "pez", Dificultad = 1 });
    ListaPalabras.Add(new Palabra { Texto = "luz", Dificultad = 1 });
    ListaPalabras.Add(new Palabra { Texto = "sal", Dificultad = 1 });
    ListaPalabras.Add(new Palabra { Texto = "mar", Dificultad = 1 });
    ListaPalabras.Add(new Palabra { Texto = "día", Dificultad = 1 });
    ListaPalabras.Add(new Palabra { Texto = "té", Dificultad = 1 });
    ListaPalabras.Add(new Palabra { Texto = "ola", Dificultad = 1 });
    ListaPalabras.Add(new Palabra { Texto = "sola", Dificultad = 1 });

    // Dificultad 2
    ListaPalabras.Add(new Palabra { Texto = "playa", Dificultad = 2 });
    ListaPalabras.Add(new Palabra { Texto = "silla", Dificultad = 2 });
    ListaPalabras.Add(new Palabra { Texto = "coche", Dificultad = 2 });
    ListaPalabras.Add(new Palabra { Texto = "reloj", Dificultad = 2 });
    ListaPalabras.Add(new Palabra { Texto = "flaco", Dificultad = 2 });
    ListaPalabras.Add(new Palabra { Texto = "lindo", Dificultad = 2 });
    ListaPalabras.Add(new Palabra { Texto = "tigre", Dificultad = 2 });
    ListaPalabras.Add(new Palabra { Texto = "fuego", Dificultad = 2 });
    ListaPalabras.Add(new Palabra { Texto = "piano", Dificultad = 2 });
    ListaPalabras.Add(new Palabra { Texto = "cielo", Dificultad = 2 });

    // Dificultad 3
    ListaPalabras.Add(new Palabra { Texto = "ventana", Dificultad = 3 });
    ListaPalabras.Add(new Palabra { Texto = "silencio", Dificultad = 3 });
    ListaPalabras.Add(new Palabra { Texto = "elefante", Dificultad = 3 });
    ListaPalabras.Add(new Palabra { Texto = "murciélago", Dificultad = 3 });
    ListaPalabras.Add(new Palabra { Texto = "caminante", Dificultad = 3 });
    ListaPalabras.Add(new Palabra { Texto = "trenecito", Dificultad = 3 });
    ListaPalabras.Add(new Palabra { Texto = "pingüino", Dificultad = 3 });
    ListaPalabras.Add(new Palabra { Texto = "dragones", Dificultad = 3 });
    ListaPalabras.Add(new Palabra { Texto = "espejismo", Dificultad = 3 });
    ListaPalabras.Add(new Palabra { Texto = "computado", Dificultad = 3 });

    // Dificultad 4
    ListaPalabras.Add(new Palabra { Texto = "hipopótamo", Dificultad = 4 });
    ListaPalabras.Add(new Palabra { Texto = "transparente", Dificultad = 4 });
    ListaPalabras.Add(new Palabra { Texto = "biblioteca", Dificultad = 4 });
    ListaPalabras.Add(new Palabra { Texto = "psicología", Dificultad = 4 });
    ListaPalabras.Add(new Palabra { Texto = "transformador", Dificultad = 4 });
    ListaPalabras.Add(new Palabra { Texto = "circunstancia", Dificultad = 4 });
    ListaPalabras.Add(new Palabra { Texto = "neumonía", Dificultad = 4 });
    ListaPalabras.Add(new Palabra { Texto = "dificultoso", Dificultad = 4 });
    ListaPalabras.Add(new Palabra { Texto = "especialidad", Dificultad = 4 });
    ListaPalabras.Add(new Palabra { Texto = "infraestructura", Dificultad = 4 });
}
   public void InicializarJuego(string nombreUsuario, int dificultadSeleccionada)
    {
        JugadorActual = new Usuario();
        JugadorActual.Nombre = nombreUsuario;
        JugadorActual.CantidadIntentos = 0;
    }


    private string CargarPalabra(int dificultadBuscada)
    {
        List<Palabra> listaFiltrada = new List<Palabra>();

        for (int i = 0; i < ListaPalabras.Count; i++)
        {
            if (ListaPalabras[i].Dificultad == dificultadBuscada)
            {
                listaFiltrada.Add(ListaPalabras[i]);
            }
        }

        if (listaFiltrada.Count == 0)
        {
            return "";
        }

        Random generadorAleatorio = new Random();
        int posicion = generadorAleatorio.Next(listaFiltrada.Count);
        return listaFiltrada[posicion].Texto;
    }

    
    public void FinJuego(int cantidadDeIntentos)
    {
        JugadorActual.CantidadIntentos = cantidadDeIntentos;
        ListaJugadores.Add(JugadorActual);
    }

    
    public List<Usuario> DevolverListaUsuarios()
    {
        for (int i = 0; i < ListaJugadores.Count - 1; i++)
        {
            for (int j = i + 1; j < ListaJugadores.Count; j++)
            {
                if (ListaJugadores[i].CantidadIntentos > ListaJugadores[j].CantidadIntentos)
                {
                    Usuario auxiliar = ListaJugadores[i];
                    ListaJugadores[i] = ListaJugadores[j];
                    ListaJugadores[j] = auxiliar;
                }
            }
        }

        return ListaJugadores;
    }

    


    }
}
