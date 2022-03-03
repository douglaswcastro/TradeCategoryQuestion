using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCQ.Interface
{
    internal interface ITrade
    {
        public double Value { get; set; }
        public string ClientSector { get; set; }

        public DateTime NextPaymentDate { get; set; }

        public bool IsPoliicallyExposed { get; set; }

        public string Valida(DateTime dataReferencia);

        public bool ValidaExpirado(DateTime dataReferencia, DateTime data);
        public bool ValidaRiscoMedio(double valor, string setor);
        public bool ValidaRiscoAlto(double valor, string setor);

        public string Retorno(double valor, string clientSector, DateTime nextPaymentDate, bool isPoliicallyExposed, DateTime dataReferencia);
    }
}
