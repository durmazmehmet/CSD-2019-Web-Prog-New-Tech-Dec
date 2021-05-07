using CSD.AppointmentApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSD.AppointmentApp.Data
{
    public partial class AppointmentAppDbContext : DbContext
    {
        public AppointmentAppDbContext()
        {
        }

        public AppointmentAppDbContext(DbContextOptions<AppointmentAppDbContext> options)
            : base(options)
        {
        }

        // Aşağıdaki DbSet'ler tablolarımızı temsil eder. Dikkat scaffold ile oluşturduğumuzda
        // tıpkı veritabanında olduğu gibi tablo isimlerinde s takısı yoktu biz ekledik.
        // **Dikkat 1 
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;

            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=AppointmentAppDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aşağıdaki DbSet'ler tablolarımızı temsil eder.
            // **Dikkat 1'de "s" takısı eklediğimizden dolayı isim farklılığı oldu.
            // Aşağıda takip eden 2 satırdaki kodları yazmak durumunda kaldık
            // Model builder ile sınıf ile veri tabanındaki tabloları ilişkilendirdik.
            modelBuilder.Entity<Appointment>().ToTable("Appointment");
            modelBuilder.Entity<Client>().ToTable("Client");

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.Property(e => e.ClientId)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Date).HasColumnType("datetime");

                // Aşağıda Client tablosundaki ID'nin Appointment tablosunda 
                // foreign key olarak verildiğini görüyoruz
                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}