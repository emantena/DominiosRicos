using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string Street { get; private set; }
        public string Number { get; set; }
        public string Neightborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public Address(string street, string number, string neightborhood, string city, string state, string zipCode)
        {
            Street = street;
            Number = number;
            Neightborhood = neightborhood;
            City = city;
            State = state;
            ZipCode = zipCode;
        }
    }
}