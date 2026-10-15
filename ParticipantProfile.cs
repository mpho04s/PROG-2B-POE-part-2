namespace RaceDayAPI.Models
{
    public class ParticipantProfile
    {
        public string ProfileID { get; set; } = string.Empty;
        public string UserID { get; set; } = string.Empty;
        public string EmergencyContactName { get; set; } = string.Empty;
        public string EmergencyContactPhone { get; set; } = string.Empty;
        public string? ClubName { get; set; } 
        public string? AsaLicenceNumber { get; set; }

    }
}
