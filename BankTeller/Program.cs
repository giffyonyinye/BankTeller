using System;

namespace BankTeller
{
    class Program
    {
        static void Main(string[] args)
        {

            Teller Giffy = new Teller();

            Giffy.CustomerDetails();
            Giffy.ShowCummulative();
        }
    }

    class Teller
    {
        public string AccountType { get; set; }
        public double UserDeposit { get; set; }


        public void CustomerDetails()
        {
            string name;
            Console.WriteLine("Enter your Account Number:");
            name = Console.ReadLine();

            //get the name
            //get other details

            Console.WriteLine("Please select your account type. \nInput a number to choose:");
            Console.WriteLine("1. Savings \n2. Current \n3. Kids \n4. Corporate");
            int userAccountType = int.Parse(Console.ReadLine());
            switch (userAccountType)
            {
                case 1:
                    AccountType = "savings";
                    break;
                case 2:
                    AccountType = "current";
                    break;
                case 3:
                    AccountType = "kids";
                    break;
                case 4:
                    AccountType = "corporate";
                    break;
                default:
                    AccountType = "savings";
                    break;
            }
            Console.WriteLine("Please enter your initial amount: ");
            UserDeposit = double.Parse(Console.ReadLine());
        }

        private double GetRate()
        {
            if (AccountType == "savings")
            {
                return 5.2/100;
            }
            else if (AccountType == "current")
            {
                return 7.4/100;
            }
            else return 0.00;
        }

        public double CalculateCummulative(int month, double rate, double initial)
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
            switch (AccountType)
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
