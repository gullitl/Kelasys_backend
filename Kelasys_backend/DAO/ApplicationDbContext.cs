using Microsoft.EntityFrameworkCore;
using Kelasys_backend.Models.VO;

namespace Kelasys_backend.DAO {
    public class ApplicationDbContext : DbContext {

        #region DbContext configurations

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
            this.Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            base.OnConfiguring(options);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }

        #endregion
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }


    }
}
