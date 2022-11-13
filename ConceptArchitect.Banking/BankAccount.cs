namespace ConceptArchitect.BankingSystem;

public class BankAccount 
{
   static double interestRate;

   static BankAccount()
   {
        //we can write any logic here
        interestRate = 12;
   }

    static  int lastId=0;
    public BankAccount( string name, string password, double balance) //, double rate)
    {
        lastId++;
        this.name=name;
        this.accountNumber=lastId;
        this.password=password;
        this.balance=balance;
        //BankAccount.interestRate=rate;   
    }






    public static double InterestRate 
    { 
        get
        {
            return interestRate;
        }
        set
        {
            var delta = interestRate/10;
            if(value>=interestRate-delta && value<=interestRate+delta)
                interestRate = value;
        }
    }

    public void CreditInterest()
    {
        balance+=balance*interestRate/1200;
    }





    int accountNumber;

    public int AccountNumber 
    {
        get
        {
            return accountNumber;
        }
        //no set
    }

    double balance;
    public double Balance 
    {
        get
        {
            return balance;
        }
        //set
    }


    string name;

    public string Name 
    {
        get
        {
            return name;
        }

        set
        {
            if(LastName(name)==LastName(value))
                name=value;
        }
    }

    private string LastName(string name)
    {
        var i = name.LastIndexOf(' ');
        if(i==-1) //name has no blanks
            return ""; //no last name
        else
            return name.Substring(i+1); //create a string starting after last blank space
    }

    string password;
    private string Password 
    {
        set
        {
            password=value; //save the password after encrypting
        }
    }

    private string Encrypt(string password)
    {
        return password;
    }


    public bool Authenticate(string challengePassword)
    {
        return (password==challengePassword);
    }

    public bool ChangePassword(string oldPassword, string newPassword)
    {
        var authenticated= Authenticate(oldPassword);

        if(authenticated)
            Password = newPassword;

        return authenticated;
    }


  

  
    public bool Deposit(double amount)
    {
     
        if(amount>0)
        {
            balance+=amount;
            return true; //success
        }
        else
        {
            return false;
        }
    }

    public bool Withdraw(double amount, string confirmPassword)
    {
        if(amount<0) 
            return false;  //failed
        else if(amount>balance)
            return false; //failed
        else if(this.password!=confirmPassword)
            return false; //failed
        else
        {
            balance-=amount;
            return true; //success
        }

    }

  
    public string GetInfo(string confirmPassword){
        if(this.password == confirmPassword)
            return ($"AccountNumber={accountNumber}\tName={name}"+
                                    $"\tBalance={balance}\tInterest Rate={interestRate}");
        else
            return "Invalid Credentials";
    }

    public void Show()
    {
        Console.WriteLine ($"AccountNumber={accountNumber}\tName={name}"+
                                 $"\tBalance={balance}\tInterest Rate={interestRate}");
    }

    public static bool Transfer(BankAccount from, double amount, string confirmPassword, BankAccount to)
    {
        if(from.Withdraw(amount,confirmPassword))
            return to.Deposit(amount);
        else
            return false;

    }

}
