using CondSys.Enumerator;
using CondSys.Model;
using CondSys.Model.Configuracao;
using CondSys.Model.Correspondencias;
using CondSys.Model.Menu;
using CondSys.Model.UH;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Data.Mapping
{
    public static class Mapping
    {
        public static void Map(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>()
                .ToTable("Pessoa")
                .HasKey(p => p.PessoaId)
                .Property(p => p.PessoaId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Morador>()
                .HasOptional(r => r.Unidade).WithMany(m => m.Moradores).HasForeignKey(f => f.UnidadeId);

            modelBuilder.Entity<PessoaDocumento>()
                .ToTable("PessoaDocumento")
                .HasKey(p => p.PessoaDocumentoId)
                .Property(p => p.PessoaDocumentoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<PessoaDocumento>()
                .HasRequired(r => r.Pessoa).WithMany(m => m.Documentos).HasForeignKey(f => f.PessoaId);

            modelBuilder.Entity<PessoaContato>()
                .ToTable("PessoaContato")
                .HasKey(p => p.PessoaContatoId)
                .Property(p => p.PessoaContatoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<PessoaContato>()
                .HasOptional(r => r.Pessoa).WithMany(m => m.Contatos).HasForeignKey(f => f.PessoaId);

            modelBuilder.Entity<PessoaEndereco>()
                .ToTable("PessoaEndereco")
                .HasKey(k => k.PessoaEnderecoId)
                .Property(p => p.PessoaEnderecoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<PessoaEndereco>()
                .HasOptional(r => r.Pessoa).WithMany(m => m.Enderecos).HasForeignKey(f => f.PessoaId);

            modelBuilder.Entity<Movimento>()
                .ToTable("Movimento")
                .HasKey(k => k.MovimentoId)
                .Property(p => p.MovimentoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Movimento>()
                .HasRequired(r => r.Morador).WithMany().HasForeignKey(f => f.MoradorId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Movimento>()
                .HasRequired(r => r.Visitante).WithMany().HasForeignKey(f => f.VisitanteId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .ToTable("Usuario")
                .HasKey(k => k.UsuarioId)
                .Property(p => p.UsuarioId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Usuario>()
                .HasOptional(o => o.Morador).WithMany().HasForeignKey(f => f.PessoaId);

            modelBuilder.Entity<Aviso>()
                .ToTable("Aviso")
                .HasKey(k => k.AvisoId)
                .Property(p => p.AvisoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<AvisoMorador>()
                .HasRequired(o => o.Aviso).WithMany(m => m.Moradores).HasForeignKey(f => f.AvisoId).WillCascadeOnDelete(false);

            modelBuilder.Entity<AvisoMorador>()
                .ToTable("AvisoMorador")
                .HasKey(k => k.AvisoMoradorId)
                .Property(p => p.AvisoMoradorId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<AvisoMorador>()
                .HasRequired(o => o.Morador).WithMany().HasForeignKey(f => f.MoradorId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Veiculo>()
                .ToTable("Veiculo")
                .HasKey(k => k.VeiculoId)
                .Property(p => p.VeiculoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Veiculo>()
                .HasRequired(r => r.Unidade).WithMany(m => m.Veiculos).HasForeignKey(f => f.UnidadeId);

            modelBuilder.Entity<Unidade>()
                .ToTable("Unidade")
                .HasKey(k => k.UnidadeId)
                .Property(p => p.UnidadeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Menu>()
                .ToTable("Menu")
                .HasKey(k => k.MenuId)
                .Property(p => p.MenuId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<MenuAcesso>()
                .ToTable("MenuAcesso")
                .HasKey(k => k.MenuAcessoId)
                .Property(p => p.MenuAcessoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<MenuAcesso>()
                .HasRequired(r => r.Menu).WithMany(m => m.MenusAcesso).HasForeignKey(f => f.MenuId).WillCascadeOnDelete(true);

            modelBuilder.Entity<Configuracao>()
                .ToTable("Configuracao")
                .HasKey(k => k.ConfiguracaoId)
                .Property(p => p.ConfiguracaoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Correspondencia>()
                .ToTable("Correspondencia")
                .HasKey(k => k.CorrespondenciaId)
                .Property(p => p.CorrespondenciaId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Correspondencia>()
                .HasRequired(r => r.Morador).WithMany().HasForeignKey(f => f.MoradorId);
            modelBuilder.Entity<Correspondencia>()
                .HasRequired(r => r.UsuarioRecebimento).WithMany().HasForeignKey(f => f.UsuarioRecebimentoId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Correspondencia>()
                .HasRequired(r => r.UsuarioEntrega).WithMany().HasForeignKey(f => f.UsuarioEntregaId).WillCascadeOnDelete(false);
        }
    }
}
