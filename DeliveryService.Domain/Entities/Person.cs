using DeliveryService.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace DeliveryService.Domain.Entities;


public abstract class Person : Entity
{
    protected Person(Name nome, Phone phone, Email email, Document documento, Login login, Address address)
    {
        Nome = nome;
        Phone = phone;
        Email = email;
        Documento = documento;
        Login = login;
        Address = address;
    }

    public Name Nome { get; private set; }

    public Phone Phone { get; private set; }

    public Email Email { get; private set; }

    public Document Documento { get; private set; }

    public Login Login { get; set; }

    public Address Address { get; private set; }
}
