using PTR.TPFinal.Domain.Enums;

namespace PTR.TPFinal.Services.Patterns.Strategy
{
    public static class PaymentFactory
    {
        public static IPaymentStrategy Create(PaymentType type)
        {
            return type switch
            {
                PaymentType.Efectivo => new EfectivoPayment(),
                PaymentType.TarjetaCredito => new TarjetaCreditoPayment(),
                PaymentType.TarjetaDebito => new TarjetaDebitoPayment(),
                PaymentType.TransferenciaBancaria => new TransferenciaBancariaPayment(),
                PaymentType.BilleteraVirtual => new BilleteraVirtualPayment(),
                _ => throw new NotImplementedException()
            };
        }
    }
}