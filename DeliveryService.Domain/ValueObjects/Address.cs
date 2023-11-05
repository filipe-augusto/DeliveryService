using DeliveryService.Domain.Enums;
using DeliveryService.Shared.ValueObjects;
using Flunt.Validations;

namespace DeliveryService.Domain.ValueObjects
{
    public class Address : ValueObject

    {
        public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;


            AddNotifications(new Contract()
          .Requires()
          .HasMinLen(Street, 3, "Address.Street", "A rua deve conter pelo menos 3 caracteres")
          .HasMaxLen(Street, 100, "Address.Street", "A rua deve no maximo 100 caracteres")
          .HasMinLen(Neighborhood, 3, "Address.Neighborhood", "A Bairro deve conter pelo menos 3 caracteres")
          .HasMaxLen(Neighborhood, 100, "Address.Neighborhood", "A Bairro deve no maximo 100 caracteres")
          .HasMinLen(City, 3, "Address.City", "A cidade deve conter pelo menos 3 caracteres")
          .HasMaxLen(City, 100, "Address.City", "A Cidade deve no maximo 100 caracteres")
          .HasMinLen(Country, 3, "Address.Country", "O país deve conter pelo menos 3 caracteres")
          .HasMaxLen(Country, 100, "Address.Country", "O país deve no maximo 100 caracteres")
          .HasMaxLen(Number, 100, "Address.Number", "O número deve no maximo 100 caracteres")
          .HasMinLen(Number, 8, "Address.ZipCode", "O CEP deve no maximo 8 caracteres")
          );
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }


    }
}
