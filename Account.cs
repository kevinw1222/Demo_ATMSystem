namespace Demo_ATMSystem
{
    internal class Account
    {
        protected string name;
        protected string password;
        protected decimal balance;

        public decimal Balance
        { get { return balance; } }

        public string Name
        { get { return name; } }

        public Account(string name, string password)
        {
            this.name = name;
            this.password = password;
            this.balance = 0;
        }

        //***** Deposit *****
        public bool Deposit(decimal amount)
        {
            if (amount <= 0)
            { return false; }
            balance += amount;
            return true;
        }

        public bool Deposit(double amount)
        { return Deposit((decimal)amount); }

        public bool Deposit(int amount)
        { return Deposit((decimal)amount); }

        public bool Deposit(decimal amount, out decimal balance)
        {
            bool succeed = Deposit(amount);
            balance = this.balance;
            return succeed;
        }
        //***** Deposit *****

        //***** Withdraw *****
        public bool Withdraw(decimal amount)
        {
            if (amount > balance || amount <= 0)
            { return false; }
            balance -= amount;
            return true;
        }

        public bool Withdraw(double amount)
        { return Withdraw((decimal)amount); }

        public bool Withdraw(int amount)
        { return Withdraw((decimal)amount); }

        public bool Withdraw(decimal amount, out decimal balance)
        {
            bool succeed = Withdraw(amount);
            balance = this.balance;
            return succeed;
        }
        //***** Withdraw *****

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            if (oldPassword != password)
            { return false; }
            password = newPassword;
            return true;
        }

        public bool Login(string name, string passowrd)
        { return (this.name == name && this.password == passowrd); }
    }
}