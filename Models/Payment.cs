using System;

namespace ParkingSystemApp
{
    public class Payment
    {
        public int PaymentId { get; private set; }
        public float Amount { get; private set; }
        public PaymentStatus Status { get; set; }

        public Payment(int id, float amount)
        {
            PaymentId = id;
            Amount = amount;
            Status = PaymentStatus.PENDING;
        }

        public PaymentStatus ProcessPayment()
        {
            Console.WriteLine($"[Payment System] Processing payment {PaymentId} for amount {Amount}...");
            Status = PaymentStatus.CONFIRMED;
            return Status;
        }
    }
}
