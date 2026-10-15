namespace RaceDayAPI.Models
{
    public class Result
    {
        public int ResultID { get; set; }
        public int EnrolmentID { get; set; }
        public string OfficialTime { get; set; } = string.Empty;
        public int OverallPosition { get; set; }
        public int CategoryPosition { get; set; }
        public string? PacePerKm { get; set; }
    }
}
