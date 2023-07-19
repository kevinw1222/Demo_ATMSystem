namespace Demo_ATMSystem
{
    internal class ATM
    {
        private const string quitcode = "5";
        private Bank bank;

        public ATM(Bank bank)
        { this.bank = bank; }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("******************************");
                Console.WriteLine("[1] Open Account");
                Console.WriteLine("[2] Login");
                Console.WriteLine("[3] Quit");
                Console.WriteLine("******************************");
                Console.WriteLine("Please enter your choice then press [ENTER]: ");
                string code = Console.ReadLine();

                if (code == quitcode)
                { return; }

                else if (code == "1")
                { OpenAccount(); }

                else if (code == "2")
                { LoginAccount(); }

                else if (code == "3")
                {
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                    return;
                }
            }
        }

        private void LoginAccount()
        {
            Console.Clear();
            Console.WriteLine("* You have logged in *");
            Console.WriteLine("*******************************************");
            Console.WriteLine("* Please enter your username and password *");
            Console.WriteLine("*******************************************");
            string name = Input("Username: ");
            string password = Input("Password: ");

            Account account;
            if (!bank.LoginAccount(name, password, out account))
            {
                Console.WriteLine("Login failed, check username and password then try again.");
                Console.Read();
            }
            else
            { ManageAccount(ref account); }
        }

        private void OpenAccount()
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("* Please enter your username and password *");
            Console.WriteLine("*******************************************");
            string name = Input("Username: ");
            string password = Input("Password: ");

            Account account;

            if (!bank.OpenAccount(name, password, out account))
            {
                Console.WriteLine("Username have been existed, please change a new one.");
                Console.Read();
            }
            else
            {
                Print("Open Account", 0, account);
                ManageAccount(ref account);
            }
        }

        private void ManageAccount(ref Account account)
        {
            Console.Clear();
            Console.WriteLine("********************");
            Console.WriteLine("[1] Deposit");
            Console.WriteLine("[2] Withdraw");
            Console.WriteLine("[3] Check Amount");
            Console.WriteLine("[4] Change Password");
            Console.WriteLine("[5] Back to Home");
            Console.WriteLine("********************");
            Console.Write("Enter your option: ");

            while (true)
            {
                Console.Write("");
                string code = Console.ReadLine();
                decimal amount;
                bool succeed;
                switch (code)
                {
                    case "1":
                        amount = InputNumber("Please enter deposit amount: $");
                        succeed = account.Deposit(amount);
                        if (succeed)
                        { Print("Deposit", amount, account); }
                        else
                        { Console.WriteLine("Deposit failed."); }
                        Pause();
                        break;

                    case "2":
                        amount = InputNumber("Please enter withdraw amount: $");
                        succeed = account.Withdraw(amount);
                        if (succeed)
                        { Print("Withdraw", amount, account); }
                        else
                        { Console.WriteLine("Withdraw failed."); }
                        Pause();
                        break;

                    case "3":
                        break;

                    case "4":
                        string oldPassword = Input("Current Password");
                        string newPassword = Input("New Password");
                        succeed = account.ChangePassword(oldPassword, newPassword);
                        if (succeed)
                        { Console.WriteLine("Password has been changed."); }
                        else
                        { Console.WriteLine("Password change failed."); }
                        Pause();
                        break;

                    case "5":
                        Console.Clear();
                        break;

                    default:
                        break;
                }
            }
        }

        private string Input(string prompt)
        {
            Console.Write(prompt);
            string str = Console.ReadLine();
            while (str == "")
            {
                Console.Write("Can not be enpty, {0}", prompt);
                str = Console.ReadLine();
            }
            return str;
        }

        private decimal InputNumber(string prompt)
        {
            Console.Write(prompt);
            string s = Console.ReadLine();
            decimal amount = decimal.Parse(s);
            return amount;
        }

        private void Pause()
        {
            Console.Write("Press [ENTER] key to continue.");
            Console.Read();
        }

        private void Print(string operation, decimal amount, Account account)
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("Name: " + account.Name);
            Console.WriteLine("" + operation + ": $" + amount);
            Console.WriteLine("Balance: $" + account.Balance);
            Console.WriteLine("" + operation + " Success");
            Console.WriteLine("*****************************");
        }

        private void Print(Account account)
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("Name: {0}", account.Name);
            Console.WriteLine("Balance: $ {0}", account.Balance);
            Console.WriteLine("*****************************");
        }
    }
}