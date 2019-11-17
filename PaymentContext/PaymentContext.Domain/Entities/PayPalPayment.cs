using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public Email Email { get; set; }
        public string LastTransactionCode { get; set; }

        public PayPalPayment(Email email, string lastTransactionCode, DateTime paidDate, DateTime expireDate, string owner, Document document, decimal total, decimal totalPaid, string address)
            : base(paidDate, expireDate, owner, document, total, totalPaid, address)
        {
            Email = email;
            LastTransactionCode = lastTransactionCode;
        }
    }
}