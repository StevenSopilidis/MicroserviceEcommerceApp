using System.ComponentModel.DataAnnotations.Schema;

namespace Ordering.Domain.Models.ValueObjects
{
    [ComplexType]
    public record Address
    {
        public string FirstName { get; } = default!;
        public string LastName { get; } = default!;
        public string? Email { get; } = default!;
        public string AddressLine { get; } = default!;
        public string Country { get; } = default!;
        public string State { get; } = default!;
        public string ZipCode { get; } = default!;

        protected Address() {}

        private Address(
            string firstName, string lastName, 
            string email, string addressLine,
            string country, string state, string zipCode) 
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            AddressLine = addressLine;
            Country = country;
            State = state;
            ZipCode = zipCode;
        }

        public static Address Of(
            string firstName, string lastName, 
            string email, string addressLine,
            string country, string state, string zipCode) 
        {
            ArgumentException.ThrowIfNullOrEmpty(email);
            ArgumentException.ThrowIfNullOrEmpty(addressLine);

            return new Address(firstName, lastName, email, addressLine, country, state, zipCode);
        }
    };
}