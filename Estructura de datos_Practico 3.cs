using System;
using System.Collections.Generic;

namespace Biblioteca_Tu_Mundo  // Cambié aquí el nombre del espacio de nombres.
{
    // La clase "Libro" representa un libro en la biblioteca, con atributos como ISBN, título, autor y año de publicación.
    public class Libro
    {
        private string _isbn;
        private string _nombreLibro;
        private string _nombreAutor;
        private int _añoPublicacion;

        public Libro(string isbn, string nombreLibro, string nombreAutor, int añoPublicacion)
        {
            _isbn = isbn;
            _nombreLibro = nombreLibro;
            _nombreAutor = nombreAutor;
            _añoPublicacion = añoPublicacion;
        }

        public string ObtenerISBN() => _isbn;
        public string ObtenerNombreLibro() => _nombreLibro;
        public string ObtenerNombreAutor() => _nombreAutor;
        public int ObtenerAñoPublicacion() => _añoPublicacion;

        public override string ToString()
        {
            return $"ISBN: {_isbn} | Título: {_nombreLibro} | Autor: {_nombreAutor} | Año: {_añoPublicacion}";
        }
    }

    // La clase "Biblioteca" administra una colección de libros.
    public class Biblioteca
    {
        private Dictionary<string, Libro> _librosDiccionario;
        private HashSet<string> _autoresConjunto;

        public Biblioteca()
        {
            _librosDiccionario = new Dictionary<string, Libro>();
            _autoresConjunto = new HashSet<string>();
        }

        public bool RegistrarLibro(Libro libro)
        {
            if (_librosDiccionario.ContainsKey(libro.ObtenerISBN()))
            {
                return false;
            }
            _librosDiccionario.Add(libro.ObtenerISBN(), libro);
            _autoresConjunto.Add(libro.ObtenerNombreAutor());
            return true;
        }

        public List<Libro> ObtenerTodosLosLibros()
        {
            return new List<Libro>(_librosDiccionario.Values);
        }

        public Libro ObtenerLibroPorISBN(string isbn)
        {
            return _librosDiccionario.ContainsKey(isbn) ? _librosDiccionario[isbn] : null;
        }

        public HashSet<string> ObtenerAutores()
        {
            return _autoresConjunto;
        }
    }

    // La clase "Programa" contiene el menú principal de interacción con el usuario.
    class Programa
    {
        static void Main(string[] args)
        {
            Biblioteca miBiblioteca = new Biblioteca();
            int seleccion;

            do
            {
                MostrarMenu();
                Console.Write("Seleccione una opción: ");
                bool esOpcionValida = int.TryParse(Console.ReadLine(), out seleccion);

                if (!esOpcionValida)
                {
                    Console.WriteLine("Opción inválida. Intente nuevamente.\n");
                    continue;
                }

                switch (seleccion)
                {
                    case 1:
                        RegistrarLibroConsola(miBiblioteca);
                        break;
                    case 2:
                        MostrarTodosLosLibros(miBiblioteca);
                        break;
                    case 3:
                        ConsultarLibroPorISBN(miBiblioteca);
                        break;
                    case 4:
                        MostrarAutoresRegistrados(miBiblioteca);
                        break;
                    case 5:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.\n");
                        break;
                }

            } while (seleccion != 5);
        }

        static void MostrarMenu()
        {
            Console.WriteLine("======================================");
            Console.WriteLine("        SISTEMA DE BIBLIOTECA         ");
            Console.WriteLine("======================================");
            Console.WriteLine("1. Registrar un libro");
            Console.WriteLine("2. Mostrar todos los libros");
            Console.WriteLine("3. Consultar un libro por ISBN");
            Console.WriteLine("4. Mostrar autores registrados");
            Console.WriteLine("5. Salir");
            Console.WriteLine("======================================");
        }

        static void RegistrarLibroConsola(Biblioteca biblioteca)
        {
            Console.WriteLine("\n[REGISTRAR LIBRO]");

            Console.Write("Ingrese el código ISBN del libro: ");
            string isbn = Console.ReadLine();

            Console.Write("Ingrese el título del libro: ");
            string nombreLibro = Console.ReadLine();

            Console.Write("Ingrese el autor del libro: ");
            string nombreAutor = Console.ReadLine();

            Console.Write("Ingrese el año de publicación: ");
            int añoPublicacion;
            bool esNumero = int.TryParse(Console.ReadLine(), out añoPublicacion);
            if (!esNumero)
            {
                Console.WriteLine("Año de publicación inválido. Operación cancelada.\n");
                return;
            }

            Libro nuevoLibro = new Libro(isbn, nombreLibro, nombreAutor, añoPublicacion);

            bool exito = biblioteca.RegistrarLibro(nuevoLibro);
            if (exito)
                Console.WriteLine("Libro registrado exitosamente.\n");
            else
                Console.WriteLine("Error: Ya existe un libro con ese ISBN.\n");
        }

        static void MostrarTodosLosLibros(Biblioteca biblioteca)
        {
            Console.WriteLine("\n[LISTADO DE LIBROS]");
            List<Libro> listaDeLibros = biblioteca.ObtenerTodosLosLibros();

            if (listaDeLibros.Count == 0)
            {
                Console.WriteLine("No hay libros registrados.\n");
                return;
            }

            foreach (Libro libro in listaDeLibros)
            {
                Console.WriteLine(libro.ToString());
            }
            Console.WriteLine();
        }

        static void ConsultarLibroPorISBN(Biblioteca biblioteca)
        {
            Console.WriteLine("\n[CONSULTAR LIBRO POR ISBN]");
            Console.Write("Ingrese el ISBN: ");
            string isbn = Console.ReadLine();

            Libro libroEncontrado = biblioteca.ObtenerLibroPorISBN(isbn);
            if (libroEncontrado != null)
            {
                Console.WriteLine("Libro encontrado:");
                Console.WriteLine(libroEncontrado.ToString() + "\n");
            }
            else
            {
                Console.WriteLine("No se encontró un libro con ese ISBN.\n");
            }
        }

        static void MostrarAutoresRegistrados(Biblioteca biblioteca)
        {
            Console.WriteLine("\n[LISTADO DE AUTORES]");
            HashSet<string> autoresRegistrados = biblioteca.ObtenerAutores();

            if (autoresRegistrados.Count == 0)
            {
                Console.WriteLine("No hay autores registrados.\n");
                return;
            }

            foreach (string autor in autoresRegistrados)
            {
                Console.WriteLine("- " + autor);
            }
            Console.WriteLine();
        }
    }
}
