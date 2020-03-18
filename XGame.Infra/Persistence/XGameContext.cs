using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using XGame.Entities;

namespace XGame.Infra.Persistence
{
    public class XGameContext : DbContext
    {
        public XGameContext() : base("XGameConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public IDbSet<Jogador> Jogadores { get; set; }

        public IDbSet<Plataforma> Plataformas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove a pluralização dos nomes das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Remoe exclusão em cascata
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Seta para usar varchar ou inves de nvarchar
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            //Caso eu esqueça de informar o tamanho do campo ele irá colocar varchar de 100
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            //Mapeia as entidades

            #region Adiciona entidades mapeadas - Automaticamente via Assembly
            modelBuilder.Configurations.AddFromAssembly(typeof(XGameContext).Assembly);
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
