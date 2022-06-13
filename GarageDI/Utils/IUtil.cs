namespace GarageDI.Utils
{
    public interface IUtil
    {
        int AskForInt(string prompt);
        int AskForKey(string prompt);
        string AskForString(string prompt);
    }
}