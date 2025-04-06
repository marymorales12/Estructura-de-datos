

using System;
using System.Collections.Generic;

namespace centralidad
{
    public class NodoRed
    {
        private int id;
        private List<int> vecinos;

        public NodoRed(int id)
        {
            this.id = id;
            vecinos = new List<int>();
        }

        public int GetId()
        {
            return id;
        }

        public void SetId(int nuevoId)
        {
            id = nuevoId;
        }

        public List<int> GetVecinos()
        {
            return vecinos;
        }

        public void SetVecinos(List<int> nuevaLista)
        {
            vecinos = nuevaLista;
        }

        public void AgregarVecino(int idVecino)
        {
            if (!vecinos.Contains(idVecino))
            {
                vecinos.Add(idVecino);
            }
        }
    }

    public class RedConectada
    {
        private List<NodoRed> nodos;

        public RedConectada()
        {
            nodos = new List<NodoRed>();
        }

        public List<NodoRed> GetNodos()
        {
            return nodos;
        }

        public void AgregarConexion(int id1, int id2)
        {
            NodoRed nodo1 = BuscarOCrear(id1);
            NodoRed nodo2 = BuscarOCrear(id2);

            nodo1.AgregarVecino(id2);
            nodo2.AgregarVecino(id1);
        }

        private NodoRed BuscarOCrear(int id)
        {
            for (int i = 0; i < nodos.Count; i++)
            {
                if (nodos[i].GetId() == id)
                    return nodos[i];
            }

            NodoRed nuevo = new NodoRed(id);
            nodos.Add(nuevo);
            return nuevo;
        }

        public NodoRed? ObtenerNodo(int id)
        {
            for (int i = 0; i < nodos.Count; i++)
            {
                if (nodos[i].GetId() == id)
                    return nodos[i];
            }
            return null;
        }

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
                    Console.Write($"{vecinos[j]} ");
                }
                Console.WriteLine();
            }
        }
    }

    public class CalculadoraCentralidad
    {
        private RedConectada red;

        public CalculadoraCentralidad(RedConectada red)
        {
            this.red = red;
        }

        public void CalcularGrado()
        {
            Console.WriteLine("\n Centralidad de Grado:");
            List<NodoRed> nodos = red.GetNodos();
            int total = nodos.Count - 1;
            for (int i = 0; i < nodos.Count; i++)
            {
                NodoRed nodo = nodos[i];
                double grado = (double)nodo.GetVecinos().Count / total;
                Console.WriteLine($"Nodo {nodo.GetId()}: {grado:F2}");
            }
        }

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
                    if (otro.GetId() != nodo.GetId())
                        suma += DistanciaMinima(nodo.GetId(), otro.GetId());
                }
                double cercania = (double)(n - 1) / suma;
                Console.WriteLine($"Nodo {nodo.GetId()}: {cercania:F2}");
            }
        }

        private int DistanciaMinima(int origenId, int destinoId)
        {
            HashSet<int> visitados = new HashSet<int>();
            Queue<(int id, int distancia)> cola = new Queue<(int id, int distancia)>();
            cola.Enqueue((origenId, 0));
            visitados.Add(origenId);

            while (cola.Count > 0)
            {
                (int actual, int distancia) = cola.Dequeue();
                NodoRed? nodoActual = red.ObtenerNodo(actual);

                if (nodoActual == null) continue;

                List<int> vecinos = nodoActual.GetVecinos();
                for (int i = 0; i < vecinos.Count; i++)
                {
                    int vecinoId = vecinos[i];
                    if (vecinoId == destinoId)
                        return distancia + 1;
                    if (!visitados.Contains(vecinoId))
                    {
                        visitados.Add(vecinoId);
                        cola.Enqueue((vecinoId, distancia + 1));
                    }
                }
            }

            return int.MaxValue;
        }
    }

    class AplicacionCentralidad
    {
        static void Main()
        {
            RedConectada red = new RedConectada();
            CalculadoraCentralidad calculadora = new CalculadoraCentralidad(red);
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

                string? entrada = Console.ReadLine();
                if (!int.TryParse(entrada, out opcion))
                {
                    opcion = -1;
                }

                switch (opcion)
                {
                    case 1:
                        Console.Write("ID del primer nodo: ");
                        string? entradaA = Console.ReadLine();
                        int a = int.TryParse(entradaA, out int valA) ? valA : 0;

                        Console.Write("ID del segundo nodo: ");
                        string? entradaB = Console.ReadLine();
                        int b = int.TryParse(entradaB, out int valB) ? valB : 0;

                        red.AgregarConexion(a, b);
                        Console.WriteLine("Conexión agregada. Presione una tecla...");
                        Console.ReadKey();
                        break;

                    case 2:
                        red.MostrarRed();
                        Console.WriteLine("Presione una tecla...");
                        Console.ReadKey();
                        break;

                    case 3:
                        calculadora.CalcularGrado();
                        Console.WriteLine("Presione una tecla...");
                        Console.ReadKey();
                        break;

                    case 4:
                        calculadora.CalcularCercania();
                        Console.WriteLine("Presione una tecla...");
                        Console.ReadKey();
                        break;

                    case 0:
                        Console.WriteLine(" Saliendo...");
                        break;

                    default:
                        Console.WriteLine(" Opción no válida.");
                        Console.ReadKey();
                        break;
                }

            } while (opcion != 0);
        }
    }
}
