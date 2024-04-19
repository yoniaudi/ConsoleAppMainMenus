namespace Ex04.Menus.Test.Actions
{
    public class ShowTime : Interfaces.IMenuItemObserver
    {
        public void Action()
        {
            string currentTime = $"Time: {DateTime.Now.ToString("HH:mm:ss")}{Environment.NewLine}";

            Console.WriteLine(currentTime);
        }
    }
}