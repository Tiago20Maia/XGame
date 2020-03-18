using System;
using System.Collections.Generic;
using System.Linq;
using XGame.Entities;
using XGame.Interfaces.Services;

namespace XGame.Infra.Persistence.Repositories
{
    public class Repository : IRepositoryJogador
    {
        protected readonly XGameContext _context;

        public Repository(XGameContext context)
        {
            _context = context;
        }

        public Jogador AdicionarJogador(Jogador jogador)
        {
            _context.Jogadores.Add(jogador);
            _context.SaveChanges();

            return jogador;
        }

        public void AlterarJogador(Jogador jogador)
        {
            throw new NotImplementedException();
        }

        public Jogador AutenticarJogador(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Jogador> ListarJogador()
        {
            return _context.Jogadores.ToList();
        }

        public Jogador ObterJogadorPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
