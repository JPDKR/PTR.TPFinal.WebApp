namespace PTR.TPFinal.Services.Patterns.Strategy
{
    public class EfectivoPayment : IPaymentStrategy
    {
        public decimal Pay(decimal amount)
        {
            return amount * 0.8m; // 20% discount
        }
    }

    public class TarjetaCreditoPayment : IPaymentStrategy
    {
        public decimal Pay(decimal amount)
        {
            return amount; // No discount
        }
    }

    public class TarjetaDebitoPayment : IPaymentStrategy
    {
        public decimal Pay(decimal amount)
        {
            return amount * 0.95m; // 5% discount
        }
    }

    public class TransferenciaBancariaPayment : IPaymentStrategy
    {
        public decimal Pay(decimal amount)
        {
            return amount * 0.9m; // 10% discount
        }
    }

    public class BilleteraVirtualPayment : IPaymentStrategy
    {
        public decimal Pay(decimal amount)
        {
            return amount * 0.85m; // 15% discount
        }
    }
}
