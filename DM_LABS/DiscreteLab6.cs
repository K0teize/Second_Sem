class lab
{
    static void Main()
    {
        int inf = int.MaxValue;
        int vertex = 4;
        int[,] matrice =
        { 
            {0,  1,  6, inf},
            {inf,0,  4, 1 },
            {inf,inf,0, inf},
            {inf,inf,1, 0 }
        };

        for (int i = 0; i < vertex; i++)
        {
            for (int j = 0; j<vertex; j++)
            {
                for(int k = 0; k<vertex; k++)
                {
                    if (matrice[j, k] > matrice[j, i] + matrice[i, k] && matrice[j,i]!=inf && matrice[i,k]!=inf)
                    {
                        matrice[j,k] = matrice[j, i]+matrice[i,k];
                    }
                }
            }
        }

        for (int i = 0;i < vertex; i++)
        {
            for(int j = 0; j < vertex; j++)
            {
                if (matrice[i, j] == inf)
                {
                    Console.WriteLine("inf");
                }
                else
                {
                    Console.WriteLine(matrice[i, j]);
                }
            }
        }
    }
}