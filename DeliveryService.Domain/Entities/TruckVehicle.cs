using PaymentContext.Shared.Entities;
using System.Diagnostics;

namespace DeliveryService.Domain.Entities
{
    public class TruckVehicle : Vehicle
    {
        public int TruckBody { get; set; }//trocar - caçamba aberta, baú fechado, plataforma plana ou reboqu
        public bool DualWheels { get; set; }

    }
}
