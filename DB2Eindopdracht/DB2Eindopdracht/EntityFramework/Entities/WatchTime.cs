namespace DB2Eindopdracht.EntityFramework.Entities
{
    public class WatchTime
    {
        public int watchTime { get; set; }
        public int ProfileId { get; set; }
        public int ContentId { get; set; }
        public int TimeStamp { get; set; }
        public int LanguageContent { get; set; }
        public string WatchDate { get; set; }
    }
}
