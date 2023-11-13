using DeliveryService.Domain.Enums;
using DeliveryService.Domain.ValueObjects;
using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace DeliveryService.Domain.Entities
{
    public  class DeliveryRunRoute : Entity
    {
        public DeliveryRunRoute(DriverPerson driver, DeliveryRun deliveryRun, decimal totalDistance, TimeSpan totalTime 
           , TimeSpan estimatedTime, Address startingAddress, Address destinationAddress)
        {
            Driver = driver;
            DeliveryRun = deliveryRun;
       
            TotalDistance = totalDistance;
            TotalTime = totalTime;
         
            EstimatedTime = estimatedTime;
            StartingAddress = startingAddress;
            DestinationAddress = destinationAddress;
     
            AddNotifications(new Contract()
           .Requires()
           .IsFalse( TotalDistance == 0, "DeliveryRunRoute.TotalDistance", "Distancia invalida")
           .IsFalse( EstimatedTime ==  TimeSpan.Zero, "DeliveryRunRoute.EstimatedTime", "Tempo estimado invalido")
            .IsNotNull(Driver, "DeliveryRunRoute.Driver", "Informe um motorista")
            .IsNotNull(DeliveryRun, "DeliveryRunRoute.DeliveryRun", "Rota não vinculada a uma corrida")
           .IsNotNull(StartingAddress, "DeliveryRunRoute.StartingAddress", "Inicio da rota não informado")
           .IsNotNull(DestinationAddress, "DeliveryRunRoute.DestinationAddress", "Destino da rota não informado")
           );
        }
     
        public DriverPerson Driver { get; private set; }
        public DeliveryRun DeliveryRun { get; private set; }

        public decimal TotalDistance { get; private set; }
        public TimeSpan TotalTime { get; private set; }
        public TimeSpan TotalDowntime { get; private set; }
        public TimeSpan EstimatedTime { get; private set; }
        public Address StartingAddress { get; private set; }
        public Address DestinationAddress { get; private set; }


        public void ChangeDriver(DriverPerson driver) => Driver = driver;
        

 

    }
}


