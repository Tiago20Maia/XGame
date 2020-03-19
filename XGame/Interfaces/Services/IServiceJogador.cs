using System;
using System.Collections.Generic;
using XGame.Arguments.Base;
using XGame.Arguments.Jogador;

namespace XGame.Interfaces.Services
{
    public interface IServiceJogador
    {
        AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request);

        AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request);

        AlterarJogadorResponse AlterarJogador(AlterarJogadorRequest request);

        IEnumerable<JogadorResponse> ListarJogador();

        ResponseBase ExluirJogador(Guid id);
    }
}
