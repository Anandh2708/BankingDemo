

using System;
using Xunit;

public class BankSpecs
{
    private double interestRate=12;
    Bank bank;
    string name="ICICI";

    public BankSpecs()
    {
        bank=new Bank();
        bank.InterestRate=interestRate;
        bank.Name=name;
    }

    [Fact]
    public void BankHasAName()
    {
        string name="New Bank";
        var bank=new Bank();

        bank.Name=name;
        Assert.Equal(name, bank.Name);

    }
    [Fact]
    public void BankHasAnInterestRate()
    {
        var bank=new Bank();
        bank.InterestRate=interestRate;

        Assert.Equal(interestRate,bank.InterestRate);
    }

    [Fact]
    public void InterestRateCanChangeWithinDeltaOf10Percent()
    {
        var newRate= 1.05*interestRate; //withing +/- 10% range
        bank.InterestRate=newRate;

        Assert.Equal(newRate,bank.InterestRate);
    }

    [Fact]
    public void InterestRateCantCangeChangeWithDeltaGreaterThan10Percent()
    {
        bank.InterestRate=1.15*interestRate;

        Assert.Equal(interestRate, bank.InterestRate); //no change
    }

    [Fact(Skip="Not yet implemented")]
    public void OpenAccountShouldOpenAccountAndReturnAccountNumberInHappyPath()
    {
    }
    

    [Fact(Skip="Not yet implemented")]
    public void OpenAccountShoulToOpenAccountAndReturn0ForMissingName()
    {
    }
    [Fact(Skip="Not yet implemented")]
    public void OpenAccountShoulToOpenAccountAndReturn0ForMissingPassword()
    {
    }
    [Fact(Skip="Not yet implemented")]
    public void OpenAccountShoulToOpenAccountAndReturn0ForNonPostiveBalance()
    {
    }


}