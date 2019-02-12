using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.Models
{
    public class Veiculo
    {
        public const int FreioAbs = 800;
        public const int ArCondicionado = 1000;
        public const int Mp3Player = 500;

        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string PrecoFormatado { get { return string.Format("R$ {0}", Preco); } }

        public bool TemFreioAbs { get; set; }
        public bool TemArCondicionado { get; set; }
        public bool TemMp3Player { get; set; }

        public string PrecoTotalFormatado
        {
            get
            {
                return string.Format("Valor total: R$ {0}",
              Preco
              + (TemFreioAbs ? FreioAbs : 0)
              + (TemArCondicionado ? ArCondicionado : 0)
              + (TemMp3Player ? Mp3Player : 0));
            }
        }
    }
}
