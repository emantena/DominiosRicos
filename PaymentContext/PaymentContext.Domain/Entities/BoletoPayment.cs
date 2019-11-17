using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public string BarCode { get; private set; }
        public Email Email { get; private set; }
        public string BoletoNumber { get; private set; }

        public BoletoPayment(string barCode, Email email, string boletoNumber, DateTime paidDate, DateTime expireDate, string owner, Document document, decimal total, decimal totalPaid, string address)
            : base(paidDate, expireDate, owner, document, total, totalPaid, address)
        {
            BarCode = barCode;
            Email = email;
            BoletoNumber = boletoNumber;
        }
    }
}