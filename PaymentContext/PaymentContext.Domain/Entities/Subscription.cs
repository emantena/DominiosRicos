using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Subscription : Entity
    {
        private IList<Payment> _payments;

        public Guid SubscriptionId { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool Active { get; private set; }

        public IReadOnlyCollection<Payment> Payments
        {
            get
            {
                return _payments.ToArray();
            }
        }

        #region :: Ctor ::
        public Subscription(DateTime? expireDate)
        {
            SubscriptionId = Guid.NewGuid();
            ExpireDate = expireDate;
            Active = true;
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;

            _payments = new List<Payment>();
        }
        #endregion

        public void AddPayment(Payment payment)
        {

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(DateTime.Now, payment.PaidDate, "Subsctiption.Payments", "Data do pagamento deve ser uma data futura")
            );

            if (Valid)
                _payments.Add(payment);
        }

        public void Activate()
        {
            Active = true;
            LastUpdateDate = DateTime.Now;
        }

        public void Inactivate()
        {
            Active = false;
            LastUpdateDate = DateTime.Now;
        }
    }
}