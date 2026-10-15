using Microsoft.AspNetCore.Mvc;
using RaceDayAPI.Models;

namespace RaceDayAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantProfilesController : ControllerBase
    {
        private static List<ParticipantProfile> profiles = new List<ParticipantProfile>
        {
            new ParticipantProfile
            {
                ProfileID = "P001",
                UserID = "1",
                EmergencyContactName = "Jane Smith",
                EmergencyContactPhone = "0821234567",
                ClubName = "Soweto Running Club",
                AsaLicenceNumber = "ASA001"
            },

            new ParticipantProfile
            {
                ProfileID = "P002",
                UserID = "2",
                EmergencyContactName = "Peter Jones",
                EmergencyContactPhone = "0839876543",
                ClubName = "Cape Town Runners",
                AsaLicenceNumber = "ASA002"
            }
        };

        [HttpGet]
        public IActionResult GetProfiles()
        {
            return Ok(profiles);
        }

        [HttpGet("{id}")]
        public IActionResult GetProfile(string id)
        {
            var profile = profiles.FirstOrDefault(p => p.ProfileID == id);

            if (profile == null)
            {
                return NotFound("Participant profile not found.");
            }

            return Ok(profile);
        }

        [HttpPost]
        public IActionResult AddProfile(ParticipantProfile profile)
        {
            profiles.Add(profile);

            return Ok(profile);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProfile(string id, ParticipantProfile updatedProfile)
        {
            var profile = profiles.FirstOrDefault(p => p.ProfileID == id);

            if (profile == null)
            {
                return NotFound("Participant profile not found.");
            }

            profile.UserID = updatedProfile.UserID;
            profile.EmergencyContactName = updatedProfile.EmergencyContactName;
            profile.EmergencyContactPhone = updatedProfile.EmergencyContactPhone;
            profile.ClubName = updatedProfile.ClubName;
            profile.AsaLicenceNumber = updatedProfile.AsaLicenceNumber;

            return Ok(profile);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProfile(string id)
        {
            var profile = profiles.FirstOrDefault(p => p.ProfileID == id);

            if (profile == null)
            {
                return NotFound("Participant profile not found.");
            }

            profiles.Remove(profile);

            return Ok("Participant profile deleted successfully.");
        }
    }
}
