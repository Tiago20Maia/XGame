using XGame.Arguments.Jogador;

namespace XGame.Interfaces.Services
{
    public interface IServicePlataforma
    {
        AdicionarPlataformaResponse AdicionarPlataforma(AdicionarPlataformaRequest request);

        AutenticarJogadorResponse AutenticarPlataforma(AutenticarJogadorRequest request);
    }
}
