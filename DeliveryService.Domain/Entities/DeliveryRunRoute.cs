using DeliveryService.Domain.Enums;
using DeliveryService.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace DeliveryService.Domain.Entities
{
    public  class DeliveryRunRoute : Entity
    {
        public DeliveryRunRoute(DriverPerson driver, DeliveryRun deliveryRun, ERaceStatus status, decimal totalDistance, TimeSpan totalTime, TimeSpan totalDowntime, TimeSpan estimatedTime, Address startingAddress, Address destinationAddress)
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

    }
}


