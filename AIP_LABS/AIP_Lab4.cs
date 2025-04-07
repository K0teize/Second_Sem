public class lab5
{
    static void Main()
    {

        Console.WriteLine("Введите количество элементов:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите элементы: ");
        List<int> list = new List<int>();
        for(int i = 0; i < n; i++)
        {
            list.Add(int.Parse(Console.ReadLine()));  
        }
        HashSet<int> set = new HashSet<int>(list);
        Console.WriteLine("Список состоит их элементов: "+string.Join(' ',set));

        int maxcount = 1;
        List<int> maxcount_num = new List<int>();
        for(int i = 0;i < n; i++)
        {
            int currentnum = list[i];
            int count = 1;
            for(int j = i+1;j < n; j++)
            {
                if (list[j] == currentnum)
                {
                    count++;
                }
            }
            if (count > maxcount)
            {
                maxcount = count;
                maxcount_num.Clear();
                maxcount_num.Add(currentnum);
            }
            else if(count == maxcount)
            {
                maxcount_num.Add(currentnum);
            }
        }
        Console.WriteLine($"Наиболее часто встречающееся число: {string.Join(' ',maxcount_num)}");
    }
}