namespace PTR.TPFinal.Services.Patterns.Strategy
{
    public interface IPaymentStrategy
    {
        decimal Pay(decimal amount);
    }
}
