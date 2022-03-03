using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCQ.Classes;
using TCQ.Interface;

namespace TCQ.Repositorio
{
    internal class Trade : ITrade
    {
        private double _valor;
        private string _clientSector;
        private DateTime _nextPaymentDate;
        private bool _isPoliicallyExposed;

        public double Value
        {
            get => _valor;
            set => _valor = value;
        }
        public string ClientSector {
            get => _clientSector;
            set => _clientSector = value;
        }

        public DateTime NextPaymentDate {
            get => _nextPaymentDate;
            set => _nextPaymentDate = value;
        }

        public bool IsPoliicallyExposed {
            get => _isPoliicallyExposed;
            set => _isPoliicallyExposed = value;
        }

        public Trade() { }

        public Trade(double _value, string clientSector, DateTime nextPaymentDate, bool isPoliicallyExposed)
        {
            Value = _value; _clientSector = clientSector; _nextPaymentDate = nextPaymentDate; _isPoliicallyExposed = isPoliicallyExposed;
        }

        public string Valida(DateTime dataReferencia)
        {
           return Retorno(Value, ClientSector, NextPaymentDate, IsPoliicallyExposed, dataReferencia);
        }

        public bool ValidaExpirado(DateTime dataReferencia, DateTime dataPagamento)
        {
            if (dataPagamento.AddDays(30) < dataReferencia)
            {
                return true;
            }
            return false;
        }
        public bool ValidaRiscoMedio(double valor, string setor)
        {
            if (valor > 1000000 && setor.ToUpper() == "PUBLIC")
            {
                return true;
            }
            return false;
        }

        public bool ValidaRiscoAlto(double valor, string setor)
        {
            if (valor > 1000000 && setor.ToUpper() == "PRIVATE")
            {
                return true;
            }
            return false;
        }

        public string Retorno(double valor, string clientSector, DateTime nextPaymentDate, bool isPoliicallyExposed, DateTime dataReferencia)
        {
            if (ValidaExpirado(dataReferencia, nextPaymentDate))
            {
                return Categoria.GetString(Enumerados.EnumCategoria.EXPIRED);
            }

            if (ValidaRiscoAlto(valor, clientSector))
            {
                return Categoria.GetString(Enumerados.EnumCategoria.HIGHRISK);
            }

            if (ValidaRiscoMedio(valor, clientSector))
            {
                return Categoria.GetString(Enumerados.EnumCategoria.MEDIUMRISK);
            }

            if (IsPoliicallyExposed)
            {
                return Categoria.GetString(Enumerados.EnumCategoria.POLITICALLYEXPOSED);
            }

            return string.Empty;

        }
    }
}
