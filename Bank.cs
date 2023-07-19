namespace Demo_ATMSystem
{
    internal class Bank
    {
        protected string name;
        protected const int MaxAccountNum = 2048;
        protected int usedAccountNum;
        protected Account[] accounts;

        public string Name
        { get { return name; } }

        public Bank(string name)
        {
            this.name = name;
            this.usedAccountNum = 0;
            accounts = new Account[MaxAccountNum];
        }

        public bool LoginAccount(string name, string password, out Account account)
        {
            account = null;
            for (int i = 0; i < usedAccountNum; ++i)
            {
                if (accounts[i].Login(name, password))
                {
                    account = accounts[i];
                    return true;
                }
            }
            return false;
        }

        public bool OpenAccount(string name, string password, out Account account)
        {
            account = null;
            for (int i = 0; i < usedAccountNum; ++i)
            {
                if (accounts[i].Name == name)
                { return false; }
            }
            account = new Account(name, password);
            accounts[usedAccountNum++] = account;
            return true;
        }
    }
}