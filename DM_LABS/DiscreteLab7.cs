class Program
{
    static void Wave(double[,] arr, int n1, int m1, int n2, int m2)
    {
        double inf = double.PositiveInfinity;
        int n = arr.GetLength(0);
        double[,] arr2 = new double[n + 2, n + 2];
        for (int i = 0; i < n + 2; i++)
        {
            for (int j = 0; j < n + 2; j++)
            {
                if (i == 0 || j == 0 || i == n + 1 || j == n + 1)
                {
                    arr2[i, j] = -1;
                }
                else
                {
                    arr2[i, j] = arr[i - 1, j - 1];
                }
            }
        }
        arr2[n1 + 1, m1 + 1] = 0;
        for (int k = 0; k < n * n; k++)
        {
            for (int i = 0; i < n + 2; i++)
            {
                for (int j = 0; j < n + 2; j++)
                {
                    if (arr2[i, j] != inf && arr2[i, j] != -1)
                    {
                        if (arr2[i - 1, j] > arr2[i, j])
                        {
                            arr2[i - 1, j] = arr2[i, j] + 1;
                        }
                        if (arr2[i, j - 1] > arr2[i, j])
                        {
                            arr2[i, j - 1] = arr2[i, j] + 1;
                        }
                        if (arr2[i + 1, j] > arr2[i, j])
                        {
                            arr2[i + 1, j] = arr2[i, j] + 1;
                        }
                        if (arr2[i, j + 1] > arr2[i, j])
                        {
                            arr2[i, j + 1] = arr2[i, j] + 1;
                        }
                    }
                }
            }
        }
        if (arr2[n2 + 1, m2 + 1] != inf)
        {
            Console.WriteLine($"Значение в точке: {arr2[n2 + 1, m2 + 1]}");
        }
        else
        {
            Console.WriteLine($"Невозможно дойти до точки");
        }
    }

    static void Main()
    {
        double i = double.PositiveInfinity;
        double[,] arr =
        {
            { i, i, i, -1, -1 },
            { i, -1, i, i, i },
            { i, -1, i, -1, i },
            { i, i, i, -1, i },
            { i, i, i, -1, i }
        };
        Wave(arr, 3, 1, 3, 4);
    }
}