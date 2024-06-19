using CondSys.Data.Migrations;
using CondSys.Model;
using CondSys.Model.Configuracao;
using CondSys.Model.Menu;
using CondSys.Model.UH;
using CondSys.Model.Correspondencias;
using CondSys.Model.Visitante;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Data.Context
{
    public class ContextMySql : DbContext
    {
        public ContextMySql()
            : base("name=CnnCondSys")
        {
            Database.SetInitializer<ContextMySql>(null);
        }

        public ContextMySql(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
            Database.SetInitializer<ContextMySql>(null);
        }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<Unidade> Unidades { get; set; }
        public virtual DbSet<Configuracao> Configuracoes { get; set; }
        public virtual DbSet<Movimento> Movimentos { get; set; }
        public virtual DbSet<Correspondencia> Correspondencias { get; set; }
        public virtual DbSet<Aviso> Avisos { get; set; }
        public virtual DbSet<AvisoMorador> AvisoMoradores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(500));

            this.Configuration.UseDatabaseNullSemantics = false;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = true;
            this.Configuration.ValidateOnSaveEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            
            Mapping.Mapping.Map(modelBuilder);
        }

        public async Task Commit()
        {
            await base.SaveChangesAsync();
        }

        public void Salvar<T>(T entity) where T : class
        {
            Set<T>().Attach(entity);
            Entry(entity).State = EntityState.Added;
        }

        public void Alterar<T>(T entity) where T : class
        {
            Set<T>().Attach(entity);
            Entry(entity).State = EntityState.Modified;
        }

        public void Excluir<T>(T entity) where T : class
        {
            Set<T>().Attach(entity);
            Entry(entity).State = EntityState.Deleted;

        }

        public IDbSet<T> DbSet<T>() where T : class
        {
            return Set<T>();
        }

        public T Find<T>(params object[] keyValues) where T : class
        {
            return Set<T>().Find(keyValues);
        }

        public T Find<T>(string sql) where T : class
        {
            return Set<T>().SqlQuery(sql).FirstOrDefault<T>();
        }

        public List<T> RetornaLista<T>(string sql) where T : class
        {
            return Database.SqlQuery<T>(sql).ToList();
        }

        public void Remove<T>(T item) where T : class
        {
            try
            {
                Set<T>().Attach(item);
                Set<T>().Remove(item);
                Entry(item).State = EntityState.Deleted;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
