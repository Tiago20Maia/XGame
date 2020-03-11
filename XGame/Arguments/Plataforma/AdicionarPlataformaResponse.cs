using System;
using XGame.ValueObject;

namespace XGame.Arguments.Jogador
{
    public class AdicionarPlataformaResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        
        public string Message { get; set; }

    }
}
