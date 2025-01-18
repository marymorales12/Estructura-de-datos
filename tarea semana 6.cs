// Ejercicio 5
using System;

public class Node
{
    public int Data;  // Almacena el valor del nodo (tipo entero)
    public Node Next; // Referencia al siguiente nodo

    // Constructor para inicializar el nodo con un valor
    public Node(int data)
    {
        Data = data;
        Next = null;  // Inicializa el puntero al siguiente nodo como null
    }
}

public class LinkedList
{
    public Node Head;  // Cabeza de la lista enlazada

    // Constructor para inicializar una lista vacía
    public LinkedList()
    {
        Head = null;  // Inicializa la lista vacía
    }

    // Método para agregar un nodo al final de la lista
    public void AddLast(int value)
    {
        Node newNode = new Node(value);  // Crear un nuevo nodo con el valor
        if (Head == null)  // Si la lista está vacía
        {
            Head = newNode;  // El nuevo nodo será la cabeza de la lista
        }
        else
        {
            // Si la lista no está vacía, se recorre hasta el final y se agrega el nuevo nodo
            Node temp = Head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = newNode;  // Enlazamos el nuevo nodo al final
        }
    }

    // Método para agregar un nodo al principio de la lista
    public void AddFirst(int value)
    {
        Node newNode = new Node(value);  // Crear un nuevo nodo con el valor
        newNode.Next = Head;  // El siguiente nodo será la actual cabeza
        Head = newNode;  // El nuevo nodo será la nueva cabeza de la lista
    }

    // Método para contar el número de nodos en la lista
    public int Count()
    {
        int count = 0;
        Node temp = Head;
        // Recorremos la lista y contamos los nodos
        while (temp != null)
        {
            count++;
            temp = temp.Next;
        }
        return count;
    }

    // Método para mostrar todos los elementos de la lista
    public void Display()
    {
        Node temp = Head;
        // Recorremos la lista y mostramos cada elemento
        while (temp != null)
        {
            Console.Write(temp.Data + " ");
            temp = temp.Next;
        }
        Console.WriteLine();  // Imprimir una línea nueva al final de la lista
    }
}

public class Program
{
    // Función para verificar si un número es primo
    public static bool IsPrime(int number)
    {
        if (number <= 1) return false;  // Los números menores o iguales a 1 no son primos
        for (int i = 2; i <= Math.Sqrt(number); i++)  // Solo verificamos hasta la raíz cuadrada de 'number'
        {
            if (number % i == 0)  // Si es divisible por 'i', no es primo
                return false;
        }
        return true;  // Si no tiene divisores, es primo
    }

    // Función para verificar si un número es Armstrong
    public static bool IsArmstrong(int number)
    {
        int sum = 0;
        int temp = number;
        int digits = (int)Math.Log10(number) + 1;  // Cantidad de dígitos del número

        while (temp > 0)
        {
            int digit = temp % 10;  // Extraer el último dígito
            sum += (int)Math.Pow(digit, digits);  // Sumar el dígito elevado a la potencia de 'digits'
            temp /= 10;  // Eliminar el último dígito
        }

        return sum == number;  // Si la suma es igual al número original, es un número Armstrong
    }

    public static void Main(string[] args)
    {
        LinkedList primeList = new LinkedList();  // Crear lista para números primos
        LinkedList armstrongList = new LinkedList();  // Crear lista para números Armstrong

        // Agregar números del 1 al 100 a las listas
        for (int i = 1; i <= 100; i++)
        {
            // Si el número es primo, lo agregamos al final de la lista de primos
            if (IsPrime(i))
            {
                primeList.AddLast(i);
            }

            // Si el número es Armstrong, lo agregamos al principio de la lista de Armstrong
            if (IsArmstrong(i))
            {
                armstrongList.AddFirst(i);
            }
        }

        // Mostrar el número de elementos en cada lista
        Console.WriteLine($"Número de elementos en la lista de números primos: {primeList.Count()}");
        Console.WriteLine($"Número de elementos en la lista de números Armstrong: {armstrongList.Count()}");

        // Mostrar cuál lista tiene más elementos
        if (primeList.Count() > armstrongList.Count())
        {
            Console.WriteLine("La lista de números primos tiene más elementos.");
        }
        else if (primeList.Count() < armstrongList.Count())
        {
            Console.WriteLine("La lista de números Armstrong tiene más elementos.");
        }
        else
        {
            Console.WriteLine("Ambas listas tienen el mismo número de elementos.");
        }

        // Mostrar todos los datos insertados en ambas listas
        Console.WriteLine("Lista de números primos:");
        primeList.Display();  // Mostrar todos los números primos

        Console.WriteLine("Lista de números Armstrong:");
        armstrongList.Display();  // Mostrar todos los números Armstrong
    }
}

// Ejercicio 8
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Declaramos la lista principal donde almacenaremos los números reales
        List<double> mainList = new List<double>();

        // Pedimos al usuario que ingrese la cantidad de datos a cargar
        Console.Write("¿Cuántos datos deseas ingresar? ");
        int n = int.Parse(Console.ReadLine()); // Leer el número de elementos a cargar

        // Cargamos los datos en la lista principal
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Ingrese el valor {i + 1}: ");
            double input = double.Parse(Console.ReadLine()); // Leer el dato ingresado
            mainList.Add(input); // Agregar el dato a la lista principal
        }

        // Calcular el promedio de los datos en la lista principal
        double sum = 0; // Variable para almacenar la suma de los números
        foreach (var number in mainList)
        {
            sum += number; // Sumar cada valor de la lista
        }
        double average = sum / mainList.Count; // Promedio = suma / cantidad de elementos

        // Crear dos listas adicionales: una para los números menores o iguales al promedio, y otra para los mayores
        List<double> lessThanOrEqualToAverage = new List<double>();
        List<double> greaterThanAverage = new List<double>();

        // Clasificar los números en las dos listas basadas en el promedio
        foreach (var number in mainList)
        {
            if (number <= average)
            {
                lessThanOrEqualToAverage.Add(number); // Agregar a la lista de menores o iguales al promedio
            }
            else
            {
                greaterThanAverage.Add(number); // Agregar a la lista de mayores al promedio
            }
        }

        // Mostrar los resultados
        Console.WriteLine("\nLos datos cargados en la lista principal:");
        foreach (var number in mainList)
        {
            Console.WriteLine(number); // Mostrar los números cargados
        }

        Console.WriteLine($"\nEl promedio de los datos es: {average}");

        Console.WriteLine("\nLos datos menores o iguales al promedio:");
        foreach (var number in lessThanOrEqualToAverage)
        {
            Console.WriteLine(number); // Mostrar los números menores o iguales al promedio
        }

        Console.WriteLine("\nLos datos mayores al promedio:");
        foreach (var number in greaterThanAverage)
        {
            Console.WriteLine(number); // Mostrar los números mayores al promedio
        }
    }
}
