//EJERCICIO 1//

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 1. Lista de asignaturas del curso.
        List<string> asignaturas = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
        
        // 2. Lista para almacenar las notas que se ingresen.
        List<double> notas = new List<double>();

        // 3. Solicitar la nota de cada asignatura.
        foreach (string asignatura in asignaturas)
        {
            // Solicitamos al usuario que ingrese la nota para la asignatura actual.
            Console.Write($"Introduce la nota en {asignatura}: ");
            
            // 4. Validamos la entrada para asegurarnos de que sea un número válido entre 0 y 10.
            double nota;
            while (!double.TryParse(Console.ReadLine(), out nota) || nota < 0 || nota > 10)
            {
                // Si el valor no es un número válido o está fuera del rango permitido, solicitamos la nota nuevamente.
                Console.Write("Por favor, introduce una nota válida entre 0 y 10: ");
            }
            
            // 5. Añadimos la nota ingresada a la lista de notas.
            notas.Add(nota);
        }

        // 6. Mostrar las asignaturas junto con sus notas.
        Console.WriteLine("\nLas notas obtenidas son:");
        for (int i = 0; i < asignaturas.Count; i++)
        {
            // Imprimimos en pantalla el mensaje en el formato solicitado: "En <asignatura> has sacado <nota>"
            Console.WriteLine($"En {asignaturas[i]} has sacado {notas[i]}");
        }
    }
}


//EJERCICIO 2//
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 1. Crear una lista para almacenar los números del 1 al 10
        List<int> numeros = new List<int>();

        // 2. Llenar la lista con los números del 1 al 10
        for (int i = 1; i <= 10; i++)
        {
            // Añadir el número 'i' a la lista
            numeros.Add(i);
        }

        // 3. Mostrar los números en orden inverso, separados por comas
        Console.WriteLine("Los números en orden inverso son:");

        // 4. Recorrer la lista en orden inverso
        for (int i = numeros.Count - 1; i >= 0; i--)
        {
            // Imprimir el número actual
            // Si no es el último número, se imprime una coma después
            if (i != numeros.Count - 1)
            {
                Console.Write(", ");
            }
            Console.Write(numeros[i]);
        }
        
        // 5. Imprimir una nueva línea al final para que la salida sea más legible
        Console.WriteLine();
    }
}

// EJERCICIO 3//
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 1. Crear una lista para almacenar el abecedario
        List<char> abecedario = new List<char>();

        // 2. Llenar la lista con las letras del abecedario (de 'a' a 'z')
        for (char letra = 'a'; letra <= 'z'; letra++)
        {
            abecedario.Add(letra);
        }

        // 3. Eliminar las letras en las posiciones que son múltiplos de 3
        // Es importante iterar en sentido inverso para evitar problemas al eliminar elementos.
        for (int i = abecedario.Count - 1; i >= 0; i--)
        {
            // Comprobamos si el índice es múltiplo de 3
            if ((i + 1) % 3 == 0)  // (i + 1) porque las posiciones en la lista empiezan en 1
            {
                abecedario.RemoveAt(i);  // Eliminar la letra en la posición 'i'
            }
        }

        // 4. Mostrar la lista resultante después de eliminar las letras
        Console.WriteLine("El abecedario resultante es:");
        
        // Mostrar cada letra de la lista, separada por 

// EJERCICIO 4//
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 1. Crear una lista para almacenar los precios
        List<int> precios = new List<int> { 50, 75, 46, 22, 80, 65, 8 };

        // 2. Inicializar las variables para el precio menor y mayor
        int precioMenor = precios[0];  // Suponemos que el primer precio es el menor al inicio
        int precioMayor = precios[0];  // Suponemos que el primer precio es el mayor al inicio

        // 3. Recorrer la lista de precios para encontrar el menor y el mayor
        foreach (int precio in precios)
        {
            // Comprobar si el precio actual es menor que el menor encontrado hasta ahora
            if (precio < precioMenor)
            {
                precioMenor = precio;
            }

            // Comprobar si el precio actual es mayor que el mayor encontrado hasta ahora
            if (precio > precioMayor)
            {
                precioMayor = precio;
            }
        }

        // 4. Mostrar el precio menor y mayor
        Console.WriteLine($"El precio menor es: {precioMenor}");
        Console.WriteLine($"El precio mayor es: {precioMayor}");
    }
}

// EJERCICIO 5//
using System;
using System.Collections.Generic;
using System.Linq;  // Para usar el método "Average" y otras funciones de LINQ

class Program
{
    static void Main()
    {
        // 1. Preguntar al usuario por una muestra de números separados por comas
        Console.Write("Introduce una muestra de números separados por comas: ");
        string input = Console.ReadLine();  // Leemos la entrada del usuario

        // 2. Convertir la entrada de texto en una lista de números
      
