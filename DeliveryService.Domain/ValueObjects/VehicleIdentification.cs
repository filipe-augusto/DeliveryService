using DeliveryService.Domain.Enums;
using DeliveryService.Shared.ValueObjects;
using Flunt.Validations;

namespace DeliveryService.Domain.ValueObjects
{
    public class VehicleIdentification : ValueObject

    {
        public VehicleIdentification(string vehicleIdentificationNumber, string vehicleMake, string vehicleModel, int yearNumber)
        {
            VehicleIdentificationNumber = vehicleIdentificationNumber;
            VehicleMake = vehicleMake;
            VehicleModel = vehicleModel;
            YearNumber = yearNumber;


            AddNotifications(new Contract()
         .Requires()
         .HasMinLen(VehicleIdentificationNumber,10, "VehicleIdentification.VehicleIdentificationNumber", "Identificação do veiculo deve conter pelo menos 10 caracteres")
         .HasMaxLen(VehicleIdentificationNumber, 40, "VehicleIdentification.VehicleIdentificationNumber", "Identificação do veiculo deve conter no maximo 40 caracteres")
         .HasMaxLen(VehicleMake, 50, "VehicleIdentification.VehicleMake", "Marca do veiculo deve conter no maximo 50 caracteres")
         .HasMaxLen(VehicleModel, 50, "VehicleIdentification.VehicleModel", "Modelo do veiculo deve conter no maximo 50 caracteres")
         .IsTrue(YearNumber > 1900, "VehicleIdentification.YearNumber","Ano Precisa ser maior que 1900")
         .IsTrue(YearNumber < DateTime.Now.Year, "VehicleIdentification.YearNumber", "Ano Precisa ser maior que 1900")
         );

        }

        public string VehicleIdentificationNumber { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public int YearNumber { get; set; }


    }
}
