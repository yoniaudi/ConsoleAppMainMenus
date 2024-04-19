namespace Ex04.Menus.Test.Actions
{
    public class CountCapitals : Interfaces.IMenuItemObserver
    {
        public void Action()
        {
            int capitalLettersCount = 0;
            string inputString = null;
            string amountOfCapitalLettersMsg = null;

            Console.WriteLine("Enter a sentence: ");
            inputString = Console.ReadLine();

            foreach (char letter in inputString)
            {
                if (char.IsUpper(letter))
                {
                    capitalLettersCount++;
                }
            }

            amountOfCapitalLettersMsg = $"The amount of capital letters in the sentence is: {capitalLettersCount}{Environment.NewLine}";
            Console.WriteLine(amountOfCapitalLettersMsg);
        }
    }
}