using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XGame.Arguments.Jogador;

namespace XGame.Interfaces.Services
{
    public interface IRepositoryJogador
    {
        AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request);
        Guid AdicionarJogador(AdicionarJogadorRequest request);
    }
}
