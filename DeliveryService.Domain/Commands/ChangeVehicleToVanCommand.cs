using DeliveryService.Domain.Enums;
using DeliveryService.Shared.Commands;
using Flunt.Validations;
using Flunt.Notifications;

namespace DeliveryService.Domain.Commands
{ 
    public class ChangeVehicleToVanCommand : Notifiable, ICommand
    {

        public string? NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
        public string Address { get; set; }
        public string NumberDocument { get; set; }
        public string Street { get; set; }
        public string AdressNumber { get; set; }
        public EDocumentType TypeDocument { get; private set; }
        public string Neighborhood { get; set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        //Vehicle
        public decimal Fuelcapacity { get; set; }
        public bool HasInsurance { get; set; }
        public decimal CargoVolume { get; set; }
        //car

        public int NumberDoors { get; private set; }
        public int PassengerCapacity { get; private set; }
        public bool HasAirConditioning { get; private set; }
        public bool HasArmored { get; private set; }
        // VehicleIdentification
        public string VehicleIdentificationNumber { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public int YearNumber { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
     .Requires()
                .HasMinLen(FirstName, 2, "Name.FirstName", "Nome deve conter pelo menos 2 caracteres")
                .HasMinLen(LastName, 2, "Name.LastName", "Sobrenome deve conter pelo menos 2 caracteres")
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

        private bool ValidateDoc()
        {

            if (TypeDocument == EDocumentType.CNPJ && Number.Replace("-", "").Replace("/", "").Replace(".", "").Length == 14)
                return ValidateCNPJ(Number.Replace("-", "").Replace("/", "").Replace(".", ""));

            if (TypeDocument == EDocumentType.CPF && Number.Replace("-", "").Replace("/", "").Replace(".", "").Length == 11)
                return ValidateCPF(Number.Replace("-", "").Replace("/", "").Replace(".", ""));

            return false;
        }

        public static bool ValidateCPF(string cpf)
        {
            if (cpf.Length != 11 || !OnlyDigitos(cpf))
            {
                return false;
            }

            int[] multiplicadoresPrimeiroDigito = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadoresSegundoDigito = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            if (CheckDigito(cpf, multiplicadoresPrimeiroDigito) != int.Parse(cpf[9].ToString()))
            {
                return false;
            }

            if (CheckDigito(cpf, multiplicadoresSegundoDigito) != int.Parse(cpf[10].ToString()))
            {
                return false;
            }

            return true;
        }

        public static bool OnlyDigitos(string valor)
        {
            foreach (char c in valor)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        public static int CheckDigito(string cpf, int[] multiplicadores)
        {
            int total = 0;
            for (int i = 0; i < multiplicadores.Length; i++)
            {
                total += int.Parse(cpf[i].ToString()) * multiplicadores[i];
            }
            int resto = total % 11;
            return resto < 2 ? 0 : 11 - resto;
        }

        public static bool ValidateCNPJ(string cnpj)
        {
            if (cnpj.Length != 14 || !OnlyDigitosCnpj(cnpj))
            {
                return false;
            }

            int[] multiplicadoresPrimeiroDigito = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadoresSegundoDigito = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            if (CheckDigitoCnpj(cnpj, multiplicadoresPrimeiroDigito) != int.Parse(cnpj[12].ToString()))
            {
                return false;
            }

            if (CheckDigitoCnpj(cnpj, multiplicadoresSegundoDigito) != int.Parse(cnpj[13].ToString()))
            {
                return false;
            }

            return true;
        }

        public static bool OnlyDigitosCnpj(string valor)
        {
            foreach (char c in valor)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        public static int CheckDigitoCnpj(string cnpj, int[] multiplicadores)
        {
            int total = 0;
            for (int i = 0; i < multiplicadores.Length; i++)
            {
                total += int.Parse(cnpj[i].ToString()) * multiplicadores[i];
            }
            int resto = total % 11;
            return resto < 2 ? 0 : 11 - resto;
        }



    }
}
