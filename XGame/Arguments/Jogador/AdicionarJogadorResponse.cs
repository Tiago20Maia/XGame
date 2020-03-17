using System;
using XGame.Interfaces.Arguments;

namespace XGame.Arguments.Jogador
{
    public class AdicionarJogadorResponse : IResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

        public static explicit operator AdicionarJogadorResponse(Entities.Jogador entidade)
        {
            return new AdicionarJogadorResponse()
            {
                Id = entidade.Id,
                Message = XGame.Resources.Message.OPERACAO_REALIZADA_COM_SUCESSO
            };
        }
    }
}
