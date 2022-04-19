using System;
public class FunConsole : IConsole
{
    public void Clear()
    {
        Console.Clear();
        Random rng = new Random();
        int newColor = rng.Next(0, 16);

        Console.BackgroundColor = (ConsoleColor)newColor;
        Console.WriteLine("I cleared it!");
    }

    public void WriteLine(string s)
    {
        Random rng = new Random();
        int newColor = rng.Next(0, 16);
        Console.ForegroundColor = (ConsoleColor)newColor;
        bool capitalize = false;
        foreach (char c in s)
        {
            if (capitalize)
            {
                Console.Write(c.ToString().ToUpper());
            }
            else
            {
                Console.Write(c.ToString().ToLower());
            }
            capitalize = !capitalize;
        }
        Console.Write("\n");
    }

    public void Write(string s)
    {
        Console.WriteLine("\n\n\n\n\n" + s + "\n\n\n\n\n");
    }

    public void Write(object o)
    {
        Console.Write(o);
    }
    public void WriteLine(object o)
    {
        Console.WriteLine(o);
    }
    public string ReadLine()
    {
        return Console.ReadLine();
    }
    public ConsoleKeyInfo ReadKey()
    {
        return Console.ReadKey();
    }
    public void Beep()
    {
        Console.Beep();
    }
}