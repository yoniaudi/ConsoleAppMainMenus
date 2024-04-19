namespace Ex04.Menus.Test.Actions
{
    public class ShowDate : Interfaces.IMenuItemObserver
    {
        public void Action()
        {
            string currentDate = $"Date: {DateTime.Now.ToString("dd/MM/yyyy")}{Environment.NewLine}";

            Console.WriteLine(currentDate);
        }
    }
}