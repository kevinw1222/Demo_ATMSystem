namespace Demo_ATMSystem
{
    internal class MainProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Welcome to CA Bank! *****");

            Bank bank = new Bank("ATM Self-service");
            ATM atm = new ATM(bank);
            atm.Start();
        }
    }
}