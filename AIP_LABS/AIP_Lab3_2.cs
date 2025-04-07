
class Stack2Lab
{
    static void Main()
    {
        string text = Console.ReadLine(); 
        string[] elem = text.Split(' ');
        Stack<int> stack = new Stack<int>();
        bool isCorrect = true;
        foreach(var item in elem)
        {
            if(item == "+" || item == "-"|| item == "*" || item == "/")
            {
                if(stack.Count < 2)
                {
                    isCorrect = false;
                    break;
                }
                int el2 = stack.Pop();
                int el1 = stack.Pop();
                switch(item)
                {
                    case "+":
                        stack.Push(el1 + el2);
                        break;
                    case "-":
                        stack.Push(el1 - el2);
                        break;
                    case "*":
                        stack.Push(el1 * el2);
                        break;
                    case "/":
                        try
                        {
                            stack.Push(el1 / el2);
                        }
                        catch(DivideByZeroException ex)
                        {
                            Console.WriteLine("Деление на ноль невозможно");
                            isCorrect = false;
                        }
                        break;
                }
            }
            else
            {
                stack.Push(int.Parse(item));
            } 
        }
        if (stack.Count>1)
        {
            isCorrect = false;
        }
        if (isCorrect)
        {
            Console.WriteLine(stack.Pop());
        }
        else
        {
            Console.WriteLine("Запись неверная");
        }   
    }
}


