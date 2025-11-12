using System;

class Nodo
{
    public int Dato;
    public Nodo Izq, Der;
    public Nodo(int dato) { Dato = dato; }
}

class ArbolBST
{
    public Nodo Raiz;

    public void Insertar(int valor)
    {
        Raiz = InsertarRec(Raiz, valor);
    }

    private Nodo InsertarRec(Nodo n, int v)
    {
        if (n == null) return new Nodo(v);
        if (v < n.Dato) n.Izq = InsertarRec(n.Izq, v);
        else n.Der = InsertarRec(n.Der, v);
        return n;
    }

    //suma y cuenta pares  y impares en un solo método
    public int SumarYContar(Nodo n, ref int pares, ref int impares)
    {
        if (n == null) return 0;

        if (n.Dato % 2 == 0) pares++;
        else impares++;

        return n.Dato
             + SumarYContar(n.Izq, ref pares, ref impares)
             + SumarYContar(n.Der, ref pares, ref impares);
    }

    public void PostOrden(Nodo n)
    {
        if (n == null) return;
        PostOrden(n.Izq);
        PostOrden(n.Der);
        Console.Write(n.Dato + " ");
    }
}
class Program
{
    static void Main()
    {
        ArbolBST arbol = new ArbolBST();

        Console.Write("¿Cuántos valores ingresará? ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.Write("Valor " + (i + 1) + ": ");
            arbol.Insertar(int.Parse(Console.ReadLine()));
        }

        int pares = 0, impares = 0;
        int suma = arbol.SumarYContar(arbol.Raiz, ref pares, ref impares);

        Console.WriteLine("\nPostorden:");
        arbol.PostOrden(arbol.Raiz);

        Console.WriteLine("\n\nSuma: " + suma);
        Console.WriteLine("Pares: " + pares);
        Console.WriteLine("Impares: " + impares);

        Console.ReadKey();
    }
}
