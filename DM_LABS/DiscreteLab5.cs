using System;
class Program
{
    static void Ford(double[,] arr, int start, int end)
    {
        double inf = double.PositiveInfinity;
        int n = arr.GetLength(0);
        double[] distances = new double[n];
        for (int i = 0; i < n; i++)
        {
            distances[i] = (i != start) ? inf : 0;
        }
        for (int k = 1; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (distances[i] + arr[i, j] < distances[j])
                    {
                        distances[j] = distances[i] + arr[i, j];
                    }
                }
            }
        }
        Console.WriteLine(distances[end] != inf ? $"Длина кратчайшего маршрута: {distances[end]}" : "Маршрута между точками нет.");
    }
    static void Main()
    {
        double i = double.PositiveInfinity;
        double[,] arr = {
            { i,1,i,i,3 },
            { i,i,8,7,1 },
            { i,i,i,1,-5 },
            { i,i,2,i,i },
            { i,i,i,4,i },
        };
        Ford(arr, 0, 4);
    }

}