using DB2Eindopdracht.Entities;
using System.Data.Entity;


namespace DB2Eindopdracht
{
    public class DatabaseContext : DbContext 
    {
        public virtual DbSet<Episode> Episodes { get; set; }
        public virtual DbSet<Season> Seasons { get; set; }
        public DatabaseContext() : base("data source=(localdb)\\MSSQLLocalDB;Initial catalog=NetflixDB;")
        {
            Database.SetInitializer(
                new DropCreateDatabaseAlways<DatabaseContext>());
        }
    }
}
