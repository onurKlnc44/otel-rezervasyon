using Microsoft.EntityFrameworkCore;

namespace projeodev.Models
{
    public class DataContext:DbContext
    {

        public DataContext(DbContextOptions<DataContext>
            options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Oda>().HasOne(x => x.Detay).WithMany(x => x.odas).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Rezervasyon>().HasOne(x => x.kullanıcı).WithMany(x =>x.rezervasyons).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Rezervasyon>().HasOne(x => x.oda).WithMany(x => x.Rezervasyons).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Resimler>().HasOne(x => x.oda).WithMany(x=>x.resimlers).OnDelete(DeleteBehavior.SetNull);

        }
     
        public DbSet<Detay> Detay { get; set; }
        public DbSet<Kullanıcı> Kullanıcı { get; set; }
        public DbSet<Oda> Oda { get; set; }
        public DbSet<Rezervasyon> Rezervarsyon { get; set; }

        public DbSet<Resimler> Resimler { get; set; }


    }
}
