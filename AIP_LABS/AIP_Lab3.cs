using System;
class StackLab
{
    static void Main()
    {
        Stack<char> stack = new Stack<char>();
        string text = Console.ReadLine();
        bool ans = true;
        foreach(char element in text)
        {
            if (element == '(' || element == '{' || element == '[')
            {
                stack.Push(element);
            }
            if (element == ')'|| element == '}' || element == ']')
            {
                if(stack.Count == 0 || !Match(stack.Pop(),element))
                {
                    ans = false;
                }
            }
        }
        if (stack.Count == 1)
        {
            ans = false;
        }
        if (ans == false)
        {
            Console.WriteLine("Скобки расставлены неверно");
        }
        else
        {
            Console.WriteLine("Скобки расставлены верно");
        }
    }
    static bool Match(char op, char cl)
    {
        return (op == '(' && cl == ')' || op == '{' && cl == '}' || op == '[' && cl == ']');
    }
    
}



