namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        public string Title { get; set; } = null;
        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();

        public MainMenu(string i_Title)
        {
            Title = i_Title;
        }

        public void Show()
        {
            bool visible = true;

            while (visible == true)
            {
                int userChoice = 0;

                displayMenu();
                userChoice = getValidUserInput();

                if (userChoice == 0)
                {
                    visible = false;
                    break;
                }

                r_MenuItems[userChoice - 1].ExecuteActions();
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

            msg = $"0 -> Exit";
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
    }
}