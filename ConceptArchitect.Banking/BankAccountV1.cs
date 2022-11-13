namespace ConceptArchitect.BankingSystem;

public class BankAccountV1 
{
    int accountNumber;
    string name;
    string password;
    double balance;
    double interestRate;

    public BankAccountV1(int accountNumber, string name, string password, double balance, double interestRate)
    {
        this.name=name;
        this.accountNumber=accountNumber;
        this.password=password;
        this.balance=balance;
        this.interestRate=interestRate;   
    }

    public void Deposit()
    {
        Console.Write("Amount to Deposit? ");
        var amount= double.Parse( Console.ReadLine() ); //reads one line typed by user as string

        if(amount>0)
        {
            balance+=amount;
            System.Console.WriteLine("Amount Deposited Successfully");
        }
        else
        {
            System.Console.WriteLine("Deposit Failed. Amount Must be greater than zero");
        }
    }

    public void Withdraw()
    {
        Console.Write("Amount to Withdraw? ");
        var amount= double.Parse( Console.ReadLine() ); //reads one line typed by user as string
        Console.Write("password? ");
        var password=Console.ReadLine();
        if(amount<0) 
            Console.WriteLine("Invalid Amount. Must be greater than zero");
        else if(amount>balance)
            Console.WriteLine("Insufficient balance.");
        else if(this.password!=password)
            Console.WriteLine("Invalid Credentials");
        else
        {
            balance-=amount;
            Console.WriteLine("Please Collect your cash");
        }

    }

    public void CreditInterest()
    {
        balance+=balance*interestRate/1200;
        System.Console.WriteLine("Interest Credited");
    }

    public void Show(){
        System.Console.WriteLine($"AccountNumber={accountNumber}\tName={name}"+
                                 $"\tBalance={balance}\tInterest Rate={interestRate}");
    }

}
