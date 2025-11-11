/*
Escribir el programa que tenga una función recursiva que encuentre el
número de nodos de un árbol binario. Se debe imprimir el árbol en recorrido
preorden y a continuación mostrar la cantidad de nodos del árbol.
(Importante: se deben solicitar los datos como entrada para crear el
árbol)
*/

using System;
using System.Collections.Generic;
namespace GraphExample
{
	class Graph 
	{
    	private readonly int _numVertices;
    	private readonly List<int>[] _adjacencyList;

    	public Graph(int numVertices)
    	{
        	_numVertices = numVertices;
        	_adjacencyList = new List<int>[numVertices];
        	for (int i = 0; i < numVertices; i++)
            	_adjacencyList[i] = new List<int>();
    	}

    	public void AddEdge(int from, int to)
    	{
        	// para grafo dirigido
        	_adjacencyList[from].Add(to);
    	}

    	public void DFS(int start)
    	{
        	bool[] visited = new bool[_numVertices];
        	DFSUtil(start, visited);
    	}

    	private void DFSUtil(int v, bool[] visited)
    	{
        	visited[v] = true;
        	Console.WriteLine("Visited node " + v);

        	foreach (int neighbour in _adjacencyList[v])
        	{
            	if (!visited[neighbour])
                	DFSUtil(neighbour, visited);
        	}
    	}

    	public void BFS(int start)
    	{
        	bool[] visited = new bool[_numVertices];
        	Queue<int> queue = new Queue<int>();

        	visited[start] = true;
        	queue.Enqueue(start);

        	while (queue.Count > 0)
        	{
            	int v = queue.Dequeue();
            	Console.WriteLine("Visited node " + v);

            	foreach (int neighbour in _adjacencyList[v])
            	{
                	if (!visited[neighbour])
                	{
                    	visited[neighbour] = true;
                    	queue.Enqueue(neighbour);
                	}
            	}
        	}
    	}
}

	class Program
	{
    	static void Main(string[] args)
		{
			// crear grafo con 5 nodos (0-4)
			
			
			Graph g = new Graph(5);

        	g.AddEdge(0, 1);
        	g.AddEdge(0, 2);
        	g.AddEdge(1, 2);
        	g.AddEdge(2, 0);
        	g.AddEdge(2, 3);
        	g.AddEdge(3, 3);

        	Console.WriteLine("Depth First Traversal (desde el nodo 2):");
        	g.DFS(2);

        	Console.WriteLine("Breadth First Traversal (desde el nodo 2):");
        	g.BFS(2);
    	}
	}
}