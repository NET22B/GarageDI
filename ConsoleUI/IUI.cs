
namespace ConsoleUI
{
    public interface IUI
    {
        string GetString();
        string GetKey();
        void ShowMeny();
        void Print(string message);
        void Clear();
        void Meny(bool isFull, string options, string menyheading);
    }
}
