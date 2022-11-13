using Xunit;

using ConceptArchitect.BankingSystem;
namespace BankingTests;

public class BankAccountTests
{

    BankAccount account;
    double originalInterestRate;



    string fname = "Sanjay";
    string lastName = "Mall";
    string password = "p@ss";
    double balance = 20000;


    public BankAccountTests()
    {
        account = new BankAccount($"{fname} {lastName}", password, balance);
        originalInterestRate = BankAccount.InterestRate;
    }


    //helper functions.
    public void AssertTransactionFailed(bool status)
    {
        Assert.False(status);
        Assert.Equal(balance, account.Balance);
    }

     //helper functions.
    public void AssertTransactionFaileds(bool status)
    {
        Assert.False(status);
        Assert.Equal(balance, account.Balance);
    }

    //hai da ajmeer conflict kaaga
    // hey epudra 
    public void AssertBalance(double expectedBalance)
    {
        Assert.Equal(expectedBalance, account.Balance);
    }



    [Fact]
    public void DepositReturnsTrueForPositiveAmount()
    {
        var result = account.Deposit(1);
        //Assert.True(result);
        AssertBalance(balance+1);
    }



    [Fact]
    public void DepositReturnsFalseForNegativeAmount()
    {
        var result = account.Deposit(-1000);
        //Assert.False(result);
        AssertTransactionFailed(result);
    }

    //write tests for 
    //withdraw 
    //fails for 

    [Fact]
    public void WithdrawFailsForNegativeAmount()
    {
        //Assert.False(account.Withdraw(-1, password));
        AssertTransactionFailed(account.Withdraw(-1, password));
    }


    //invalid password for

    [Fact]
    public void WithdrawFAilsForInvalidPassword()
    {
        //Assert.False(account.Withdraw(1, "invalid password"));
        AssertTransactionFailed(account.Withdraw(1, "invalid password"));
    }


    [Fact]
    public void WithdrawFailsForInsufficientBalance()
    {
        //Assert.False(account.Withdraw(balance + 1, password));
        AssertTransactionFailed(account.Withdraw(balance + 1, password));
    }

    


    [Fact]
    public void WithdrawWorksHappyTerm()
    {
        var result = account.Withdraw(1, password);
        // Assert.True(result);
        // Assert.Equal(balance-1, account.Balance);

        AssertBalance(balance-1);
    }

    [Fact]
    public void InterestRateChangesInValidRange()
    {
        BankAccount.InterestRate = 13;
        Assert.Equal(13, BankAccount.InterestRate);
    }

    [Fact]
    public void InterestRateDoesntChangeForOutOfRange()
    {
        BankAccount.InterestRate = 100;
        Assert.Equal(originalInterestRate, BankAccount.InterestRate);
    }

    [Fact]
    public void NameChangeIsAllowedWithSameSurnName()
    {

        var newName = $"Xyz {lastName}";
        account.Name = newName;

        Assert.Equal(newName, account.Name);
    }

    [Fact]
    public void NameChangeNotPermittedWithADifferentLastName()
    {
        var origianalName = account.Name;
        var newName = $"Xyz Abc";
        account.Name = newName;

        Assert.Equal(origianalName, account.Name);
    }

    [Fact]
    public void CreditInterestCreditsOneMonthInterest()
    {
        var expectedNewBalance = balance * (1 + BankAccount.InterestRate / 1200);
        account.CreditInterest();
        
        //Assert.Equal(expectedNewBalance, account.Balance);
        AssertBalance(expectedNewBalance);
    }




}