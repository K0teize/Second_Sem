class lab
{
    static void AlgDeikstra(int[,] graph, int start, int end, int vertex)
    {
        int[] distance = new int[vertex];
        bool[] visited = new bool[vertex];

        for (int i = 0; i < vertex; i++)
        {
            distance[i] = int.MaxValue;
            visited[i] = false;
        }
        distance[start] = 0;

        for (int i = 0; i < vertex; i++)
        {
            int MinWeight = int.MaxValue;
            int MinIndex = -1;
            for (int j = 0; j < vertex; j++)
            {
                if (!visited[j] && distance[j] < MinWeight)
                {
                    MinWeight = distance[j];
                    MinIndex = j;
                }
            }

            visited[MinIndex] = true;
            for (int j = 0; j < vertex; j++)
            {
                if (!visited[j] && graph[MinIndex,j] != 0 && distance[MinIndex] != int.MaxValue && distance[MinIndex] + graph[MinIndex, j] < distance[j])
                {
                    distance[j] = distance[MinIndex] + graph[MinIndex, j];
                }
            }

        }
        Console.WriteLine($"Кратчайшее расстояние от вершины {start} до вершины {end}: {distance[end]}");
    }

    static void Main()
    {
        int vertex = 6;
        int[,] graph = new int[6,6]
        {
            {0,5,0,0,2,4 },
            {5,0,12,0,0,1 },
            {0,12,0,9,0,3 },
            {0,0,9,0,7,10 },
            {2,0,0,7,0,8 },
            {4,1,3,10,8,0 },

        };
        Console.WriteLine("Введите начальную вершину:");
        int start = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите конечную вершину:");
        int end = int.Parse(Console.ReadLine());
        AlgDeikstra(graph,start,end,vertex);
    }
}