using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using XGame.Enum;
using XGame.Extensions;
using XGame.Resources;
using XGame.ValueObject;

namespace XGame.Entities
{
    public class Jogador : Notifiable
    {
        public Jogador(Email email, string senha)
        {
            Email = email;
            Senha = senha;
            new AddNotifications<Jogador>(this)
                .IfNullOrEmptyOrInvalidLength(x => x.Senha, 6, 32, "A senha deve ter entre 6 a 32 caracteres");
        }
        public Jogador(Nome nome, Email email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Id = Guid.NewGuid();
            Status = EnumSituacaoJogador.EmAnalise;

            new AddNotifications<Jogador>(this)
                .IfNullOrInvalidLength(x => x.Senha, 6, 32, Message.X0_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_X2_CARACTERES.ToFormat("Senha", "6", "32"));
            if (IsValid())
            {
                Senha = Senha.ConvertToMD5();
            }
            AddNotifications(nome, email);
        }

        public void AlterarJogador(Nome nome, Email email, EnumSituacaoJogador statu)
        {
            Nome = nome;
            Email = email;

            new AddNotifications<Jogador>(this).IfFalse(Status == EnumSituacaoJogador.Ativo, "Só é alterar jogador com status ativo.");

            AddNotifications(nome, email);
        }

        public Guid Id { get; private set; }
        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public string Senha { get; private set; }
        public EnumSituacaoJogador Status { get; private set; }

        public override string ToString()
        {
            return this.Nome.PrimeiroNome + " " + this.Nome.UltimoNome;
        }
       
    }
}
