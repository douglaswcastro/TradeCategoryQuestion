using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCQ.Repositorio;

namespace TCQ.Classes
{
    internal class Trades
    {
        internal void Trading() {

            List<string> retornos = new List<string>();
            Console.WriteLine("Informe data de referência:");
            DateTime datareferencia = DateTime.Parse(Console.ReadLine(), CultureInfo.GetCultureInfo("en-US"));

            Console.WriteLine("Informe a quantidade de négocios na carteira:");
            int quantidade = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe os Elementos(separados por um espaço):");
            for (int i = 0; i < quantidade; i++) {
                var linha = Console.ReadLine();
                retornos.Add(new Trade(double.Parse(linha.Split(' ')[0]), linha.Split(' ')[1], DateTime.Parse(linha.Split(' ')[2], CultureInfo.GetCultureInfo("en-US")), bool.Parse(linha.Split(' ')[3])).Valida(datareferencia)); 
            }

            foreach (string retorno in retornos) {
                Console.WriteLine(retorno);
            }

            Console.ReadKey();

        }
    }
}
