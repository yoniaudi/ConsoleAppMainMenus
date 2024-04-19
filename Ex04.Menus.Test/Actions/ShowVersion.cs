namespace Ex04.Menus.Test.Actions
{
    public class ShowVersion : Interfaces.IMenuItemObserver
    {
        public void Action()
        {
            Console.WriteLine("Version: 24.1.4.9633");
            Console.WriteLine();
        }
    }
}