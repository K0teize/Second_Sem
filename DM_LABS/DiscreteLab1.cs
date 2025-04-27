public class Programm
{
    static void Main()
    {
        //Ввод матрицы
        Console.WriteLine("Введите размер матрицы смежности:");
        int n = int.Parse(Console.ReadLine());
        int[,] array = new int[n, n];
        Console.WriteLine("Введите элементы матрицы смежности:");
        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < n; j++)
            {
                array[i, j] = int.Parse(Console.ReadLine());
            }
        }
        List<int> list = new List<int>();
        for(int i=0; i < n; i++)
        {
            list.Add(i);
        }
        //Первый алгоритм
        int count = 0;
        while(list.Count != 0)
        {
            List<int> templist = new List<int>();
            templist.Add(list[0]);
            list.Remove(list[0]);
            int cur = 0;
            while (list.Count != 0)
            {
                for(int i = cur; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (array[i, j] == 1)
                        {
                            templist.Add(j);
                            list.Remove(j);
                        }
                    }
                }
                cur++;
                HashSet<int> set = new HashSet<int>(templist);
                templist = set.ToList();
                if (cur == n + 1)
                {
                    break;
                }
            }

            count++;
        }
        Console.WriteLine($"Количество компонентов связанности: {count}");
        //Второй алгоритм
        
        List<int> tlist = new List<int>();

        tlist.Add(1);
        int curr = 0;
        while (tlist.Count != n)
        {
            curr++;
            List<int> templist1 = new List<int>();
            for (int i = 0; i <= curr-1; i++)
            {
                if (array[curr,i] == 1)
                {
                    templist1.Add(tlist[i]);
                }
            }
            if (tlist.Count != curr + 1)
            {
                templist1.Add(tlist[curr-1]+1);
            }
            tlist.Add(Enumerable.Min(templist1));
        }
        for(int i = 0;i < n; i++)
        {
            for (int j = 1; j < tlist.Count; j++)
            {
                for(int k = 0; k < j; k++)
                {
                    if(tlist[k] > tlist[i])
                    {
                        if (tlist[i] == 1)
                        {
                            tlist[k] = tlist[j];
                        }
                    }
                }
            }
        }
        HashSet<int> s = new HashSet<int>(tlist);
        tlist=s.ToList<int>();

        Console.WriteLine($"Количество компонентов связанности: {tlist.Count}");
          
    }
}
