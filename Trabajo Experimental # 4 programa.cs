
using System;
using System.Collections.Generic;

namespace centralidad
{
    // Clase NodoRed: Representa un nodo en la red, con un identificador y lista de vecinos
    public class NodoRed
    {
        private int id;  // Identificador único del nodo
        private List<int> vecinos;  // Lista de IDs de los nodos vecinos

        // Constructor que inicializa el nodo con un ID
        public NodoRed(int id)
        {
            this.id = id;
            vecinos = new List<int>();  // Inicializamos la lista de vecinos vacía
        }

        // Obtiene el ID del nodo
        public int GetId()
        {
            return id;
        }

        // Establece un nuevo ID para el nodo
        public void SetId(int nuevoId)
        {
            id = nuevoId;
        }

        // Obtiene la lista de vecinos del nodo
        public List<int> GetVecinos()
        {
            return vecinos;
        }

        // Establece una nueva lista de vecinos para el nodo
        public void SetVecinos(List<int> nuevaLista)
        {
            vecinos = nuevaLista;
        }

        // Agrega un vecino al nodo, solo si no está presente ya
        public void AgregarVecino(int idVecino)
        {
            if (!vecinos.Contains(idVecino))
            {
                vecinos.Add(idVecino);  // Agregamos el vecino a la lista
            }
        }
    }

    // Clase RedConectada: Representa la red de nodos, maneja conexiones y nodos existentes
    public class RedConectada
    {
        private List<NodoRed> nodos;  // Lista que guarda todos los nodos en la red

        // Constructor que inicializa la lista de nodos vacía
        public RedConectada()
        {
            nodos = new List<NodoRed>();
        }

        // Obtiene la lista completa de nodos
        public List<NodoRed> GetNodos()
        {
            return nodos;
        }

        // Agrega una conexión bidireccional entre dos nodos
        public void AgregarConexion(int id1, int id2)
        {
            NodoRed nodo1 = BuscarOCrear(id1);  // Busca o crea el nodo 1
            NodoRed nodo2 = BuscarOCrear(id2);  // Busca o crea el nodo 2

            nodo1.AgregarVecino(id2);  // Agrega nodo2 como vecino de nodo1
            nodo2.AgregarVecino(id1);  // Agrega nodo1 como vecino de nodo2
        }

        // Busca un nodo por su ID. Si no existe, lo crea y lo agrega a la lista
        private NodoRed BuscarOCrear(int id)
        {
            for (int i = 0; i < nodos.Count; i++)
            {
                if (nodos[i].GetId() == id)
                    return nodos[i];  // Retorna el nodo si ya existe
            }

            // Si no se encuentra el nodo, lo creamos y agregamos
            NodoRed nuevo = new NodoRed(id);
            nodos.Add(nuevo);
            return nuevo;
        }

        // Obtiene un nodo de la red dado su ID
        public NodoRed? ObtenerNodo(int id)
        {
            for (int i = 0; i < nodos.Count; i++)
            {
                if (nodos[i].GetId() == id)
                    return nodos[i];
            }
            return null;  // Si no existe, retorna null
        }

        // Muestra todos los nodos y sus conexiones
        public void MostrarRed()
        {
            Console.WriteLine("\n Lista de nodos y conexiones:");
            for (int i = 0; i < nodos.Count; i++)
            {
                NodoRed nodo = nodos[i];
                Console.Write($"Nodo {nodo.GetId()} conectado con: ");
                List<int> vecinos = nodo.GetVecinos();
                for (int j = 0; j < vecinos.Count; j++)
                {
                    Console.Write($"{vecinos[j]} ");  // Muestra los vecinos de cada nodo
                }
                Console.WriteLine();
            }
        }
    }

    // Clase CalculadoraCentralidad: Calcula diferentes métricas de centralidad para la red
    public class CalculadoraCentralidad
    {
        private RedConectada red;  // Instancia de la red conectada

        // Constructor que inicializa la calculadora con la red
        public CalculadoraCentralidad(RedConectada red)
        {
            this.red = red;
        }

        // Calcula la centralidad de grado (número de conexiones de un nodo dividido por el total de nodos)
        public void CalcularGrado()
        {
            Console.WriteLine("\n Centralidad de Grado:");
            List<NodoRed> nodos = red.GetNodos();
            int total = nodos.Count - 1;  // Total de nodos menos 1, para el cálculo normalizado
            for (int i = 0; i < nodos.Count; i++)
            {
                NodoRed nodo = nodos[i];
                double grado = (double)nodo.GetVecinos().Count / total;  // Calcular la centralidad de grado
                Console.WriteLine($"Nodo {nodo.GetId()}: {grado:F2}");
            }
        }

        // Calcula la centralidad de cercanía (cercanía a todos los demás nodos)
        public void CalcularCercania()
        {
            Console.WriteLine("\n Centralidad de Cercanía:");
            List<NodoRed> nodos = red.GetNodos();
            int n = nodos.Count;
            for (int i = 0; i < n; i++)
            {
                NodoRed nodo = nodos[i];
                int suma = 0;
                for (int j = 0; j < n; j++)
                {
                    NodoRed otro = nodos[j];
                    if (otro.GetId() != nodo.GetId())  // No calculamos la distancia del nodo consigo mismo
                        suma += DistanciaMinima(nodo.GetId(), otro.GetId());  // Suma de distancias mínimas
                }
                double cercania = (double)(n - 1) / suma;  // Centralidad de cercanía
                Console.WriteLine($"Nodo {nodo.GetId()}: {cercania:F2}");
            }
        }

        // Calcula la distancia mínima entre dos nodos utilizando búsqueda en amplitud (BFS)
        private int DistanciaMinima(int origenId, int destinoId)
        {
            HashSet<int> visitados = new HashSet<int>();  // Conjunto para nodos ya visitados
            Queue<(int id, int distancia)> cola = new Queue<(int id, int distancia)>();  // Cola para BFS
            cola.Enqueue((origenId, 0));  // Empezamos con el nodo de origen y distancia 0
            visitados.Add(origenId);

            while (cola.Count > 0)
            {
                (int actual, int distancia) = cola.Dequeue();  // Obtenemos el nodo actual y su distancia
                NodoRed? nodoActual = red.ObtenerNodo(actual);  // Buscamos el nodo actual en la red

                if (nodoActual == null) continue;  // Si no encontramos el nodo, continuamos

                List<int> vecinos = nodoActual.GetVecinos();  // Conseguimos los vecinos del nodo actual
                for (int i = 0; i < vecinos.Count; i++)
                {
                    int vecinoId = vecinos[i];
                    if (vecinoId == destinoId)  // Si encontramos el nodo destino, retornamos la distancia
                        return distancia + 1;
                    if (!visitados.Contains(vecinoId))
                    {
                        visitados.Add(vecinoId);  // Marcamos el vecino como visitado
                        cola.Enqueue((vecinoId, distancia + 1));  // Añadimos el vecino a la cola con distancia incrementada
                    }
                }
            }

            return int.MaxValue;  // Si no se encuentra el destino, retornamos un valor máximo
        }
    }

    // Clase AplicacionCentralidad: Maneja la interfaz de usuario y las opciones de menú
    class AplicacionCentralidad
    {
        static void Main()
        {
            RedConectada red = new RedConectada();  // Creamos la red conectada
            CalculadoraCentralidad calculadora = new CalculadoraCentralidad(red);  // Creamos la calculadora de centralidad
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("******** UNIVERSIDAD ESTATAL AMAZONICA (UEA)  **********");
                Console.WriteLine("=== CÁLCULO DE MÉTRICAS DE CENTRALIDADES ===");
                Console.WriteLine("1. Agregar conexión entre nodos");
                Console.WriteLine("2. Mostrar red");
                Console.WriteLine("3. Calcular centralidad de grado");
                Console.WriteLine("4. Calcular centralidad de cercanía");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");

                // Leer la opción del usuario y validarla
                string? entrada = Console.ReadLine();
                if (!int.TryParse(entrada, out opcion))
                {
                    opcion = -1;
                }

                switch (opcion)
                {
                    case 1:
                        // Opción para agregar una conexión entre nodos
                        Console.Write("ID del primer nodo: ");
                        string? entradaA = Console.ReadLine();
                        int a = int.TryParse(entradaA, out int valA) ? valA : 0;

                        Console.Write("ID del segundo nodo: ");
                        string? entradaB = Console.ReadLine();
                        int b = int.TryParse(entradaB, out int valB) ? valB : 0;

                        red.AgregarConexion(a, b);  // Agregar la conexión
                        Console.WriteLine("Conexión agregada. Presione una tecla...");
                        Console.ReadKey();
                        break;

                    case 2:
                        // Opción para mostrar la red
                        red.MostrarRed();
                        Console.WriteLine("Presione una tecla...");
                        Console.ReadKey();
                        break;

                    case 3:
                        // Opción para calcular la centralidad de grado
                        calculadora.CalcularGrado();
                        Console.WriteLine("Presione una tecla...");
                        Console.ReadKey();
                        break;

                    case 4:
                        // Opción para calcular la centralidad de cercanía
                        calculadora.CalcularCercania();
                        Console.WriteLine("Presione una tecla...");
                        Console.ReadKey();
                        break;

                    case 0:
                        // Opción para salir del programa
                        Console.WriteLine(" Saliendo...");
                        break;

                    default:
                        // Opción para manejar entradas no válidas
                        Console.WriteLine(" Opción no válida.");
                        Console.ReadKey();
                        break;
                }

            } while (opcion != 0);  // Repetir el menú hasta que el usuario elija salir
        }
    }
}
