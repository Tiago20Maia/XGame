using System;
using XGame.Arguments.Jogador;
using XGame.Interfaces.Services;
using XGame.ValueObject;

namespace XGame.Services
{
    public class ServiceJogador : IServiceJogador
    {
        private readonly IRepositoryJogador _repositoryJogador;

        public ServiceJogador(IRepositoryJogador repositoryJogador)
        {
            _repositoryJogador = repositoryJogador;
        }
        public ServiceJogador()
        {
            
        }

        public AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request)
        {
            Guid id = _repositoryJogador.AdicionarJogador(request);

            return new AdicionarJogadorResponse() { Id = id, Message = "Operação realizada com sucesso!" };
        }
        public AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request)
        {
            if (request == null)
            {
                throw new Exception("AutenticarJogadorRequest é obrigatório.");
            }

            if (string.IsNullOrEmpty(request.Email))
            {
                throw new Exception("Informe o email.");
            }

            if (string.IsNullOrEmpty(request.Senha))
            {
                throw new Exception("Informw a senha.");
            }

            if (isEmail(request.Email))
            {
                throw new Exception("Informe um email.");
            }
            var response = _repositoryJogador.AutenticarJogador(request);

            return response;
        }
        private bool isEmail(string email)
        {
            return false;
        }
    }
}
