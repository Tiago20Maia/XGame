using XGame.Interfaces.Arguments;
using XGame.ValueObject;

namespace XGame.Arguments.Jogador
{
    public class AdicionarJogadorRequest : IRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
    }
}
