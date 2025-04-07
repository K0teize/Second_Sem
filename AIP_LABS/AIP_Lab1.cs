

public class Human
{
    public string Name { get; set; }
    public string City { get; set; }
    public List<NumberInfo> Numbers { get; set; }
    public Human(string name, string city)
    {
        Name = name;
        City = city;
        Numbers = new List<NumberInfo>();
    }
    public void AddNumber(NumberInfo numberInfo)
    {
        Numbers.Add(numberInfo);
    }
}

public class NumberInfo
{
    public string PNumber { get; set; }
    public string PNumber_op {  get; set; }
    public string Data {  get; set; }
    
    public NumberInfo(string pnumber, string pnumber_op,string data)
    {
        PNumber = pnumber;
        PNumber_op = pnumber_op;
        Data = data;

    }
   
}

public class Lab1
{
    private static List<Human> HumanList = new List<Human>();   
    static void Main()
    {
        
        bool task = true;
        while (task)
        {
            Console.WriteLine("Меню");
            Console.WriteLine("1. Ввод данных абонента ");
            Console.WriteLine("2. Выборка по дате заключения договора");
            Console.WriteLine("3. Выборка по оператору связи");
            Console.WriteLine("4. Выборка по номеру телефона");
            Console.WriteLine("5. Выборка по городу проживания");
            Console.WriteLine("6. Выход");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    bool base_task = true;
                    Console.WriteLine("Введите ФИО абонента");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите город проживания абонента");
                    string city = Console.ReadLine();
                    Human human = new(name,city);
                    while (base_task)
                    {
                        Console.WriteLine("Введите номер телефона абонента");
                        string pnumber = Console.ReadLine();
                        Console.WriteLine("Введите оператора связи");
                        string pnumber_op = Console.ReadLine();
                        Console.WriteLine("Введите дату заключения договора");
                        string data = Console.ReadLine();
                        NumberInfo phone = new NumberInfo(pnumber, pnumber_op, data);
                        human.AddNumber(phone);
                        Console.WriteLine("Есть ли еще номера телефона у абонента? Введите 'N' если нет дополнительных номеров. ");
                        string temp_option = Console.ReadLine();
                        if (temp_option.ToUpper() == "N")
                        {
                            base_task = false;
                        }
                    }
                    HumanList.Add(human);

                    break;
                case 2: 
                    Console.WriteLine("Введите дату заключения договора:");
                    string tempdata = Console.ReadLine();
                    foreach(var people in HumanList)
                    {
                        foreach(var num in people.Numbers)
                        {
                            if(tempdata == num.Data)
                            {
                                Console.WriteLine($"ФИО абонента: {people.Name}\nГород проживания абонента: {people.City}\nНомер абонента: {num.PNumber}\nОператор связи: {num.PNumber_op}\nДата заключения договора: {num.Data}\n");
                            }
                        }
                    }
                    break;
                case 3: 
                    Console.WriteLine("Введите оператора связи");
                    string tempoper = Console.ReadLine();
                    foreach(var people in HumanList)
                    {
                        foreach (var num in people.Numbers)
                        {
                            if(tempoper == num.PNumber_op)
                            {
                                Console.WriteLine($"ФИО абонента: {people.Name}\nГород проживания абонента: {people.City}\nНомер абонента: {num.PNumber}\nОператор связи: {num.PNumber_op}\nДата заключения договора: {num.Data}\n");
                            }
                        }
                    }
                    break;
                case 4: 
                    Console.WriteLine("Введите номер телефона");
                    string tempnum = Console.ReadLine();
                    foreach(var people in HumanList)
                    {
                        foreach( var num in people.Numbers)
                        {
                            if(tempnum == num.PNumber)
                            {
                                Console.WriteLine($"ФИО абонента: {people.Name}\nГород проживания абонента: {people.City}\nНомер абонента: {num.PNumber}\nОператор связи: {num.PNumber_op}\nДата заключения договора: {num.Data}\n");
                            }
                        }
                    }
                    break;
                case 5: 
                    Console.WriteLine("Введите город проживания");
                    string tempcity = Console.ReadLine();
                    foreach(var people in HumanList)
                    {
                        if (tempcity == people.City)
                        {
                            foreach(var num in people.Numbers)
                            {
                                Console.WriteLine($"ФИО абонента: {people.Name}\nГород проживания абонента: {people.City}\nНомер абонента: {num.PNumber}\nОператор связи: {num.PNumber_op}\nДата заключения договора: {num.Data}\n");
                            }
                        }
                    }
                    break;
                case 6: 
                    task = false;
                    break;
            }
            
        }
    }
}
