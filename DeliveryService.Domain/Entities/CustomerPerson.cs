namespace DeliveryService.Domain.Entities
{
    public class CustomerPerson : Person
    {
        public IReadOnlyCollection<DeliveryRun> DeliveryRuns { get; set; }
        public IReadOnlyCollection<Payment> Payments { get; set; }

    }
}
