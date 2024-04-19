using Ex04.Menus.Test.Actions;

namespace Ex04.Menus.Test.MainMenus
{
    internal class MainMenuInterfaces
    {
        public void Show()
        {
            Interfaces.MainMenu mainMenu = new Interfaces.MainMenu("Interfaces Main Menu");
            Interfaces.MenuItem showDateTime = new Interfaces.MenuItem("Show Date/Time");
            Interfaces.MenuItem showDate = new Interfaces.MenuItem("Show Date");
            Interfaces.MenuItem showTime = new Interfaces.MenuItem("Show Time");
            Interfaces.MenuItem versionAndCapitals = new Interfaces.MenuItem("Version and Capitals");
            Interfaces.MenuItem capitals = new Interfaces.MenuItem("Count Capitals");
            Interfaces.MenuItem version = new Interfaces.MenuItem("Show Version");

            mainMenu.AddMenuItem(showDateTime);
            mainMenu.AddMenuItem(versionAndCapitals);
            showDateTime.AddMenuItem(showDate);
            showDateTime.AddMenuItem(showTime);
            showDate.AttachObserver(new ShowDate());
            showTime.AttachObserver(new ShowTime());
            versionAndCapitals.AddMenuItem(capitals);
            versionAndCapitals.AddMenuItem(version);
            capitals.AttachObserver(new CountCapitals());
            version.AttachObserver(new ShowVersion());
            mainMenu.Show();
        }
    }
}
