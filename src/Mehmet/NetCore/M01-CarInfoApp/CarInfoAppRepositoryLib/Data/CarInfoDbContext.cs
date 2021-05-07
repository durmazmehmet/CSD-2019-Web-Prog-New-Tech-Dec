using CSD.CarInfoApp.Models;
using Microsoft.EntityFrameworkCore;

/*00. Nugetten;
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
*/

//01. Database first yaklaşımı
//02. Ortada bir database var ona göre yazıyoruz bu kodu

namespace CSD.CarInfoApp.Data
{
    //03. Dbcontext Microsoft.EntityFrameworkCore bir parçası
    //04. Dbcontext Disposible bir sınıf, yani using ile kullanacağız
    public partial class CarInfoDbContext : DbContext
    {
        public CarInfoDbContext() { }

        public CarInfoDbContext(DbContextOptions<CarInfoDbContext> options) : base(options) { }

        //05. bu DbSet<CarInfo> tabloma karşılık gelecek, 
        //06. auto propoery ile bunun içini doldurmak tamamen COntext'in sorumluluğunda olacak
        public virtual DbSet<CarInfo> CarInfos { get; set; } //10. CarInfos daki "s" için Bricelam.EntityFrameworkCore.Pluralizer yükledik... 

        //09. CarInfoDb hangi bağlantıdan alıyoruz?
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;

            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=CarInfoDb;Trusted_Connection=True;");
        }

        //07. carinfo modeli ile databasei eşleştirme. 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CarInfo>().ToTable("CarInfo");

            //08. tablo isimi model ismi ile aynı, fieldlerin isimleri de aynı
            //bundan dolayı ürettiğimiz model zaten eşleşiyor sadece propertyleri çekiyoruz
            modelBuilder.Entity<CarInfo>(entity =>
            {
                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EngineId)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
