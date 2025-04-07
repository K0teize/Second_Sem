public class PhNumber
{
    public string Number { get; set; }
    public string Operator { get; set; }
    public PhNumber(string number,string ooperator)
    {
        Number = number;
        Operator = ooperator;
    }

}

public class Lab6
{
    static void Main(string[] args)
    {
        
        List<PhNumber> numbers = new List<PhNumber>();
        Dictionary<string, int> operFreq = new Dictionary<string, int>();

        Console.WriteLine("Введите количество абонентов");
        int c = int.Parse(Console.ReadLine());
        for (int i = 0; i < c; i++)
        {
            Console.WriteLine("Введите оператора");
            string ooperator = Console.ReadLine();
            Console.WriteLine("Введите номер телефона");
            string number = Console.ReadLine();
            numbers.Add(new PhNumber(number, ooperator));
            if (operFreq.ContainsKey(ooperator))
            {
                operFreq[ooperator]++;
            }
            else
            {
                operFreq[ooperator] = 1;
            }
        }
        foreach(var pair in operFreq)
        {
            Console.WriteLine($"Оператор: {pair.Key}, Частота: {pair.Value}");
        }
    }
}

