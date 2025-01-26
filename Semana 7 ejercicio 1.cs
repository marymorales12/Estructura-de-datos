using System;
using System.Collections.Generic; // Usamos esta librería para trabajar con la clase Stack

class Program
{
    // Método principal
    static void Main()
    {
        // Definimos una expresión matemática como ejemplo
        string expression = "{12+(4*5)-[(5-1)+(12+5)]}";

        // Llamamos al método IsBalanced para verificar si la expresión está balanceada
        if (IsBalanced(expression))
        {
            // Si la expresión está balanceada, mostramos un mensaje
            Console.WriteLine("La fórmula está balanceada.");
        }
        else
        {
            // Si la expresión no está balanceada, mostramos un mensaje
            Console.WriteLine("La fórmula no está balanceada.");
        }
    }

    // Método que verifica si la expresión tiene los paréntesis balanceados
    static bool IsBalanced(string expression)
    {
        // Creamos una pila (Stack) para llevar un seguimiento de los paréntesis de apertura
        Stack<char> stack = new Stack<char>();

        // Recorremos cada carácter en la expresión
        foreach (char ch in expression)
        {
            // Si encontramos un paréntesis de apertura ('(', '{' o '['), lo agregamos a la pila
            if (ch == '(' || ch == '{' || ch == '[')
            {
                stack.Push(ch); // Apilamos el carácter de apertura
            }
            // Si encontramos un paréntesis de cierre (')', '}' o ']')
            else if (ch == ')' || ch == '}' || ch == ']')
            {
                // Si la pila está vacía, significa que no hay un paréntesis de apertura para este cierre
                if (stack.Count == 0)
                    return false; // La expresión no está balanceada

                // Sacamos el último paréntesis de apertura de la pila (el de más reciente)
                char open = stack.Pop();

                // Verificamos si el paréntesis de apertura coincide con el paréntesis de cierre
                if (!IsMatchingPair(open, ch))
                    return false; // Si no coincide, la expresión no está balanceada
            }
        }

        // Al final, si la pila está vacía, significa que todos los paréntesis de apertura tuvieron su par correspondiente
        return stack.Count == 0;
    }

    // Método auxiliar para verificar si los paréntesis coinciden (apertura y cierre)
    static bool IsMatchingPair(char open, char close)
    {
        // Comprobamos las combinaciones válidas de paréntesis
        return (open == '(' && close == ')') || 
               (open == '{' && close == '}') || 
               (open == '[' && close == ']');
    }
}
