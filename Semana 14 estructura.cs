using System;

// Clase que representa un producto ferretero 
public class ProductoFerretero
{
    public string Nombre { get; set; }  // Nombre del producto.
    public double Precio { get; set; }  // Precio del producto.
    public int Cantidad { get; set; }  // Cantidad disponible en la ferretería.
    public string CategoriaFerreteria { get; set; }  // Categoría del producto en la ferretería (ej. herramientas, materiales, etc.)

    // Constructor que inicializa un producto ferretero con sus propiedades.
    public ProductoFerretero(string nombre, double precio, int cantidad, string categoriaFerreteria)
    {
        Nombre = nombre;
        Precio = precio;
        Cantidad = cantidad;
        CategoriaFerreteria = categoriaFerreteria;  // Asigna la categoría del producto.
    }

    // Método que devuelve una representación de texto del producto ferretero.
    public override string ToString()
    {
        return $"{Nombre} - ${Precio} - Cantidad: {Cantidad} - Categoría: {CategoriaFerreteria}";
    }
}

// Clase que representa un nodo en el árbol binario de productos ferreteros.
public class NodoArbol
{
    public ProductoFerretero Producto { get; set; }  // Almacena el producto ferretero en lugar de un dato genérico.
    public NodoArbol Izquierda { get; set; }  // Referencia al hijo izquierdo.
    public NodoArbol Derecha { get; set; }    // Referencia al hijo derecho.

    // Constructor que inicializa un nodo con un producto ferretero.
    public NodoArbol(ProductoFerretero producto)
    {
        Producto = producto;
        Izquierda = null;
        Derecha = null;
    }
}

// Clase que representa el árbol binario de productos ferreteros.
public class ArbolBinario
{
    public NodoArbol Raiz { get; set; }  // Referencia a la raíz del árbol.

    // Constructor que inicializa un árbol vacío (sin raíz).
    public ArbolBinario()
    {
        Raiz = null;  // Inicializa la raíz como nula.
    }

    // Método público para insertar un producto ferretero en el árbol.
    public void Insertar(ProductoFerretero producto)
    {
        Raiz = InsertarRecursivo(Raiz, producto);  // Llama a la función recursiva para insertar el producto.
    }

    // Función recursiva que inserta un producto ferretero en el árbol.
    private NodoArbol InsertarRecursivo(NodoArbol nodo, ProductoFerretero producto)
    {
        // Si el nodo es nulo, hemos encontrado una posición vacía para insertar el nuevo producto.
        if (nodo == null)
        {
            return new NodoArbol(producto);  // Crea un nuevo nodo con el producto y lo devuelve.
        }

        // Si el nombre del producto es menor que el del nodo actual, lo insertamos en el subárbol izquierdo.
        if (string.Compare(producto.Nombre, nodo.Producto.Nombre) < 0)
        {
            nodo.Izquierda = InsertarRecursivo(nodo.Izquierda, producto);  // Llama recursivamente para insertar en el subárbol izquierdo.
        }
        // Si el nombre del producto es mayor que el del nodo actual, lo insertamos en el subárbol derecho.
        else if (string.Compare(producto.Nombre, nodo.Producto.Nombre) > 0)
        {
            nodo.Derecha = InsertarRecursivo(nodo.Derecha, producto);  // Llama recursivamente para insertar en el subárbol derecho.
        }

        return nodo;  // Devuelve el nodo actual para asegurar la estructura del árbol.
    }

    // Método público para buscar un producto ferretero en el árbol.
    public ProductoFerretero Buscar(string nombre)
    {
        return BuscarRecursivo(Raiz, nombre);  // Llama a la función recursiva para buscar el producto.
    }

    // Función recursiva para buscar un producto ferretero en el árbol.
    private ProductoFerretero BuscarRecursivo(NodoArbol nodo, string nombre)
    {
        // Si el nodo es nulo, significa que el producto no está en el árbol.
        if (nodo == null)
        {
            return null;
        }

        // Si el nombre del producto es igual al del nodo actual, hemos encontrado el producto.
        if (string.Compare(nombre, nodo.Producto.Nombre) == 0)
        {
            return nodo.Producto;  // Devuelve el producto encontrado.
        }

        // Si el nombre del producto es menor que el del nodo actual, lo buscamos en el subárbol izquierdo.
        if (string.Compare(nombre, nodo.Producto.Nombre) < 0)
        {
            return BuscarRecursivo(nodo.Izquierda, nombre);  // Busca en el subárbol izquierdo.
        }
        else
        {
            return BuscarRecursivo(nodo.Derecha, nombre);  // Busca en el subárbol derecho.
        }
    }

    // Método público para realizar un recorrido Inorden (izquierda, nodo, derecha).
    public void RecorridoInorden()
    {
        RecorridoInordenRecursivo(Raiz);  // Llama a la función recursiva para recorrer el árbol en Inorden.
        Console.WriteLine();  // Imprime una línea nueva después del recorrido.
    }

    // Función recursiva que realiza un recorrido Inorden.
    private void RecorridoInordenRecursivo(NodoArbol nodo)
    {
        if (nodo != null)  // Si el nodo no es nulo, seguimos recorriendo el árbol.
        {
            RecorridoInordenRecursivo(nodo.Izquierda);  // Recorre el subárbol izquierdo.
            Console.Write(nodo.Producto + " ");  // Imprime el producto del nodo actual.
            RecorridoInordenRecursivo(nodo.Derecha);  // Recorre el subárbol derecho.
        }
    }

    // Método público para realizar un recorrido Preorden (nodo, izquierda, derecha).
    public void RecorridoPreorden()
    {
        RecorridoPreordenRecursivo(Raiz);  // Llama a la función recursiva para recorrer el árbol en Preorden.
        Console.WriteLine();  // Imprime una línea nueva después del recorrido.
    }

    // Función recursiva que realiza un recorrido Preorden.
    private void RecorridoPreordenRecursivo(NodoArbol nodo)
    {
        if (nodo != null)  // Si el nodo no es nulo, seguimos recorriendo el árbol.
        {
            Console.Write(nodo.Producto + " ");  // Imprime el producto del nodo actual.
            RecorridoPreordenRecursivo(nodo.Izquierda);  // Recorre el subárbol izquierdo.
            RecorridoPreordenRecursivo(nodo.Derecha);  // Recorre el subárbol derecho.
        }
    }

    // Método público para realizar un recorrido Postorden (izquierda, derecha, nodo).
    public void RecorridoPostorden()
    {
        RecorridoPostordenRecursivo(Raiz);  // Llama a la función recursiva para recorrer el árbol en Postorden.
        Console.WriteLine();  // Imprime una línea nueva después del recorrido.
    }

    // Función recursiva que realiza un recorrido Postorden.
    private void RecorridoPostordenRecursivo(NodoArbol nodo)
    {
        if (nodo != null)  // Si el nodo no es nulo, seguimos recorriendo el árbol.
        {
            RecorridoPostordenRecursivo(nodo.Izquierda);  // Recorre el subárbol izquierdo.
            RecorridoPostordenRecursivo(nodo.Derecha);  // Recorre el subárbol derecho.
            Console.Write(nodo.Producto + " ");  // Imprime el producto del nodo actual.
        }
    }
}

// Clase que contiene el método principal para interactuar con el usuario.
public class Programa
{
    public static void Main(string[] args)
    {
        ArbolBinario arbol = new ArbolBinario();  // Crea una nueva instancia del árbol binario.
        int opcion;  // Variable para almacenar la opción seleccionada por el usuario.

        do
        {
            // Muestra el menú con las opciones disponibles.
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Insertar producto ferretero");
            Console.WriteLine("2. Buscar producto ferretero");
            Console.WriteLine("3. Recorrido Inorden");
            Console.WriteLine("4. Recorrido Preorden");
            Console.WriteLine("5. Recorrido Postorden");
            Console.WriteLine("6. Salir");
            Console.Write("Ingrese la opción: ");

            // Intenta leer la opción seleccionada por el usuario.
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                // Dependiendo de la opción seleccionada, realiza una acción.
                switch (opcion)
                {
                    case 1:
                        // Inserta un producto ferretero en el árbol.
                        Console.Write("Ingrese el nombre del producto ferretero: ");
                        string nombre = Console.ReadLine();  // Lee el nombre del producto.
                        Console.Write("Ingrese el precio del producto ferretero: ");
                        double precio = double.Parse(Console.ReadLine());  // Lee el precio del producto.
                        Console.Write("Ingrese la cantidad del producto ferretero: ");
                        int cantidad = int.Parse(Console.ReadLine());  // Lee la cantidad disponible.
                        Console.Write("Ingrese la categoría del producto ferretero (ej. herramientas, materiales, etc.): ");
                        string categoriaFerreteria = Console.ReadLine();  // Lee la categoría del producto.
                        ProductoFerretero producto = new ProductoFerretero(nombre, precio, cantidad, categoriaFerreteria);  // Crea el producto.
                        arbol.Insertar(producto);  // Inserta el producto en el árbol.
                        break;
                    case 2:
                        // Busca un producto ferretero en el árbol.
                        Console.Write("Ingrese el nombre del producto ferretero a buscar: ");
                        string nombreBuscar = Console.ReadLine();  // Lee el nombre del producto a buscar.
                        ProductoFerretero encontrado = arbol.Buscar(nombreBuscar);  // Realiza la búsqueda.
                        if (encontrado != null)
                        {
                            Console.WriteLine($"Producto ferretero encontrado: {encontrado}");
                        }
                        else
                        {
                            Console.WriteLine("Producto ferretero no encontrado.");
                        }
                        break;
                    case 3:
                        // Realiza un recorrido Inorden del árbol.
                        Console.Write("Recorrido Inorden: ");
                        arbol.RecorridoInorden();
                        break;
                    case 4:
                        // Realiza un recorrido Preorden del árbol.
                        Console.Write("Recorrido Preorden: ");
                        arbol.RecorridoPreorden();
                        break;
                    case 5:
                        // Realiza un recorrido Postorden del árbol.
                        Console.Write("Recorrido Postorden: ");
                        arbol.RecorridoPostorden();
                        break;
                    case 6:
                        // Salir del programa.
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        // Si la opción no es válida, muestra un mensaje de error.
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
            else
            {
                // Si la opción ingresada no es un número, muestra un mensaje de error.
                Console.WriteLine("Opción inválida.");
            }
        } while (opcion != 6);  // El ciclo se repite hasta que el usuario seleccione la opción de salir (opción 6).
    }
}
