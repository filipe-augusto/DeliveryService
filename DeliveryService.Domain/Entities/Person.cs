using PaymentContext.Shared.Entities;

namespace DeliveryService.Domain.Entities;


    public abstract class Person : Entity
    {
        public string Nome { get; set; }

        public string Phone { get; set; }

        public string Mail { get; set; }

        public string Documento { get; set; }

        public byte TipoDocumeto { get; set; }
    }
