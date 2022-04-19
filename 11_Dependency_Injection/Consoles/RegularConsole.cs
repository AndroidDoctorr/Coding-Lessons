public class RegularConsole : IConsole
{
    public void Clear()
    {
        Console.Clear();
    }
    public void Write(string s)
    {
        Console.Write(s);
    }
    public void Write(object o)
    {
        Console.Write(o);
    }
    public void WriteLine(string s)
    {
        Console.WriteLine(s);
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