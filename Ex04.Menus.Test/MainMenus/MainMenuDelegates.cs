using Ex04.Menus.Test.Actions;

namespace Ex04.Menus.Test.MainMenus
{
    internal class MainMenuDelegates
    {
        public void Show()
        {
            Delegates.MainMenu mainMenu = new Delegates.MainMenu("Delegates Main Menu");
            Delegates.MenuItem showDateTime = new Delegates.MenuItem("Show Date/Time");
            Delegates.MenuItem versionAndCapitals = new Delegates.MenuItem("Version and Capitals");

            mainMenu.AddMenuItem(showDateTime);
            mainMenu.AddMenuItem(versionAndCapitals);
            showDateTime.AddMenuItem(new Delegates.MenuItem("Show Date", new Actions.ShowDate().Action));
            showDateTime.AddMenuItem(new Delegates.MenuItem("Show Time", new ShowTime().Action));
            versionAndCapitals.AddMenuItem(new Delegates.MenuItem("Count Capitals", new CountCapitals().Action));
            versionAndCapitals.AddMenuItem(new Delegates.MenuItem("Show Version", new ShowVersion().Action));
            mainMenu.Show();
        }
    }
}
