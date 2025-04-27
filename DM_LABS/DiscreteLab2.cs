
class Rib
{
    public int StartVertex { get; set; }
    public int EndVertex { get; set; }
    public int Weight { get; set; }
    public Rib(int start_vertex, int end_vertex, int weight)
    {
        StartVertex = start_vertex;
        EndVertex = end_vertex;
        Weight = weight;
    }
}
class Lab
{
    static void AlgPrima(int[,] matrice, int vertex)
    {
        List<int> vertexList = new List<int>();
        int MinSum = 0;
        int Vertex = 1;
        vertexList.Add(Vertex);
        while (vertexList.Count != vertex)
        {
            int TempMin = int.MaxValue;
            for (int i = 0; i < vertexList.Count(); i++)
            {
                for (int j = 0; j < vertex; j++)
                {
                    if (matrice[vertexList[i] - 1, j] < TempMin && matrice[vertexList[i] - 1, j] != 0 && !vertexList.Contains(j + 1))
                    {
                        TempMin = matrice[vertexList[i] - 1, j];
                        Vertex = j + 1;

                    }
                }
            }
            MinSum += TempMin;
            vertexList.Add(Vertex);
        }
        Console.WriteLine($"Минимальное вес остовного дерева:{MinSum} ");

    }
    static void AlgKraskal(int[,] matrice, int vertex)
    {
        List<int> VertexList = new List<int>();
        static List<Rib> GetRibs(int[,] matrice)
        {
            List<Rib> ribs = new List<Rib>();
            for (int i = 0; i < matrice.GetLength(0); i++)
            {
                for (int j = i + 1; j < matrice.GetLength(0); j++)
                {
                    if (matrice[i, j] != 0)
                    {
                        ribs.Add(new Rib(i + 1, j + 1, matrice[i, j]));
                    }
                }
            }
            return ribs;
        }
        List<Rib> ribs = GetRibs(matrice);
        ribs.Sort((a, b) => a.Weight.CompareTo(b.Weight));
        int MinSum = 0;
        VertexList.Add(ribs[0].StartVertex);
        VertexList.Add(ribs[0].EndVertex);
        MinSum += ribs[0].Weight;
        ribs.RemoveAt(0);
        while(VertexList.Count != vertex && ribs.Count()!=0)
        {
            if (VertexList.Contains(ribs[0].StartVertex) && !VertexList.Contains(ribs[0].EndVertex))
            {
                VertexList.Add(ribs[0].EndVertex);
                MinSum += ribs[0].Weight;
            }
            else if(!VertexList.Contains(ribs[0].StartVertex) && VertexList.Contains(ribs[0].EndVertex))
            {
                VertexList.Add(ribs[0].StartVertex);
                MinSum += ribs[0].Weight;
            }
            ribs.RemoveAt(0);

        }
        Console.WriteLine($"Минимальный вес остовного дерева:{MinSum}");
    }
        
  

    static void Main()
    {
        int vertex = 6;
        int[,] matrice = new int[6, 6]
        {
            { 0, 5, 0, 0, 4, 2 },
            { 5, 0, 12, 0, 0, 1 },
            { 0, 12, 0, 9, 0, 3 },
            { 0, 0, 9, 0, 7, 10 },
            { 2, 0, 0, 7, 0, 8 },
            { 4, 1, 3, 10, 8, 0 }
        };
        AlgPrima(matrice,vertex);
        AlgKraskal(matrice,vertex);
    }
}



