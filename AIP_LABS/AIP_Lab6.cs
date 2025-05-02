public class Car
{
    public string Brand { get; set; }
    public string Owner_name { get; set; }
    public string Date { get; set; }
    public bool Washed { get; set; }
    public Car(string brand, string owner_name, string date, bool washed)
    {
        Brand = brand;
        Owner_name = owner_name;
        Date = date;
        Washed = washed;
    }
}

class Garage
{
    public List<Car> Cars {  get; set; }
    public Garage()
    {
        Cars = new List<Car>();
    }
    public void garageAdd(Car car)
    {
        Cars.Add(car);
    }
    public void garageInfo( )
    {
        foreach(var car in Cars)
        {
            Console.WriteLine($"Марка автомобиля: {car.Brand}\nВладелец автомобиля: {car.Owner_name}\nГод выпуска: {car.Date}\nМашина помыта: {car.Washed}\n");
        }
    }
}

public class CarWasher
{
    public static bool WashingCar(Car car)
    {
       if(!car.Washed)
        {
            car.Washed = true;
            return true;
        }
        else
        {
            return false;
        }
    }
}

public delegate bool WashingCarDelegate(Car car);
public class Lab7
{
    private static Garage garage = new Garage();
    static void Main(string[] args)
    {
        bool task = true;
        while (task)
        {
            Console.WriteLine("Введите марку автомобиля:");
            string brand = Console.ReadLine();
            Console.WriteLine("Введите ФИО владельца:");
            string owner_name = Console.ReadLine();
            Console.WriteLine("Введите год выпуска автомобиля:");
            string date = Console.ReadLine();
            Console.WriteLine("Машина помыта? (y/n):");
            string temp = Console.ReadLine();
            bool washed = false;
            if (temp == "y")
            {
                washed = true;
            }
            Console.WriteLine("Есть ли еще автомобили? (y/n)");
            string exit = Console.ReadLine();
            if (exit == "n")
            {
                task = false;
            }
            Car car = new Car(brand, owner_name, date, washed);
            garage.garageAdd(car);
            WashingCarDelegate washingCarDelegate = CarWasher.WashingCar;
            bool WasWashed = washingCarDelegate(car);
            
        }
        garage.garageInfo();
    }

       
}