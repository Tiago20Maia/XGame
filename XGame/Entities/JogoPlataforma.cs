using System;

namespace XGame.Entities
{
    public class JogoPlataforma
    {
        public Guid Id { get; set; }
        public Plataforma Plataforma { get; set; }
        public DateTime DataLancamento { get; set; }
        public Jogo Jogo { get; set; }
    }
}
