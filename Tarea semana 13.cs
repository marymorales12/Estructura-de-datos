using System;
using System.Collections.Generic;

class Program
{
    // Función de búsqueda recursiva
    static string BusquedaRecursiva(List<string> catalogo, string titulo, int indice = 0)
    {
        // Caso base: si hemos llegado al final de la lista sin encontrar el título
        if (indice >= catalogo.Count)
        {
            return "No encontrado";  // Si llegamos al final de la lista sin encontrarlo, retornamos "No encontrado"
        }

        // Si encontramos el título en la posición actual (comparamos de forma insensible a mayúsculas/minúsculas)
        if (catalogo[indice].ToLower() == titulo.ToLower())
        {
            return "Encontrado";  // Si el título en la posición actual es igual al que buscamos, retornamos "Encontrado"
        }

        // Llamada recursiva: seguimos buscando en el siguiente índice de la lista
        return BusquedaRecursiva(catalogo, titulo, indice + 1);
    }

    // Crear el catálogo de revistas
    static List<string> CrearCatalogo()
    {
        // Inicializamos una lista vacía que almacenará los títulos de las revistas
        List<string> catalogo = new List<string>();
        
        Console.WriteLine("Ingrese 10 títulos de revistas:");

        // Bucle que permite al usuario ingresar 10 títulos de revistas
        for (int i = 0; i < 10; i++)
        {
            // Pedimos al usuario que ingrese el título de la revista
            Console.Write($"Ingrese el título de la revista {i + 1}: ");
            string titulo = Console.ReadLine();  // Guardamos el título ingresado

            // Agregamos el título ingresado a la lista del catálogo
            catalogo.Add(titulo);
        }

        // Retornamos el catálogo con los 10 títulos ingresados
        return catalogo;
    }

    // Función principal que muestra el menú y ejecuta la búsqueda
    static void Menu()
    {
        // Llamamos a CrearCatalogo() para obtener la lista de revistas
        List<string> catalogo = CrearCatalogo();
        
        // Bucle infinito para mostrar el menú repetidamente hasta que el usuario decida salir
        while (true)
        {
            // Mostramos las opciones del menú
            Console.WriteLine("\n--- Menú ---");
            Console.WriteLine("1. Buscar un título");
            Console.WriteLine("2. Salir");
            
            // Pedimos al usuario que seleccione una opción
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            // Si el usuario selecciona la opción "1", se realiza la búsqueda recursiva
            if (opcion == "1")
            {
                // Solicitamos el título a buscar
                Console.Write("Ingrese el título que desea buscar: ");
                string tituloBuscar = Console.ReadLine();

                // Llamamos a la función de búsqueda recursiva
                string resultado = BusquedaRecursiva(catalogo, tituloBuscar);

                // Mostramos el resultado de la búsqueda (encontrado o no encontrado)
                Console.WriteLine($"Resultado de la búsqueda: {resultado}");
            }
            // Si el usuario selecciona la opción "2", terminamos el programa
            else if (opcion == "2")
            {
                Console.WriteLine("¡Hasta luego!");  // Mensaje de despedida
                break;  // Rompemos el bucle y terminamos el programa
            }
            else
            {
                // Si el usuario ingresa una opción inválida, mostramos un mensaje de error
                Console.WriteLine("Opción no válida, por favor intente de nuevo.");
            }
        }
    }

    // Función principal que inicia el programa
    static void Main(string[] args)
    {
        Menu();  // Llamamos a la función que gestiona el menú y las búsquedas
    }
}
