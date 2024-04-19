namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        public string Title { get; set; } = null;
        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();
        private readonly List<IMenuItemObserver> r_OnSelectedObservers = new List<IMenuItemObserver>();

        public MenuItem(string i_Title)
        {
            Title = i_Title;
        }

        private void show()
        {
            bool visible = true;

            while (visible)
            {
                int userChoice = 0;

                displayMenu();
                userChoice = getValidUserInput();

                if (userChoice == 0)
                {
                    visible = false;
                    Console.Clear();
                    break;
                }

                r_MenuItems[userChoice - 1].ExecuteActions();
            }
        }

        public void ExecuteActions()
        {
            Console.Clear();

            foreach (IMenuItemObserver observer in r_OnSelectedObservers)
            {
                observer.Action();
            }

            if (r_MenuItems.Count > 0)
            {
                show();
            }
        }

        private void displayMenu()
        {
            int indx = 1;
            string msg = $"**{Title}**";

            Console.WriteLine(msg);
            Console.WriteLine("------------------------");

            foreach (MenuItem menuItem in r_MenuItems)
            {
                msg = $"{indx++} -> {menuItem.Title}";
                Console.WriteLine(msg);
            }

            msg = $"0 -> Back";
            Console.WriteLine(msg);
            Console.WriteLine("------------------------");
        }

        private int getValidUserInput()
        {
            string rangeMsg = r_MenuItems.Count > 1 == true ? $"1 to {r_MenuItems.Count}" : "1";
            string choiceRangeMsg = $"Enter your request: ({rangeMsg} or press '0' to Exit).";
            string stringInput = null;
            bool isNumber = false;

            Console.WriteLine(choiceRangeMsg);
            stringInput = Console.ReadLine();
            isNumber = int.TryParse(stringInput, out int userChoice);

            while (isNumber == false || userChoice < 0 || userChoice > r_MenuItems.Count)
            {
                Console.WriteLine("Invalid input. Please try again.");
                stringInput = Console.ReadLine();
                isNumber = int.TryParse(stringInput, out userChoice);
            }

            return userChoice;
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            r_MenuItems.Add(i_MenuItem);
        }

        public void RemoveMenuItem(MenuItem i_MenuItem)
        {
            r_MenuItems.Remove(i_MenuItem);
        }

        public void AttachObserver(IMenuItemObserver i_MenuItemObserver)
        {
            r_OnSelectedObservers.Add(i_MenuItemObserver);
        }

        public void DetachObserver(IMenuItemObserver i_MenuItemObserver)
        {
            r_OnSelectedObservers.Remove(i_MenuItemObserver);
        }
    }
}