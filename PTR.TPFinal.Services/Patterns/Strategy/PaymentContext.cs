namespace PTR.TPFinal.Services.Patterns.Strategy
{
    public class PaymentContext(IPaymentStrategy strategy)
    {
        private readonly IPaymentStrategy _strategy = strategy;

        public decimal ExecutePayment(decimal amount)
        {
            return _strategy.Pay(amount);
        }
    }
}
