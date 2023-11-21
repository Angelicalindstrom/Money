namespace Money
{
    internal class Program
    {
        static void Main()
        {
            // object med bankkonton, avsändare, mottagare
            CheckingAccount senderAccount = new CheckingAccount("Sender Sendersson", 1000);
            CheckingAccount receiverAccount = new CheckingAccount("Receiver Receiversson", 0);

            // tillgängligt belopp
            Console.WriteLine(senderAccount.Username + "s Initial amount of money: $" + senderAccount.Balance);

            // Hur mkt vill du överföra till mottagare?
            Console.Write("What amount would you like to transfer ? :");
            double transferAmount = (Convert.ToDouble(Console.ReadLine()));


            // Vem vill du överföra til?
            // för över --- till ,
            senderAccount.TransferMoney(receiverAccount, transferAmount);
            
            // visa balans på respektive konton.

            Console.WriteLine("\nBalance after transfer of $" + senderAccount.Balance + ":");
            DisplayBalance(senderAccount, receiverAccount);



            // Tillgänglig balans efter överföring
            Console.WriteLine($"Amount of money after making the transfer: $" + senderAccount.Balance);
        }
        static void DisplayBalance(CheckingAccount sender, CheckingAccount receiver)
        {
            Console.WriteLine(sender.Username + "´s balance in: $ " + sender.Balance);
            Console.WriteLine(receiver.Username + "´s balance in: $ " + receiver.Balance);
        }
    }

  

    class CheckingAccount
    {
        public double Balance { get; private set; }
        public string Username { get; }

        // användare och kontobalans
        public CheckingAccount(string userName, double currentBalance)
        {
            Username = userName;
            Balance = currentBalance;
        }

        public CheckingAccount()
        {
            // Balans för sender
            Balance = 10000;
        }

        //Överförametod
        public void TransferMoney(CheckingAccount recipient, double amount)
        {
             
            if(amount <= 0 || amount > Balance)
            {
                // om för lite pengar på kontot : felmeddelande
                Console.WriteLine("Invalid transfer, the amount is to big!");
                return;
                // Om för stor summa felmeddelande.. Lite tokigt här vid felhantering..****
            }
            // Överföring , godkänd summa för överföring med överföringsinfo
            Balance -= amount;
            recipient.ReceiveMoney(amount);
            Console.WriteLine("$" + amount + " transferred from you " + Username+ " to " + recipient.Username );
        }


        private void ReceiveMoney (double amount)
        {
            Balance += amount;
        }
    }
}