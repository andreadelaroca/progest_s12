using System;
using System.Collections.Generic;

class Nodo
{
    public int Dato;
    public Nodo Izq, Der;

    public Nodo(int valor)
    {
        Dato = valor;
        Izq = Der = null;
    }
}

class ArbolBinario
{
    public Nodo Raiz;

    // Insertar valores en el árbol (BST)
    public void Insertar(int valor)
    {
        Raiz = InsertarRec(Raiz, valor);
    }

    private Nodo InsertarRec(Nodo nodo, int valor)
    {
        if (nodo == null)
            return new Nodo(valor);

        if (valor < nodo.Dato)
            nodo.Izq = InsertarRec(nodo.Izq, valor);
        else
            nodo.Der = InsertarRec(nodo.Der, valor);

        return nodo;
    }

    // Método para crear el espejo del árbol
    public void Espejar()
    {
        Raiz = EspejarRec(Raiz);
    }

    private Nodo EspejarRec(Nodo nodo)
    {
        if (nodo == null) return null;

        Nodo temp = nodo.Izq;
        nodo.Izq = EspejarRec(nodo.Der);
        nodo.Der = EspejarRec(temp);

        return nodo;
    }

    // Recorridos
    public void InOrden(Nodo nodo)
    {
        if (nodo != null)
        {
            InOrden(nodo.Izq);
            Console.Write(nodo.Dato + " ");
            InOrden(nodo.Der);
        }
    }

    public void PreOrden(Nodo nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.Dato + " ");
            PreOrden(nodo.Izq);
            PreOrden(nodo.Der);
        }
    }

    public void PostOrden(Nodo nodo)
    {
        if (nodo != null)
        {
            PostOrden(nodo.Izq);
            PostOrden(nodo.Der);
            Console.Write(nodo.Dato + " ");
        }
    }
}

class Program
{
    static void Main()
    {
        ArbolBinario arbol = new ArbolBinario();

        Console.WriteLine("=== CREACIÓN DEL ÁRBOL BINARIO ===");
        Console.WriteLine("Ingrese los valores separados por espacio (ejemplo: 1 2 3 4 5):");
        Console.Write("> ");
        string entrada = Console.ReadLine();

        string[] valores = entrada.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string val in valores)
        {
            if (int.TryParse(val, out int num))
                arbol.Insertar(num);
        }

        Console.WriteLine("\n=== ÁRBOL ESPEJO ===");
        arbol.Espejar();

        Console.Write("\nRecorrido INORDEN:   ");
        arbol.InOrden(arbol.Raiz);

        Console.Write("\nRecorrido PREORDEN:  ");
        arbol.PreOrden(arbol.Raiz);

        Console.Write("\nRecorrido POSTORDEN: ");
        arbol.PostOrden(arbol.Raiz);

        Console.WriteLine("\n\nPrograma finalizado ");
    }
}