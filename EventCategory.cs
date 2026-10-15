namespace RaceDayAPI.Models
{
    public class EventCategory
    {
        public int CategoryID { get; set; }
        public int EventID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int DistanceKm { get; set; }
        public int EntryFee { get; set; }
    }
}
