internal class Bank
{
    public Bank()
    {
    }

    public string Name { get; internal set; }
    private double interestRate;
    public double InterestRate
    {
        get { return interestRate; }
        set 
        { 
            if(InterestRate==0)
            {
                interestRate=value; //first time Set
                return ;
            }

            var delta =InterestRate/10;

            if(value>=InterestRate-delta && value <=interestRate+delta)
                interestRate = value; 

        }
    }
    
}