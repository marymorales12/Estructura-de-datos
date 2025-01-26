using System;
using System.Collections.Generic; // Necesario para trabajar con la clase Stack

class Program
{
    static void Main()
    {
        int n = 3; // Número de discos
        Hanoi(n);  // Llamamos al método para resolver las Torres de Hanoi con n discos
    }

    // Método que resuelve el problema de las Torres de Hanoi usando pilas
    static void Hanoi(int n)
    {
        // Creamos 3 pilas, una para cada torre (A, B, C)
        Stack<int> A = new Stack<int>(); // Torre A (inicialmente contiene todos los discos)
        Stack<int> B = new Stack<int>(); // Torre B (vacía)
        Stack<int> C = new Stack<int>(); // Torre C (vacía)

        // Inicializamos la torre A con los discos (el disco más grande está al fondo)
        for (int i = n; i >= 1; i--)
        {
            A.Push(i); // Apilamos los discos en la torre A
        }

        // Calculamos el número total de movimientos necesarios: 2^n - 1
        int totalMoves = (int)Math.Pow(2, n) - 1;

        // Determinamos las torres de origen, destino y auxiliar según si el número de discos es par o impar
        char source, destination, auxiliary;
        if (n % 2 == 0)
        {
            source = 'A';
            destination = 'B';
            auxiliary = 'C';
        }
        else
        {
            source = 'A';
            destination = 'C';
            auxiliary = 'B';
        }

        // Realizamos los movimientos iterativamente
        for (int move = 1; move <= totalMoves; move++)
        {
            // Si el número de movimientos es impar, movemos de la torre fuente a la torre destino
            if (move % 3 == 1)
            {
                MoveDisk(A, C, source, destination);
            }
            // Si el número de movimientos es divisible por 3, movemos de la torre fuente a la torre auxiliar
            else if (move % 3 == 2)
            {
                MoveDisk(A, B, source, auxiliary);
            }
            // Si el número de movimientos es 0 mod 3, movemos de la torre auxiliar a la torre destino
            else
            {
                MoveDisk(B, C, auxiliary, destination);
            }
        }
    }

    // Método para mover un disco de una torre a otra y mostrar el movimiento
    static void MoveDisk(Stack<int> from, Stack<int> to, char fromName, char toName)
    {
        // Sacamos el disco de la torre 'from'
        int disk = from.Pop();

        // Apilamos el disco en la torre 'to'
        to.Push(disk);

        // Mostramos el movimiento realizado
        Console.WriteLine($"Mover disco {disk} de {fromName} a {toName}");
    }
}
