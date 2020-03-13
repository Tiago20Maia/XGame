using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XGame.Arguments.Jogador;
using XGame.Entities;

namespace XGame.Interfaces.Services
{
    public interface IRepositoryJogador
    {
        AutenticarJogadorResponse AutenticarJogador(string email, string senha);
        Guid AdicionarJogador(Jogador jogador);
    }
}
