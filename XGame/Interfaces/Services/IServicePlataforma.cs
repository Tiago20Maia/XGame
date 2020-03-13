using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XGame.Arguments.Jogador;

namespace XGame.Interfaces.Services
{
    public interface IServicePlataforma
    {
        AdicionarPlataformaResponse AdicionarJogador(AdicionarPlataformaRequest request);

        AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request);
    }
}
