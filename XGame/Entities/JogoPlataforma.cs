using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XGame.Entities
{
    public class JogoPlataforma
    {
        public Guid Id { get; set; }
        public Plataforma Plataforma { get; set; }
        public DateTime DataLancamento { get; set; }
        public Jogo Jogo { get; set; }
    }
}
