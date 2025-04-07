public class FigureName
{
    public string Name { get; set; }

    
}

public interface ICounter
{
    public double GetSquare();
    public double GetPerimeter();

}

public class Circle : FigureName, ICounter
{
    public int Radius { get; set; }
    public Circle(int radius, string name) 
    {
        Name = name;
        Radius = radius;
    }
    public double GetSquare()
    {
        return Math.PI * Radius * Radius;
    }
    public double GetPerimeter()
    {
        return 2*Math.PI*Radius;
    }
   
}
public class Square : FigureName, ICounter
{
    public int Length { get; set; }
    public Square(int length,string name) 
    {
        Name = name;
        Length = length;
    }
    public double GetSquare()
    {
        return Length * Length;
    }
    public double GetPerimeter()
    {
        return 4 * Length;
    }
}
public class Triangle : FigureName, ICounter
{
    public int Length { get; set; }
    public Triangle(int length,string name) 
    {
        Name = name;
        Length = length;
    }
    public double GetSquare()
    {
        return (Length * Length * Math.Sqrt(3)) / 4;
    }
    public double GetPerimeter()
    {
        return 3*Length;
    }
}
public class Lab
{
    static void Main()
    {
        Circle circle = new Circle(5, "Окружность");
        Square square = new Square(5, "Квадрат");
        Triangle triangle = new Triangle(5, "Равносторонний треугольник");
        Console.WriteLine($"Фигура: {circle.Name}\nПлощадь фигуры: {circle.GetSquare()}\nПериметр фигуры: {circle.GetPerimeter()}\n");
        Console.WriteLine($"Фигура: {square.Name}\nПлощадь фигуры: {square.GetSquare()}\nПериметр фигуры: {square.GetPerimeter()}\n");
        Console.WriteLine($"Фигура: {triangle.Name}\nПлощадь фигуры: {triangle.GetSquare()}\nПериметр фигуры: {triangle.GetPerimeter()}\n");
    }
}