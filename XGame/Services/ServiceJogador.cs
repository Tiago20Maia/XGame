using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using XGame.Arguments.Base;
using XGame.Arguments.Jogador;
using XGame.Entities;
using XGame.Interfaces.Services;
using XGame.Resources;
using XGame.ValueObject;

namespace XGame.Services
{
    public class ServiceJogador : Notifiable, IServiceJogador
    {
        private readonly IRepositoryJogador _repositoryJogador;

        public ServiceJogador()
        {

        }
        public ServiceJogador(IRepositoryJogador repositoryJogador)
        {
            _repositoryJogador = repositoryJogador;
        }

        public AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request)
        {
            var nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            var email = new Email(request.Email);

            Jogador jogador = new Jogador(nome, email, request.Senha);

            if (this.IsInvalid())
            {
                return null;
            }

            jogador = _repositoryJogador.Adicionar(jogador);

            return (AdicionarJogadorResponse)jogador;
        }

        public AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request)
        {
            if (request == null)
            {
                AddNotification("AutenticarJogadorRequest", Message.X0_E_OBRIGATORIO.ToFormat("AutenticarJogadorRequest"));
            }

            var email = new Email(request.Email);
            var jogador = new Jogador(email, request.Senha);

            AddNotifications(jogador, email);

            if (jogador.IsInvalid())
            {
                return null;
            }

            jogador = _repositoryJogador.ObterPor(x => x.Email.Endereco ==jogador.Email.Endereco, x => x.Senha == jogador.Senha);

            return (AutenticarJogadorResponse)jogador;
        }

        public AlterarJogadorResponse AlterarJogador(AlterarJogadorRequest request)
        {
            if (request == null)
            {
                AddNotification("AutenticarJogadorRequest", Message.X0_E_OBRIGATORIO.ToFormat("AlterarJogadorRequest"));
            }

            Jogador jogador = _repositoryJogador.ObterPorId(request.Id);

            if (true)
            {
                AddNotification("Id", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            var nome = new Nome(request.PrimeiroNome, request.UltimoNome);
            var email = new Email(request.Email);

            jogador.AlterarJogador(nome, email, jogador.Status);

            AddNotifications(jogador, email);

            if (jogador.IsInvalid())
            {
                return null;
            }

            _repositoryJogador.Editar(jogador);

            return (AlterarJogadorResponse)jogador;
        }

        public IEnumerable<JogadorResponse> ListarJogador()
        {
            return _repositoryJogador.Listar().Select(jogador => (JogadorResponse)jogador).ToList();
        }

        public ResponseBase ExluirJogador(Guid id)
        {
            Jogador jogador = _repositoryJogador.ObterPorId(id);

            if (jogador == null)
            {
                AddNotification("Id", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _repositoryJogador.Remover(jogador);

            return new ResponseBase();
        }
    }
}
