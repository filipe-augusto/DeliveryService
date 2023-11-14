using DeliveryService.Domain.Commands;
using DeliveryService.Domain.Entities;
using DeliveryService.Domain.Enums;
using DeliveryService.Domain.Repositories;
using DeliveryService.Domain.Services;
using DeliveryService.Domain.ValueObjects;
using DeliveryService.Shared.Commands;
using DeliveryService.Shared.Handlers;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Domain.Handlers
{
    public class CreateDeliveryRunHandler :
        Notifiable,
        IHandler<CreateDeliveryRunMotoPixCommand>
    {

        private readonly IDeliveryRunRepository _repository;
        private readonly IEmailService _emailService;


        public CreateDeliveryRunHandler(IDeliveryRunRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateDeliveryRunMotoPixCommand command)
        {
            // fail fast validations
            command.Validate();
            if (command.Invalid)
            {
            AddNotifications(command);
                return new CommandResult(false, "Não foi possivel criar a corrida");
            }
            //ou
            //verificar se rota é valida
            if (_repository.PaymentExists(command.NumberPayment)) 
                AddNotification("Payment","Pagamento já foi usado em outra corrida");


            //gerar vos
            var nameCustomer = new Name(command.FirstNameCustomer, command.LastNameCustomer);
            var phoneCustomer = new Phone(command.NumberCustomer);
            var emailCustomer = new Email(command.AddressCustomer);
            var documentCustomer = new Document(command.NumberDocumentCustomer, command.TypeDocumentCustomer);
            var loginCustomer = new Login(command.UserNameCustomer,command.PasswordCustomer, command.ActiveCustomer);
            var addressCustomer = new Address(command.StreetCustomer, command.AdressNumberCustomer,
                command.NeighborhoodCustomer,command.CityCustomer,command.StateCustomer,command.CountryCustomer, command.ZipCodeCustomer);
            var nameDriver = new Name(command.FirstNameDriver, command.LastNameCustomer);
            var phoneDriver = new Phone(command.NumberDriver);
            var emailDriver = new Email(command.AddressDriver);
            var documentDriver = new Document(command.NumberDocumentDriver, command.TypeDocumentDriver);
            var loginDriver = new Login(command.UserNameDriver, command.PasswordDriver, command.ActiveDriver);
            var addressDriver = new Address(command.StreetDriver, command.AdressNumberDriver, command.NeighborhoodDriver,command.CityDriver,
                command.StateDriver, command.StateDriver,command.ZipCodeDriver);
            var startingAddress = new Address(command.StreetStarting, command.NumberStarting, command.NeighborhoodStarting, command.NeighborhoodStarting,
                command.StateStarting, command.NeighborhoodStarting,command.ZipCodeStarting);
            var destinationAddress = new Address(command.StreetDestination, command.NumberDestination, command.NeighborhoodDestination, command.NeighborhoodDestination,
         command.StateDestination, command.NeighborhoodDestination, command.ZipCodeDestination);

            var vehicleIdentification_moto = new VehicleIdentification(command.VehicleIdentificationNumber, command.VehicleMake, command.VehicleModel,command.YearNumber);
            var vehicleMoto = new MotorcycleVehicle(command.IsScooter, command.HasTopBox, vehicleIdentification_moto,
                command.Fuelcapacity,command.HasInsurance, command.CargoVolume, null);

            var customerPerson = new CustomerPerson(command.BannedCustomer, nameCustomer, phoneCustomer, emailCustomer, documentCustomer, loginCustomer, addressCustomer);
            var driverPerson = new DriverPerson(vehicleMoto, command.NickNameDriver, nameDriver, phoneDriver, emailDriver, documentDriver, loginDriver, addressDriver);


            var payment = new PixPayment(command.KeyPIx, command.PixType, command.NumberPayment,
                command.PaidDatePayment, command.ExpireDatePayment, command.TotalPayment, command.TotalPaidPayment,
                nameCustomer.FirstName, customerPerson, driverPerson, documentCustomer, null);
     
            var deliveryRun = new DeliveryRun(customerPerson,command.ObservationDeliveryRun);
        var deliveryRunRoute = new DeliveryRunRoute(driverPerson, deliveryRun, command.TotalDistance, command.TotalTime, command.EstimatedTime, startingAddress, destinationAddress);
            //relacionamentos

            vehicleMoto.DriverPerson = driverPerson;
            deliveryRun.SetPayment(payment);
         
            //agrupar validações 
            AddNotifications(nameCustomer, phoneCustomer, emailCustomer, documentCustomer, loginCustomer, addressCustomer, nameDriver, phoneDriver, emailDriver,documentDriver,
                loginDriver, addressDriver, startingAddress, destinationAddress, vehicleIdentification_moto, vehicleMoto, customerPerson, driverPerson, payment, deliveryRun, deliveryRunRoute);

            //checar notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possivel criar a corrida");

            //salvar informações

            _repository.CreateDeliveryRun(deliveryRun);

            //enviar notificação


            _emailService.seendEmail(customerPerson.Name.ToString(), customerPerson.Email.Address, "Corrida criada!", "Sua corrida foi criada");
            //retornar informações

            return new CommandResult(true, "Corrida criada com sucesso!");

            
        }
    }
    
}
