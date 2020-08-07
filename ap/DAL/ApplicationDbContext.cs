// =============================
// Email: info@ebenmonney.com
// www.ebenmonney.com/templates
// =============================

using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using DAL.Models.Interfaces;

namespace DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public string CurrentUserId { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Instalacao> Instalacoes { get; set; }
        public DbSet<Fatura> Faturas { get; set; }



        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            const string priceDecimalType = "decimal(18,2)";

            builder.Entity<ApplicationUser>().HasMany(u => u.Claims).WithOne().HasForeignKey(c => c.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ApplicationUser>().HasMany(u => u.Roles).WithOne().HasForeignKey(r => r.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ApplicationRole>().HasMany(r => r.Claims).WithOne().HasForeignKey(c => c.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ApplicationRole>().HasMany(r => r.Users).WithOne().HasForeignKey(r => r.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Cliente>().Property(c => c.Nome).IsRequired().HasMaxLength(100);
            builder.Entity<Cliente>().HasIndex(c => c.Nome);
            builder.Entity<Cliente>().HasOne(p => p.EnderecoCobranca).WithOne().OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Cliente>().HasMany(r => r.ListaInstalacao).WithOne().HasForeignKey(r => r.ClienteId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Cliente>().ToTable($"App{nameof(this.Clientes)}");

            builder.Entity<Instalacao>().Property(p => p.Codigo).IsRequired().HasMaxLength(100);
            builder.Entity<Instalacao>().HasIndex(p => p.Codigo);
            builder.Entity<Instalacao>().HasOne(p => p.Cliente).WithMany(p => p.ListaInstalacao).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Instalacao>().HasOne(p => p.EnderecoInstalacao).WithOne().OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Instalacao>().HasMany(r => r.ListaFatura).WithOne().HasForeignKey(r => r.InstalacaoId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Instalacao>().ToTable($"App{nameof(this.Instalacoes)}");

            builder.Entity<Fatura>().ToTable($"App{nameof(this.Faturas)}");
            builder.Entity<Fatura>().Property(p => p.ValorConta).HasColumnType(priceDecimalType);

            builder.Entity<Endereco>().ToTable($"App{nameof(this.Enderecos)}");
        }




        public override int SaveChanges()
        {
            UpdateAuditEntities();
            return base.SaveChanges();
        }


        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            UpdateAuditEntities();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateAuditEntities();
            return base.SaveChangesAsync(cancellationToken);
        }


        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateAuditEntities();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }


        private void UpdateAuditEntities()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));


            foreach (var entry in modifiedEntries)
            {
                var entity = (IAuditableEntity)entry.Entity;
                DateTime now = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDate = now;
                    entity.CreatedBy = CurrentUserId;
                }
                else
                {
                    base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                    base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                }

                entity.UpdatedDate = now;
                entity.UpdatedBy = CurrentUserId;
            }
        }
    }
}
