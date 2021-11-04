using System;

namespace bankTeller
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Teller Nelson = new Teller();

            Nelson.RegisterClient();
            Nelson.ShowCummulative();
        }
    }

    class Teller
    {
        public string UserChoice { get; set; }
        public double UserDeposit { get; set; }


        public void RegisterClient()
        {
            Console.WriteLine("Enter your name:");
            //get the name
            //get other details

            Console.WriteLine("Please select account type. \nInput a number to choose:");
            Console.WriteLine("1. Savings \n2. Current \n3. Kids \n4. Corporate");
            int answerIndex = int.Parse(Console.ReadLine());
            switch (answerIndex)
            {
                case 1:
                    UserChoice = "savings";
                    break;
                case 2:
                    UserChoice = "current";
                    break;
                default:
                    UserChoice = "savings";
                    break;
            }
            Console.WriteLine("Please enter your initial amount: ");
            UserDeposit = double.Parse(Console.ReadLine());
        }

        double GetRate()
        {
            if (UserChoice == "savings")
            {
                return 5.2/100;
            }
            else if (UserChoice == "current")
            {
                return 7.4/100;
            }
            else return 0.00;
        }

        double CalculateCummulative(int month, double rate, double initial)
        {
            double interest;
            double vat = 7.5/100;
            double currentAmount = initial;

            for (int i = 0; i < month; i++)
            {
                interest = ((rate / 100) * currentAmount);
                currentAmount = (currentAmount + interest); // -(vat*currentAmount);
            }

            return Math.Round(currentAmount, 3);
        }

        public void DisplayMessage(int numberOfMonths, string accountType)
        {
            Console.WriteLine("With a " + accountType + " account, your gross amount after " + numberOfMonths + " months will be " + CalculateCummulative(numberOfMonths,GetRate(),UserDeposit));
        }

        public void ShowCummulative()
        {
            int[] monthDurations = {6, 9, 12, 24, 60 };
            switch (UserChoice)
            {
                case "savings":
                    foreach(int duration in monthDurations)
                    {
                        DisplayMessage(duration, "savings");
                    }
                    break;
                case "current":
                    foreach (int duration in monthDurations)
                    {
                        DisplayMessage(duration, "current");
                    }
                    break;
                default:
                    Console.WriteLine("Gerrout!");
                    break;
            }
        }
    }
}
