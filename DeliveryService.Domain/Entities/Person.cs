using DeliveryService.Domain.ValueObjects;
using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace DeliveryService.Domain.Entities;


public abstract class Person : Entity
{
    protected Person(Name nome, Phone phone, Email email, Document documento, Login login, Address address)
    {
        Name = nome;
        Phone = phone;
        Email = email;
        Documento = documento;
        Login = login;
        Address = address;

        AddNotifications(new Contract()
        .Requires()
        .IsNotNull(Name, "Person.Name","Nome necessario")
        .IsNotNull(Phone, "Person.Phone", "Telefone necessario")
        .IsNotNull(Email, "Person.Email", "Email necessario")
        .IsNotNull(Documento, "Person.Documento", "Documento necessario")
        .IsNotNull(Login, "Person.Login", "Login necessario")
        .IsNotNull(Address, "Person.Address", "Endereço necessario")
        );
    }

    public Name Name { get; private set; }

    public Phone Phone { get; private set; }

    public Email Email { get; private set; }

    public Document Documento { get; private set; }

    public Login Login { get; set; }

    public Address Address { get; private set; }
}
