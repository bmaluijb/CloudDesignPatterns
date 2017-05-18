namespace EventSourcingPattern
{
    public class CashWithdrawalCommand : Command
    {
        public double Amount { get; set; }
    }
}
