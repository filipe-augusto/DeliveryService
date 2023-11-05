using DeliveryService.Domain.Enums;
using DeliveryService.Shared.ValueObjects;
using Flunt.Validations;

namespace DeliveryService.Domain.ValueObjects
{
    public class Document : ValueObject

    {
        public Document(string number, EDocumentType type)
        {
            Number = number;
            TypeDocument = type;

            AddNotifications(new Contract()
              .Requires()
              .IsTrue(Validate(), "Document.Number", "Documento inválido")
          );

        }

        public string Number { get; private set; }

        public EDocumentType TypeDocument { get; private set; }


        private bool Validate()
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
