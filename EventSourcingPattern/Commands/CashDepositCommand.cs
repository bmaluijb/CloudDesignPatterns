namespace EventSourcingPattern
{
    public class CashDepositCommand : Command
    {
        public double Amount { get; set; }
    }
}
