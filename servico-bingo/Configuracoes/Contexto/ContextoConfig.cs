using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OrcamentoGenerico.Api.Dominio.Entite.Base;
using servico_bingo.Model;

namespace OrcamentoGenerico.Api.Configuracoes.Contexto
{
    public class ContextoConfig : DbContext
    {
        //public ContextoConfig(DbContextOptions<ContextoConfig> options) : base(options) { }

        public virtual DbSet<NumeroBingo> NumeroBingo { get; set; }
        public virtual DbSet<CartelaNumeroBingo> CartelaNumeroBingo { get; set; }
        public virtual DbSet<Cartela> Cartela { get; set; }
        public virtual DbSet<NumeroSorteado> NumeroSorteado { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bingo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"/*@"Server=localhost\SQLEXPRESS;Database=UpdateGamaAcademy;Trusted_Connection=True;"*/);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cartela>()
                .HasMany(c => c.CartelaNumeroBingos)
                .WithOne(cn => cn.Cartela)
                .HasForeignKey(cn => cn.CartelaId);

            modelBuilder.Entity<NumeroBingo>()
                .HasKey(n => n.Numero);

            modelBuilder.Entity<NumeroBingo>()
                .HasMany(n => n.CartelaNumeroBingos)
                .WithOne(cn => cn.NumeroBingo)
                .HasForeignKey(cn => cn.NumeroBingoId);

            modelBuilder.Entity<NumeroBingo>()
                .HasOne(n => n.NumeroSorteado)
                .WithOne(ns => ns.NumeroBingo)
                .HasForeignKey<NumeroSorteado>(ns => ns.NumeroBingoId);

            modelBuilder.Entity<CartelaNumeroBingo>()
                .HasKey(cn => new { cn.NumeroBingoId, cn.CartelaId });

            modelBuilder.Entity<NumeroSorteado>()
                .HasKey(ns => ns.NumeroBingoId);

            modelBuilder.Entity<Cartela>()
                .Property(c => c.Nome)
                .HasMaxLength(255);

            modelBuilder.Entity<Cartela>()
                .Property(c => c.CPF)
                .HasMaxLength(14)
                .IsFixedLength(true);
        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextoConfig).Assembly);
        //}

        //public override int SaveChanges(bool acceptAllChangesOnSuccess)
        //{
        //    UpdateSaveChanges();

        //    return base.SaveChanges(acceptAllChangesOnSuccess);
        //}

        //public override int SaveChanges()
        //{
        //    UpdateSaveChanges();

        //    return base.SaveChanges();
        //}

        //public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        //{
        //    UpdateSaveChanges();

        //    return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        //}

        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    UpdateSaveChanges();

        //    return await base.SaveChangesAsync(cancellationToken);
        //}

        //private void UpdateSaveChanges()
        //{
        //    var entries = ChangeTracker
        //                    .Entries()
        //                    .Where(e => e.Entity is BaseEntite &&
        //                                (e.State == EntityState.Added || e.State == EntityState.Modified));

        //    foreach (var entityEntry in entries)
        //    {
        //        UpdateSaveChanges(entityEntry);
        //    }
        //}

        //private void UpdateSaveChanges(EntityEntry entityEntry)
        //{
        //    ((BaseEntite)entityEntry.Entity).DataModificacao = DateTime.Now;
        //    //((BaseEntite)entityEntry.Entity).UsuarioModificacaoLog = ApplicationContext.Current.Request.Headers["PreferredUsername"].ToString() ?? null;

        //    if (entityEntry.State == EntityState.Added)
        //    {
        //        ((BaseEntite)entityEntry.Entity).DataCriacao = DateTime.Now;
        //    }
        //}
    }
}
