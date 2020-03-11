using XGame.ValueObject;

namespace XGame.Arguments.Jogador
{
    public class AutenticarJogadorRequest
    {
        public Email Email { get; set; }
        public string Senha { get; set; }
    }
}
