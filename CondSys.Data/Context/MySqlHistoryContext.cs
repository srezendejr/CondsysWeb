using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Migrations.History;
using System.Data.Common;

namespace CicloVida.Data.Context
{
    public class MySqlHistoryContext:HistoryContext
    {
        public MySqlHistoryContext(DbConnection conn, string schema ):base(conn, schema)
        {
            
        }
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HistoryRow>().Property(h => h.MigrationId).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<HistoryRow>().Property(h => h.ContextKey).HasMaxLength(200).IsRequired();
        }
    }
}
