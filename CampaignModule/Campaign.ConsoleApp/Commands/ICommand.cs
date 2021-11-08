namespace Campaign.ConsoleApp.Commands
{
    public interface ICommand
    {
        void Process(string[] arg);
    }
}
