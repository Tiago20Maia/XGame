using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using XGame.Entities.Base;
using XGame.Interfaces.Repositories.Base;

namespace XGame.Infra.Persistence.Repositories.Base
{
    public class RepositoryBase <TEntidade, TId> : IRepositoryBase<TEntidade, TId>
        where TEntidade : EntityBase
        where TId : struct
    {

        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntidade> ListarPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, bool>>[] includeProperties)
        {
            return Listar(includeProperties).Where(where);
        }
        
        public IQueryable<TEntidade> ListarEOrdenarPor<Tkey>(Expression<Func<TEntidade, bool>> where, Expression<Func<TEntidade, Tkey>> ordem, bool ascendente = true)
        {
            return ascendente ? Listar(where, includeProperties).OrderBy(ordem) : ListarPor(where, includeProperties).OrderByDescending(ordem);
        }

        public TEntidade ObterPor(Func<TEntidade, bool> where, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return Listar(includeProperties).FirstOrDefault(where);
        }

        public bool Existe(Func<TEntidade, bool> where)
        {
            return _context.Set<TEntidade>().Any(where);
        }

        public IQueryable<TEntidade> Listar(params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            IQueryable<TEntidade> query = _context.Set<TEntidade>();

            if (includeProperties.Any())
            {
                return Include(_context.Set<TEntidade>(), includeProperties);
            }

            return query;
        }

        public IQueryable<TEntidade> ListarOrdenarPor<Tkey>(Expression<Func<TEntidade, Tkey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return ascendente ? Listar(includeProperties).OrderBy(ordem) : Listar(includeProperties).OrderByDescending(ordem);
        }

        public TEntidade ObterPorId(TId id, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            if (includeProperties.Any())
            {
                return Listar(includeProperties).FirstOrDefault(x => x.Id.ToString() == id.ToString());
            }
            return _context.Set<TEntidade>().Find(id);
        }

        public TEntidade Adicionar(TEntidade entidade)
        {
            return _context.Set<TEntidade>().Add(entidade);
        }

        public TEntidade Editar(TEntidade entidade)
        {
            _context.Entry(entidade).State = System.Data.Entity.EntityState.Modified;

            return entidade;
        }

        public void Remover(TEntidade entidade)
        {
            _context.Set<TEntidade>().Remove(entidade);
        }

        public IEnumerable<TEntidade> AdicionarLista(IEnumerable<TEntidade> entidades)
        {
            return _context.Set<TEntidade>().AddRange(entidades);
        }

        public IQueryable<TEntidade> Include(IQueryable<TEntidade> query, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }
            return query;
        }

    }
}
