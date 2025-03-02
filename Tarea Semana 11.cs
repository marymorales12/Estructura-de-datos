using System;
using System.Collections.Generic;

namespace Traductor_ENGLISH_SPANISH
{
    // Universidad: Estatal Amazonica
    // Estudiante: Mary Morales
    // Tarea: Semana 11
    // Fecha: 02/03/2025

    // Clase que maneja la lógica del traductor.
    public class Traductor
    {
        private Dictionary<string, string> diccionario;

        // Constructor: inicializa el diccionario con palabras por defecto.
        public Traductor()
        {
            diccionario = new Dictionary<string, string>(); // Inicializa el diccionario vacío

            // Se agregan palabras base (traducción bidireccional).
            AgregarPalabra("tiempo", "time");
            AgregarPalabra("persona", "person");
            AgregarPalabra("año", "year");
            AgregarPalabra("camino", "way");
            AgregarPalabra("dia", "day");
            AgregarPalabra("cosa", "thing");
            AgregarPalabra("hombre", "man");
            AgregarPalabra("mundo", "world");
            AgregarPalabra("vida", "life");
            AgregarPalabra("mano", "hand");
            AgregarPalabra("parte", "part");
            AgregarPalabra("niño", "child");
            AgregarPalabra("ojo", "eye");
            AgregarPalabra("mujer", "woman");
            AgregarPalabra("lugar", "place");
            AgregarPalabra("trabajo", "work");
            AgregarPalabra("semana", "week");
            AgregarPalabra("caso", "case");
            AgregarPalabra("punto", "point");
            AgregarPalabra("gobierno", "government");
            AgregarPalabra("empresa", "company");
        }

        // Método para agregar nuevas palabras de forma bidireccional.
        public void AgregarPalabra(string palabraOriginal, string palabraTraduccion)
        {
            // Convierte ambas palabras a minúsculas para asegurar que la búsqueda no sea sensible al caso.
            palabraOriginal = palabraOriginal.ToLower();
            palabraTraduccion = palabraTraduccion.ToLower();

            // Si la palabra ya existe, la reemplaza, si no, la agrega
            if (diccionario.ContainsKey(palabraOriginal) || diccionario.ContainsKey(palabraTraduccion))
            {
                diccionario[palabraOriginal] = palabraTraduccion;
                diccionario[palabraTraduccion] = palabraOriginal;
                Console.WriteLine("La palabra ya existía y ha sido actualizada.");
            }
            else
            {
                // Agrega las palabras al diccionario de manera bidireccional:
                // Se mapea la palabra original a su traducción.
                diccionario[palabraOriginal] = palabraTraduccion;
                // Se mapea la palabra de traducción a su palabra original.
                diccionario[palabraTraduccion] = palabraOriginal;
            }
        }

        // Método privado que busca y retorna la traducción de una palabra.
        private string BuscarTraduccion(string palabra)
        {
            palabra = palabra.ToLower(); // Asegura que la búsqueda no sea sensible al caso.
            // Si la palabra existe en el diccionario, retorna la traducción; de lo contrario, retorna null.
            return diccionario.ContainsKey(palabra) ? diccionario[palabra] : null;
        }

        // Método que traduce una sola palabra, preservando la puntuación.
        public string TraducirPalabra(string palabra)
        {
            // Se define el inicio y el fin de la palabra (sin contar la puntuación).
            int inicio = 0, fin = palabra.Length - 1;

            // Elimina los signos de puntuación al principio de la palabra.
            while (inicio < palabra.Length && char.IsPunctuation(palabra[inicio]))
                inicio++;

            // Elimina los signos de puntuación al final de la palabra.
            while (fin >= 0 && char.IsPunctuation(palabra[fin]))
                fin--;

            // Si no hay palabra central (solo puntuación), se retorna la palabra tal como está.
            if (inicio > fin)
                return palabra;

            // Extrae los componentes: prefijo (antes de la palabra), sufijo (después de la palabra) y la palabra central.
            string prefijo = palabra.Substring(0, inicio);
            string sufijo = palabra.Substring(fin + 1);
            string palabraCentral = palabra.Substring(inicio, fin - inicio + 1);

            // Busca la traducción de la palabra central.
            string traduccion = BuscarTraduccion(palabraCentral);

            // Si se encuentra la traducción, se conserva la capitalización original.
            if (traduccion != null)
            {
                // Si la palabra original comienza con mayúscula, se cambia la traducción para que también empiece con mayúscula.
                if (char.IsUpper(palabraCentral[0]))
                    traduccion = char.ToUpper(traduccion[0]) + traduccion.Substring(1);

                // Retorna la palabra traducida, manteniendo el prefijo y sufijo (si los hubiera).
                return prefijo + traduccion + sufijo;
            }
            else
            {
                // Si no se encuentra la traducción, se retorna la palabra original.
                return palabra;
            }
        }

        // Método que traduce una frase completa palabra por palabra.
        public string TraducirFrase(string frase)
        {
            // Se divide la frase en palabras individuales.
            string[] palabras = frase.Split(' ');

            // Se traduce cada palabra individualmente.
            for (int i = 0; i < palabras.Length; i++)
            {
                palabras[i] = TraducirPalabra(palabras[i]);
            }

            // Se unen las palabras traducidas en una sola frase.
            return string.Join(" ", palabras);
        }
    }

    // Clase principal para la interacción con el usuario.
    class Programa
    {
        static void Main(string[] args)
        {
            // Se crea una instancia de la clase Traductor.
            Traductor traductor = new Traductor();
            int opcion = -1;

            // Menú de opciones hasta que el usuario elija salir (opción 0).
            while (opcion != 0)
            {
                MostrarMenu(); // Muestra el menú de opciones.
                string entrada = Console.ReadLine(); // Lee la opción seleccionada por el usuario.
                
                // Verifica si la entrada es un número válido.
                if (!int.TryParse(entrada, out opcion))
                {
                    Console.WriteLine("Opción inválida. Intente de nuevo.\n");
                    continue;
                }

                // Procesa la opción seleccionada por el usuario.
                switch (opcion)
                {
                    case 1:
                        // Opción 1: Traducir una frase.
                        Console.Write("\nIngrese la frase: ");
                        string frase = Console.ReadLine(); // Lee la frase a traducir.
                        string fraseTraducida = traductor.TraducirFrase(frase); // Traduce la frase.
                        Console.WriteLine("\nFrase traducida: " + fraseTraducida + "\n");
                        break;

                    case 2:
                        // Opción 2: Ingresar nuevas palabras al diccionario.
                        Console.Write("\nIngrese la palabra en español: ");
                        string original = Console.ReadLine().Trim(); // Lee la palabra original en español.
                        Console.Write("Ingrese su traducción en inglés: ");
                        string traduccion = Console.ReadLine().Trim(); // Lee la traducción en inglés.

                        // Se intenta agregar la nueva palabra al diccionario.
                        traductor.AgregarPalabra(original, traduccion);
                        break;

                    case 0:
                        // Opción 0: Salir del programa.
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        // Si la opción no es válida, muestra un mensaje de error.
                        Console.WriteLine("Opción no reconocida. Intente de nuevo.\n");
                        break;
                }
            }
        }

        // Método que muestra el menú de opciones.
        static void MostrarMenu()
        {
            Console.WriteLine("==== TRADUCTOR BASICO DE INGLÉS A ESPAÑOL =====");
            Console.WriteLine("******************************************************");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Ingresar más palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
        }
    }
}