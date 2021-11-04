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
        public double CustomerDeposit { get; set; }


        public void CustomerDetails()
        {
            string name;
            Console.WriteLine("Enter your Account Number:");
            name = Console.ReadLine();

            Console.WriteLine("Please select your account type. \nInput a number to choose:");
            Console.WriteLine("enter 1 for savings \n enter 2 for current \n enter 3 for corporate \n enter 4 for kids");
            int accountType = int.Parse(Console.ReadLine());
            switch (accountType)
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
            CustomerDeposit = double.Parse(Console.ReadLine());
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

        public double CompoundInterest(int month, double rate, double initial)
        {
            double interest;
            double vat = 7.5/100;
            double currentAmount = initial;

            for (int i = 0; i < month; i++)
            {
                interest = ((rate / 100) * currentAmount);
                currentAmount = (currentAmount + interest) - (vat*currentAmount);
            }

            return currentAmount;
        }

        public void DisplayCummulativeBalance(int numberOfMonths, string accountType)
        {
            Console.WriteLine($"With a {accountType}  account, you will save after  {CompoundInterest(numberOfMonths, GetRate(), CustomerDeposit)} in {numberOfMonths}");
        }

        public void ShowCummulative()
        {
            int[] monthDurations = {6, 9, 12, 24, 60 };
            switch (AccountType)
            {
                case "savings":
                    foreach(int duration in monthDurations)
                    {
                        DisplayCummulativeBalance(duration, "savings");
                    }
                    break;
                case "current":
                    foreach (int duration in monthDurations)
                    {
                        DisplayCummulativeBalance(duration, "current");
                    }
                    break;
                case "kids":
                    foreach (int duration in monthDurations)
                    {
                        DisplayCummulativeBalance(duration, "kids");
                    }
                    break;
                case "corporate":
                    foreach (int duration in monthDurations)
                    {
                        DisplayCummulativeBalance(duration, "corporate");
                    }
                    break;
                default:
                    Console.WriteLine("oops no balance!");
                    break;
            }
        }
    }
}
