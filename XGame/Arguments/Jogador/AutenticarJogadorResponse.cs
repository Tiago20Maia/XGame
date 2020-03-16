using XGame.ValueObject;

namespace XGame.Arguments.Jogador
{
    public class AutenticarJogadorResponse
    {
        public string PrimeiroNome { get; set; }
        public Email Email { get; set; }
        public int Status { get; set; }

        public static explicit operator AutenticarJogadorResponse(Entities.Jogador entidade)
        {
            return new AutenticarJogadorResponse()
            {
                Email = entidade.Email,
                PrimeiroNome = entidade.Nome.PrimeiroNome,
                Status =  (int) entidade.Status
            };
        }
    }
}
