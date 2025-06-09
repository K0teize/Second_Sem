using System;
class Program
{
    static void LittleAlg(double[,] Matrix)
    {
        int n = Matrix.GetLength(0);
        double inf = double.PositiveInfinity;
        double[,] matrix = (double[,])Matrix.Clone();
        double total = 0;
        while (n > 1)
        {
            total += RowsReduction(matrix, n, inf);
            total += ColumnsReduction(matrix, n, inf);
            var (bestRow, bestCol) = BestZero(matrix, n, inf);
            matrix[bestRow, bestCol] = inf;
            n--;
            matrix = MatrixReduction(matrix, bestRow, bestCol, n, inf);
        }
        Console.WriteLine(total);
    }
    static double RowsReduction(double[,] matrix, int n, double inf)
    {
        double sum = 0;
        for (int i = 0; i < n; i++)
        {
            double min = inf;
            for (int j = 0; j < n; j++)
                if (matrix[i, j] < min)
                    min = matrix[i, j];
            if (min != inf && min != 0)
            {
                sum += min;
                for (int j = 0; j < n; j++)
                    if (matrix[i, j] != inf)
                        matrix[i, j] -= min;
            }
        }
        return sum;
    }

    static double ColumnsReduction(double[,] matrix, int n, double inf)
    {
        double sum = 0;
        for (int j = 0; j < n; j++)
        {
            double min = inf;
            for (int i = 0; i < n; i++)
                if (matrix[i, j] < min)
                    min = matrix[i, j];

            if (min != inf && min != 0)
            {
                sum += min;
                for (int i = 0; i < n; i++)
                    if (matrix[i, j] != inf)
                        matrix[i, j] -= min;
            }
        }
        return sum;
    }
    static (int, int) BestZero(double[,] matrix, int n, double inf)
    {
        double maxScore = double.NegativeInfinity;
        int bestRow = -1;
        int bestCol = -1;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] == 0)
                {
                    double minRow = inf;
                    double minCol = inf;

                    for (int k = 0; k < n; k++)
                    {
                        if (k != j && matrix[i, k] < minRow) minRow = matrix[i, k];
                        if (k != i && matrix[k, j] < minCol) minCol = matrix[k, j];
                    }

                    double score = (minRow == inf ? 0 : minRow) + (minCol == inf ? 0 : minCol);
                    if (score > maxScore)
                    {
                        maxScore = score;
                        bestRow = i;
                        bestCol = j;
                    }
                }
            }
        }
        return (bestRow, bestCol);
    }

    static double[,] MatrixReduction(double[,] oldMatrix, int row, int col, int newSize, double inf)
    {
        double[,] newMatrix = new double[newSize, newSize];
        int newRow = 0;
        int newCol = 0;

        for (int i = 0; i < oldMatrix.GetLength(0); i++)
        {
            if (i == row) continue;
            newCol = 0;
            for (int j = 0; j < oldMatrix.GetLength(1); j++)
            {
                if (j == col) continue;
                newMatrix[newRow, newCol] = oldMatrix[i, j];
                newCol++;
            }
            newRow++;
        }
        return newMatrix;
    }
    static void Main()
    {
        double i = double.PositiveInfinity;
        double[,] test =
        {
            { i,23,45,12,67, },
            { 23,i,89,34,56, },
            { 45,89,i,71,18, },
            { 12,34,71,i,92, },
            { 67,56,18,92,i, },
        };
        LittleAlg(test);
    }
}
