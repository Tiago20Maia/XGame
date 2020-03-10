using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XGame.Enum;
using XGame.ValueObject;

namespace XGame.Entities
{
    public class Jogador
    {
        public Guid Id { get; set; }
        public Nome Nome { get; set; }
        public Email Email { get; set; }
        public string Senha { get; set; }
        public EnumSituacaoJogador status { get; set; }

    }
}
