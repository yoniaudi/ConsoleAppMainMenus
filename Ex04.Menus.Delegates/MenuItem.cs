namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        public string Title { get; set; } = null;
        public event Action GotSelected = null;
        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();

        public MenuItem(string i_Title)
        {
            Title = i_Title;
        }

        public MenuItem(string i_Title, Action i_Action)
        {
            Title = i_Title;
            GotSelected += i_Action;
        }

        private void show()
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
                    Console.Clear();
                    break;
                }

                r_MenuItems[userChoice - 1].Execute();
            }
        }

        public void Execute()
        {
            Console.Clear();

            if (r_MenuItems.Count == 0)
            {
                GotSelected?.Invoke();
            }
            else
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
    }
}