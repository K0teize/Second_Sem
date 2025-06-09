class Edge
{
    public int v1 { get; set; }
    public int v2 { get; set; }
    public Edge(int v1, int v2)
    {
        this.v1 = v1;
        this.v2 = v2;
    }
}
class Program
{
    static void Bridge(int[,] arr)
    {
        int bridgecount = 0;
        int n = arr.GetLength(0);
        bool[] visited = new bool[n];
        List<Edge> edges = new List<Edge>();

        void DFS(int num, int[,] arr2)
        {
            visited[num] = true;
            for (int i = 0; i < n; i++)
            {
                if (arr2[num, i] != 0 && !visited[i])
                {
                    DFS(i, arr2);
                }
            }
        }

        List<Edge> Prim(int[,] arr)
        {
            bool[] inMST = new bool[n];
            inMST[0] = true;
            int visitedCount = 1;
            while (visitedCount < n)
            {
                int min = int.MaxValue;
                int v1 = -1;
                int v2 = -1;
                for (int i = 0; i < n; i++)
                {
                    if (inMST[i])
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (!inMST[j] && arr[i, j] != 0 && arr[i, j] < min)
                            {
                                min = arr[i, j];
                                v2 = j;
                                v1 = i;
                            }
                        }
                    }
                }
                edges.Add(new Edge(v1, v2));
                inMST[v2] = true;
                visitedCount++;
            }
            return edges;
        }
        edges = Prim(arr);
        for (int k = 0; k < edges.Count; k++)
        {
            int count = 0;
            int[,] arr2 = (int[,])arr.Clone();
            arr2[edges[k].v1, edges[k].v2] = arr2[edges[k].v2, edges[k].v1] = 0;
            Array.Fill(visited, false);
            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    DFS(i, arr2);
                    count++;
                }
            }
            if (count > 1)
            {
                Console.WriteLine($"Ребро {edges[k].v1 + 1},{edges[k].v2 + 1} является мостом.");
                bridgecount++;
            }
        }
        if (bridgecount == 0)
        {
            Console.WriteLine("Мостов нет.");
        }
    }
static void Main()
    {
        int[,] arr =
        {
            {0,2,5,0 },
            {2,0,3,7 },
            {5,3,0,0 },
            {0,7,0,0 },
        };
        Bridge(arr);
    }
}

