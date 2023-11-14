using DeliveryService.Domain.Enums;
using DeliveryService.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace DeliveryService.Domain.Commands
{
    public class CreateDeliveryRunMotoPixCommand : Notifiable, ICommand
    {

        //customer
        public string? NickNameCustomer { get; set; }
        public string FirstNameCustomer { get; set; }
        public string LastNameCustomer { get; set; }
        public string NumberCustomer { get; set; }
        public string AddressCustomer { get; set; }
        public string NumberDocumentCustomer { get; set; }
        public string StreetCustomer { get; set; }
        public string AdressNumberCustomer { get; set; }
        public EDocumentType TypeDocumentCustomer { get; private set; }
        public string NeighborhoodCustomer { get; set; }
        public string UserNameCustomer { get; private set; }
        public string PasswordCustomer { get; private set; }
        public bool ActiveCustomer { get; set; }
        public string CityCustomer { get; set; }
        public string StateCustomer { get; set; }
        public string CountryCustomer { get; set; }
        public string ZipCodeCustomer { get; set; }
        public bool BannedCustomer { get; set; }

        //driver
        public string? NickNameDriver { get; set; }
        public string FirstNameDriver { get; set; }
        public string LastNameDriver { get; set; }
        public string NumberDriver { get; set; }
        public string AddressDriver { get; set; }
        public string NumberDocumentDriver { get; set; }
        public string StreetDriver { get; set; }
        public string AdressNumberDriver { get; set; }
        public EDocumentType TypeDocumentDriver { get; private set; }
        public string NeighborhoodDriver { get; set; }
        public string UserNameDriver { get; private set; }
        public string PasswordDriver { get; private set; }
        public bool ActiveDriver { get; set; }
        public string CityDriver { get; set; }
        public string StateDriver { get; set; }
        public string CountryDriver { get; set; }
        public string ZipCodeDriver { get; set; }
        //Vehicle
        public decimal Fuelcapacity { get; set; }
        public bool HasInsurance { get; set; }
        public decimal CargoVolume { get; set; }
      

        public bool IsScooter { get; set; }
        public bool HasTopBox { get; set; }
        // VehicleIdentification
        public string VehicleIdentificationNumber { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public int YearNumber { get; set; }
        public EClassification Classification { get; private set; }


        //run
        public DateTime DataCreateDeliveryRun { get; private set; }
        public string? ObservationDeliveryRun { get; private set; }
        public ERaceStatus RaceStatusDeliveryRun { get; private set; }
        public TimeSpan TotalTimeDeliveryRun { get; private set; }
        public decimal TotalDistanceDeliveryRun { get; private set; }



        //Payment
        public string NumberPayment { get; private set; }
        public DateTime PaidDatePayment { get; private set; }
        public DateTime ExpireDatePayment { get; private set; }
        public decimal TotalPayment { get; private set; }
        public decimal TotalPaidPayment { get; private set; }
        public string PayerPayment { get; private set; }
        //pix
        public string? KeyPIx { get; private set; }
        public string? PixType { get; private set; }

        //route
        public decimal TotalDistance { get; private set; }
        public TimeSpan TotalTime { get; private set; }
        public TimeSpan TotalDowntime { get; private set; }
        public TimeSpan EstimatedTime { get; private set; }


        public string StreetStarting { get; private set; }
        public string NumberStarting { get; private set; }
        public string NeighborhoodStarting { get; private set; }
        public string CityStarting { get; private set; }
        public string StateStarting { get; private set; }
        public string CountryStarting { get; private set; }
        public string ZipCodeStarting { get; private set; }
        public string StreetDestination { get; private set; }
        public string NumberDestination { get; private set; }
        public string NeighborhoodDestination { get; private set; }
        public string CityDestination { get; private set; }
        public string StateDestination { get; private set; }
        public string CountryDestination { get; private set; }
        public string ZipCodeDestination { get; private set; }



        public void Validate()
        {
            AddNotifications(new Contract()
     .Requires()
                .HasMinLen(FirstNameCustomer, 2, "Name.FirstName", "Nome deve conter pelo menos 2 caracteres")
                .HasMinLen(LastNameCustomer, 2, "Name.LastName", "Sobrenome deve conter pelo menos 2 caracteres")
                .HasMaxLen(FirstNameCustomer, 40, "Name.FirstName", "Nome deve conter até 40 caracteres")
                .HasMaxLen(LastNameCustomer, 40, "Name.LastName", "Nome deve conter até 40 caracteres")
                .HasMinLen(NumberCustomer, 8, "Phone.Number", "Número do telefone deve conter pelo menos 8 caracteres!")
                .HasMinLen(UserNameCustomer, 5, "Login.UserName", "UserName deve conter pelo menos 5 caracteres")
                .HasMinLen(PasswordCustomer, 5, "Login.Password", "Senha deve conter pelo menos 5 caracteres")
                .HasMaxLen(UserNameCustomer, 20, "Login.UserName", "UserName deve conter no maximo 20 caracteres")
                .HasMaxLen(PasswordCustomer, 30, "Login.Password", "Senha deve conter no maximo 30 caracteres")
                .IsTrue(!Hasletters(NumberCustomer), "Phone.Number", "Telefone invalido!")
                .IsEmail(AdressNumberCustomer, "Email.Address", "E-mail inválido")
                .HasMinLen(AdressNumberCustomer, 5, "Email.Address", "E-mail deve conter pelo menos 5 caracteres")
                .HasMinLen(StreetCustomer, 3, "Address.Street", "A rua deve conter pelo menos 3 caracteres")
                .HasMaxLen(StreetCustomer, 100, "Address.Street", "A rua deve no maximo 100 caracteres")
                .HasMinLen(NeighborhoodCustomer, 3, "Address.Neighborhood", "A Bairro deve conter pelo menos 3 caracteres")
                .HasMaxLen(NeighborhoodCustomer, 100, "Address.Neighborhood", "A Bairro deve no maximo 100 caracteres")
                .HasMinLen(CityCustomer, 3, "Address.City", "A cidade deve conter pelo menos 3 caracteres")
                .HasMaxLen(CityCustomer, 100, "Address.City", "A Cidade deve no maximo 100 caracteres")
                .HasMinLen(CountryCustomer, 3, "Address.Country", "O país deve conter pelo menos 3 caracteres")
                .HasMaxLen(CountryCustomer, 50, "Address.Country", "O país deve no maximo 50 caracteres")
                .HasMaxLen(NumberCustomer, 20, "Address.Number", "O número deve no maximo 20 caracteres")
                .HasMinLen(ZipCodeCustomer, 7, "Address.ZipCode", "O Cep deve no minimo 7 caracteres")
                .HasMinLen(FirstNameDriver, 2, "Name.FirstName", "Nome deve conter pelo menos 2 caracteres")
                .HasMinLen(LastNameDriver, 2, "Name.LastName", "Sobrenome deve conter pelo menos 2 caracteres")
                .HasMaxLen(FirstNameDriver, 40, "Name.FirstName", "Nome deve conter até 40 caracteres")
                .HasMaxLen(LastNameDriver, 40, "Name.LastName", "Nome deve conter até 40 caracteres")
                .HasMinLen(NumberDriver, 8, "Phone.Number", "Número do telefone deve conter pelo menos 8 caracteres!")
                .HasMinLen(UserNameDriver, 5, "Login.UserName", "UserName deve conter pelo menos 5 caracteres")
                .HasMinLen(PasswordDriver, 5, "Login.Password", "Senha deve conter pelo menos 5 caracteres")
                .HasMaxLen(UserNameDriver, 20, "Login.UserName", "UserName deve conter no maximo 20 caracteres")
                .HasMaxLen(PasswordDriver, 30, "Login.Password", "Senha deve conter no maximo 30 caracteres")
                .IsTrue(!Hasletters(NumberDriver), "Phone.Number", "Telefone invalido!")
                .IsEmail(AdressNumberDriver, "Email.Address", "E-mail inválido")
                .HasMinLen(AdressNumberDriver, 5, "Email.Address", "E-mail deve conter pelo menos 5 caracteres")
                .HasMinLen(StreetDriver, 3, "Address.Street", "A rua deve conter pelo menos 3 caracteres")
                .HasMaxLen(StreetDriver, 100, "Address.Street", "A rua deve no maximo 100 caracteres")
                .HasMinLen(NeighborhoodDriver, 3, "Address.Neighborhood", "A Bairro deve conter pelo menos 3 caracteres")
                .HasMaxLen(NeighborhoodDriver, 100, "Address.Neighborhood", "A Bairro deve no maximo 100 caracteres")
                .HasMinLen(CityDriver, 3, "Address.City", "A cidade deve conter pelo menos 3 caracteres")
                .HasMaxLen(CityDriver, 100, "Address.City", "A Cidade deve no maximo 100 caracteres")
                .HasMinLen(CountryDriver, 3, "Address.Country", "O país deve conter pelo menos 3 caracteres")
                .HasMaxLen(CountryDriver, 50, "Address.Country", "O país deve no maximo 50 caracteres")
                .HasMaxLen(NumberDriver, 20, "Address.Number", "O número deve no maximo 20 caracteres")
            .HasMinLen(ZipCodeDriver, 7, "Address.ZipCode", "O Cep deve no minimo 7 caracteres")
                    .HasMinLen(VehicleIdentificationNumber, 10, "VehicleIdentification.VehicleIdentificationNumber", "Identificação do veiculo deve conter pelo menos 10 caracteres")
         .HasMaxLen(VehicleIdentificationNumber, 40, "VehicleIdentification.VehicleIdentificationNumber", "Identificação do veiculo deve conter no maximo 40 caracteres")
         .HasMaxLen(VehicleMake, 50, "VehicleIdentification.VehicleMake", "Marca do veiculo deve conter no maximo 50 caracteres")
         .HasMaxLen(VehicleModel, 50, "VehicleIdentification.VehicleModel", "Modelo do veiculo deve conter no maximo 50 caracteres")
                      .IsFalse(PaidDatePayment.Day > DateTime.Now.Day, "PaidDate", "A data do pagamento deve ser futura")

         .IsTrue(YearNumber > 1900, "VehicleIdentification.YearNumber", "Ano Precisa ser maior que 1900")
         .IsTrue(YearNumber < DateTime.Now.Year, "VehicleIdentification.YearNumber", "Ano Precisa ser maior que 1900")
           .IsFalse(TotalDistance == 0, "DeliveryRunRoute.TotalDistance", "Distancia invalida")
           .IsFalse(EstimatedTime == TimeSpan.Zero, "DeliveryRunRoute.EstimatedTime", "Tempo estimado invalido")

                );
        }
        // public IReadOnlyCollection<Assessment> Assessments { get { return _assessments.ToArray(); } }
        static bool Hasletters(string input)
        {
            foreach (char c in input)
            {
                if (Char.IsLetter(c))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
