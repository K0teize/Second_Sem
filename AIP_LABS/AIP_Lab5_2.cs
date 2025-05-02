public class Lab
{
    class Calculation
    {
        public int a;
        public int b;
        public Calculation(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public int Add() { return a+b; }
        public int Sub() { return a - b; }
        public int Mul() { return a * b; }
        public int Div()
        {
            if(b == 0)
            {
                throw new DivideByZeroException();
            }
            return a / b;
        }

    }
    public delegate int CalculationDelegate();
    class Program
    {
        static void Main(string[] args)
        {
            Calculation Test1 = new Calculation(1, 2);
            CalculationDelegate del1 = () =>
            {
                int Action1 = Test1.Add();
                int Action2 = new Calculation(Action1, Test1.b).Sub();
                int Action3 = new Calculation(Action2, Test1.b).Mul();
                return Action3;
            };
            int result1 = del1();

            Calculation Test2 = new Calculation(65, 15);
            CalculationDelegate del2 = () =>
            {
                int Action1 = Test2.Mul();
                int Action2 = new Calculation(Action1, Test2.a).Sub();
                int Action3 = new Calculation(Action2, Test2.a).Div();
                return Action3;
            };
            int result2 = del2();
            Console.WriteLine($"Результат первой группы операций: {result1}\nРезультат второй группы операций: {result2}");
        }
    }

}