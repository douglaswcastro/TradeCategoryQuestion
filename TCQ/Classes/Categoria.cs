using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCQ.Enumerados;

namespace TCQ.Classes
{
    internal class Categoria
    {
        internal static string GetString(EnumCategoria categoria)
        {
            switch (categoria)
            {
                case EnumCategoria.EXPIRED:
                    return "EXPIRED";
                case EnumCategoria.MEDIUMRISK:
                    return "MEDIU MRISK";
                case EnumCategoria.HIGHRISK:
                    return "HIGH RISK";
                case EnumCategoria.POLITICALLYEXPOSED:
                    return "Politically Exposed";
                default:
                    return "";
            }
        }
    }
}
