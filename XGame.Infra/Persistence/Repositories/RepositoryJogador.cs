using System;
using XGame.Entities;
using XGame.Infra.Persistence.Repositories.Base;
using XGame.Interfaces.Services;

namespace XGame.Infra.Persistence.Repositories
{
    public class RepositoryJogador : RepositoryBase<Jogador, Guid> , IRepositoryJogador
    {
        protected readonly XGameContext _context;

        public RepositoryJogador(XGameContext context) : base(context)
        {
            _context = context;
        }
    }
}
