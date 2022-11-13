namespace ConceptArchitect.BankingSystem.Devices;

using ConceptArchitect.BankingSystem;

public class ATM
{
    private BankAccount account;
    private string pin;

    int GetNumber(string prompt){
        Console.Write(prompt);
        return int.Parse(Console.ReadLine());
    }

    string GetString(string prompt){
        Console.Write(prompt);
        return Console.ReadLine();
    }

    public void Start()
    {
        while(true)
        {
            ReadCard();
            pin= GetString("PIN? ");
            if(pin=="SHUTDOWN") //hack. hidden ATM feature known only to Admin
                return;
            MainMenu();
        }
    }

    private void MainMenu()
    {
        while(true)
        {
            var choice=GetNumber("1. Deposit  2. Withdraw  3. Statement  0. Exit\nChoose:");
            switch (choice)
            {
                case 1:
                    DoDeposit();
                    break;
                case 2:
                    DoWithdraw();
                    break;
                case 3:
                    DoShowStatement();
                    break;
                default:
                    System.Console.WriteLine("Invalid Input. Retry");
                    break;
                case 0:
                    return ; //return back;
            }   

        }
    }

    private void DoShowStatement()
    {
        ShowMessage(account.GetInfo(pin));
    }

    private void DoWithdraw()
    {
       var amount=GetNumber("Withdraw Amount? ");
       
       if(account.Withdraw(amount, pin))
        {
            DispenseCash(amount);   
            ShowMessage("Please collect your cash.") ;
        }
        else
        {
            ShowErrorMessage("Withdraw Failed");
        }
    }

    private void DispenseCash(int amount)
    {
        //real world will dispense the cash amount
        //for now it is another console.writeline
        Console.WriteLine($"Cash Dispensed: {amount}");
    }

    private void DoDeposit()
    {
        var amount=GetNumber("Amount?");
        if(account.Deposit(amount))
        {
            ShowMessage($"Amount Deposited. Your New Balance is {account.Balance}");
        } else
        {
           ShowErrorMessage("Deposit Failed");
        }
    }

    private void ShowErrorMessage(string errorMessage)
    {
        Console.Error.WriteLine($"Error: {errorMessage}");
    }

    private void ShowMessage(string message)
    {
        System.Console.WriteLine(message);
    }

    private void ReadCard()
    {
        account=new BankAccount("Sanjay","1234",20000);
    }
}