using CSD.ParticipantsApp.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSD.ParticipantsApp.Repository.Data
{
    public partial class ParticipantsAppDbContext : DbContext
    {
        public ParticipantsAppDbContext() { }

        public ParticipantsAppDbContext(DbContextOptions<ParticipantsAppDbContext> options)
            : base(options) { }

        public virtual DbSet<Participant> Participants { get; set; } //tablonun ismine karşılık gelmeli ama **

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;

            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=ParticipantsAppDb;Trusted_Connection=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participant>().ToTable("Participant"); //** db'de participant

            modelBuilder.Entity<Participant>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
