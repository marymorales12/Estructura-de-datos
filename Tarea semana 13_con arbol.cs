using System;

class Nodo
{
    public string Titulo;
    public Nodo Izquierda;
    public Nodo Derecha;

    public Nodo(string titulo)
    {
        Titulo = titulo;
        Izquierda = null;
        Derecha = null;
    }
}

class ArbolBinario
{
    public Nodo Raiz;

    public ArbolBinario()
    {
        Raiz = null;
    }

    // Método para insertar un nuevo título en el árbol
    public void Insertar(string titulo)
    {
        Raiz = InsertarRecursivo(Raiz, titulo);
    }

    // Inserción recursiva en el árbol binario
    private Nodo InsertarRecursivo(Nodo raiz, string titulo)
    {
        if (raiz == null)
        {
            raiz = new Nodo(titulo);
            return raiz;
        }

        // Comparamos el título con el nodo actual (ignorando mayúsculas/minúsculas)
        if (string.Compare(titulo, raiz.Titulo, true) < 0)
        {
            raiz.Izquierda = InsertarRecursivo(raiz.Izquierda, titulo);
        }
        else if (string.Compare(titulo, raiz.Titulo, true) > 0)
        {
            raiz.Derecha = InsertarRecursivo(raiz.Derecha, titulo);
        }

        return raiz;
    }

    // Método para buscar un título en el árbol
    public string Buscar(string titulo)
    {
        return BuscarRecursivo(Raiz, titulo);
    }

    // Búsqueda recursiva en el árbol binario
    private string BuscarRecursivo(Nodo raiz, string titulo)
    {
        if (raiz == null)
        {
            return "No encontrado";  // Si no encontramos el título, retornamos "No encontrado"
        }

        // Comparamos el título con el nodo actual (ignorando mayúsculas/minúsculas)
        if (string.Compare(titulo, raiz.Titulo, true) == 0)
        {
            return "Encontrado";  // Si encontramos el título, retornamos "Encontrado"
        }

        // Si el título es menor que el del nodo actual, buscamos en la subárbol izquierdo
        if (string.Compare(titulo, raiz.Titulo, true) < 0)
        {
            return BuscarRecursivo(raiz.Izquierda, titulo);
        }
        else
        {
            return BuscarRecursivo(raiz.Derecha, titulo);  // Si es mayor, buscamos en el subárbol derecho
        }
    }
}

class Program
{
    // Función para crear el catálogo de revistas
    static ArbolBinario CrearCatalogo()
    {
        ArbolBinario arbol = new ArbolBinario();
        Console.WriteLine("Ingrese 10 títulos de revistas:");

        // Bucle que permite al usuario ingresar 10 títulos de revistas
        for (int i = 0; i < 10; i++)
        {
            // Pedimos al usuario que ingrese el título de la revista
            Console.Write($"Ingrese el título de la revista {i + 1}: ");
            string titulo = Console.ReadLine();  // Guardamos el título ingresado

            // Insertamos el título en el árbol
            arbol.Insertar(titulo);
        }

        return arbol;
    }

    // Función para mostrar el menú
    static void Menu()
    {
        // Llamamos a CrearCatalogo() para obtener el árbol con los títulos
        ArbolBinario arbol = CrearCatalogo();

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

            // Si el usuario selecciona la opción "1", se realiza la búsqueda
            if (opcion == "1")
            {
                // Solicitamos el título a buscar
                Console.Write("Ingrese el título que desea buscar: ");
                string tituloBuscar = Console.ReadLine();

                // Llamamos al método de búsqueda del árbol
                string resultado = arbol.Buscar(tituloBuscar);

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
