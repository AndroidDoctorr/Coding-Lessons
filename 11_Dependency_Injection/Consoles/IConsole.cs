public interface IConsole
{
    void Clear();
    void Write(string s);
    void Write(object o);
    void WriteLine(string s);
    void WriteLine(object o);
    string ReadLine();
    ConsoleKeyInfo ReadKey();
    void Beep();
}