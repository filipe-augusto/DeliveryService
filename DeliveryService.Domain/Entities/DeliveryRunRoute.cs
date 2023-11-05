using DeliveryService.Domain.Enums;
using DeliveryService.Domain.ValueObjects;
using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace DeliveryService.Domain.Entities
{
    public  class DeliveryRunRoute : Entity
    {
        public DeliveryRunRoute(DriverPerson driver, DeliveryRun deliveryRun, ERaceStatus status, decimal totalDistance, TimeSpan totalTime, 
            TimeSpan totalDowntime, TimeSpan estimatedTime, Address startingAddress, Address destinationAddress)
        {
            Driver = driver;
            DeliveryRun = deliveryRun;
            Status = status;
            TotalDistance = totalDistance;
            TotalTime = totalTime;
            TotalDowntime = totalDowntime;
            EstimatedTime = estimatedTime;
            StartingAddress = startingAddress;
            DestinationAddress = destinationAddress;

            AddNotifications(new Contract()
           .Requires()
           .IsTrue(TotalDistance == 0, "DeliveryRunRoute.TotalDistance", "Distancia invalida")
           .IsTrue(EstimatedTime == new TimeSpan(0, 0, 0), "DeliveryRunRoute.EstimatedTime", "Tempo estimado invalido")
           .IsNull(Driver, "DeliveryRunRoute.Driver", "Informe um motorista")
           .IsNull(DeliveryRun, "DeliveryRunRoute.DeliveryRun", "Rota não vinculada a uma corrida")
           .IsNull(StartingAddress, "DeliveryRunRoute.StartingAddress", "Inicio da rota não informado")
           .IsNull(DestinationAddress, "DeliveryRunRoute.DestinationAddress", "Destino da rota não informado")
           );
        }

        public DriverPerson Driver { get; private set; }
        public DeliveryRun DeliveryRun { get; private set; }
        public ERaceStatus Status { get; private set; }
        public decimal TotalDistance { get; private set; }
        public TimeSpan TotalTime { get; private set; }
        public TimeSpan TotalDowntime { get; private set; }
        public TimeSpan EstimatedTime { get; private set; }
        public Address StartingAddress { get; private set; }
        public Address DestinationAddress { get; private set; }


        public void SetDriver(DriverPerson driver) => Driver = driver;
        

        public void ChangeDestination(Address destination)
        {
            if (Status != ERaceStatus.Finished || Status != ERaceStatus.Accident)
                DestinationAddress = destination;

        }

    }
}


