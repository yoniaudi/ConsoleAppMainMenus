using Ex04.Menus.Test.MainMenus;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            startMainMenuUsingInterfaces();
            startMainMenuUsingDelegates();
        }

        private static void startMainMenuUsingInterfaces()
        {
            MainMenuInterfaces mainMenuInterfaces = new MainMenuInterfaces();

            mainMenuInterfaces.Show();
        }

        private static void startMainMenuUsingDelegates()
        {
            MainMenuDelegates mainMenuDelegates = new MainMenuDelegates();

            mainMenuDelegates.Show();
        }
    }
}