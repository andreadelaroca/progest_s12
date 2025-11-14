using System;

namespace ArbolBinario
{
    // Nodo de un árbol binario
    class Nodo
    {
        public int Valor;
        public Nodo? Izquierdo; // ? indica que puede ser null
        public Nodo? Derecho;

        public Nodo(int valor)
        {
            Valor = valor;
            Izquierdo = null;
            Derecho = null;
        }
    }

    class Program
    {
        // Crea nodos de forma recursiva solicitando entrada al usuario
        // posicion se usa para mostrar dónde estamos creando el nodo (ej. "la raíz", "hijo izquierdo de 5")
        static Nodo? CrearNodoRecursivo(string posicion)
        {
            Console.Write($"¿Crear nodo en {posicion}? (s/n): ");
            string? respuesta = Console.ReadLine()?.Trim().ToLower(); //Trim() remueve espacios
            if (respuesta != "s")
                return null;

            int valor;
            while (true)
            {
                Console.Write("Ingrese un valor entero para el nodo: ");
                string? linea = Console.ReadLine();
                if (int.TryParse(linea, out valor))
                    break;
                Console.WriteLine("Entrada inválida. Por favor ingrese un número entero.");
            }

            Nodo nodo = new Nodo(valor);
            nodo.Izquierdo = CrearNodoRecursivo($"hijo izquierdo de {valor}");
            nodo.Derecho = CrearNodoRecursivo($"hijo derecho de {valor}");
            return nodo;
        }

        // Imprime el árbol en recorrido preorden
        static void Preorden(Nodo? nodo)
        {
            if (nodo == null)
                return;
            Console.Write(nodo.Valor + " ");
            Preorden(nodo.Izquierdo);
            Preorden(nodo.Derecho);
        }

        // Cuenta los nodos del árbol de forma recursiva
        static int ContarNodos(Nodo? nodo)
        {
            if (nodo == null)
                return 0;
            return 1 + ContarNodos(nodo.Izquierdo) + ContarNodos(nodo.Derecho);
        }

        static void Main(string[] args)
        {

            Nodo? raiz = CrearNodoRecursivo("la raíz");
            Console.WriteLine();

            if (raiz == null)
            {
                Console.WriteLine("El árbol está vacío.");
                Console.WriteLine("Cantidad de nodos: 0");
                return;
            }

            Console.WriteLine("Recorrido en preorden:");
            Preorden(raiz);
            Console.WriteLine();

            int cantidad = ContarNodos(raiz);
            Console.WriteLine($"Cantidad de nodos del árbol: {cantidad}");
        }
    }
}