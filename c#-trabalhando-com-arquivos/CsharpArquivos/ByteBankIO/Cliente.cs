using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankIO
{
    public class Cliente (string nome)
    {
        public string Nome { get; set; } = nome;
        public string CPF { get; set; } = string.Empty;
        public string Profissao { get; set; } = string.Empty;
    }
}
