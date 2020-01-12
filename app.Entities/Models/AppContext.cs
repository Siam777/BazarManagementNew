using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using app.Entities.Models.Mapping;
using Repository.Pattern.Ef6;
using app.Entities.Models;

namespace app.Entities.Models
{
    public partial class AppContext : DataContext
    {
        static AppContext()
        {
            Database.SetInitializer<AppContext>(null);
        }

        public AppContext()
            : base("Name=AppContext")
        {
        }

       // public DbSet<C_Migration> C_Migration { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<MonthlyActivatedUser> MonthlyActivatedUser { get; set; }
        public DbSet<BazarType> BazarType { get; set; }
        public DbSet<BazarExpense> BazarExpense { get; set; }
        public DbSet<CollectionForBazarAndInstallation> CollectionForBazarAndInstallation { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           // modelBuilder.Configurations.Add(new C_MigrationMap());
           // modelBuilder.Configurations.Add(new AcademicBranchMap());
            modelBuilder.Configurations.Add(new UserInfoMap());
            modelBuilder.Configurations.Add(new ImageMap());
            modelBuilder.Configurations.Add(new MonthlyActivatedUserMap());
            modelBuilder.Configurations.Add(new BazarTypeMap());
            modelBuilder.Configurations.Add(new BazarExpenseMap());
            modelBuilder.Configurations.Add(new CollectionForBazarAndInstallationMap());
        }
    }
}
