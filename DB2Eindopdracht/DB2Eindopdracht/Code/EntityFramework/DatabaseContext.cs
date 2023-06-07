using DB2Eindopdracht.Entities;
using DB2Eindopdracht.EntityFramework.Entities;
using System.Data.Entity;


namespace DB2Eindopdracht
{
    public class DatabaseContext : DbContext 
    {
        public DbSet<Content> Contents { get; set; }
        public DbSet<ContentType> ContentTypes { get; set; }
        public DbSet<ContentWatched> Contentwatcheds  { get; set; }
        public DbSet<Episode> Episodes  { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Kijkwijzer> Kijkwijzers { get; set; }
        public DbSet<KijkwijzerContent> kijkwijzerContents  { get; set; }
        public DbSet<Movie> Movies  { get; set; }
        public DbSet<Preference> Preferences  { get; set; }
        public DbSet<Profile> Profiles  { get; set; }
        public DbSet<Quality> Qualities  { get; set; }
        public DbSet<Season> Seasons  { get; set; }
        public DbSet<Serie> Series  { get; set; }
        public DbSet<Subscription> Subscriptions  { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes  { get; set; }
        public DbSet<SubtitleLanguage> SubtitleLanguages  { get; set; }
        public DbSet<SubtitleLanguageContent> SubtitleLanguageContents  { get; set; }
        public DbSet<User> Users  { get; set; }
        public DbSet<WatchList> WatchLists  { get; set; }
        public DbSet<WatchTime> WatchTimes  { get; set; }

        public DatabaseContext() : base("ConnectionName")
        {
            Database.SetInitializer(
                new DropCreateDatabaseAlways<DatabaseContext>());
        }

        public void addData() { 
            using  (var db = new DatabaseContext())
            {
                try
                {
                    var newCustomer = new User
                    {
                        EmailAdress = "1@gmail.com",
                        Password = "1pw",
                        Active = true,
                        LoginAttempts = 1,
                        Blocked = true,
                        Date = "762023"
                    };

                    db.Users.Add(newCustomer);
                    db.SaveChanges();
                    Console.WriteLine("Data has been inserted");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
