using Microsoft.AspNetCore.Mvc;
using RaceDayAPI.Models;

namespace RaceDayAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrolmentsController : ControllerBase
    {
        private static List<Enrolment> enrolments = new List<Enrolment>
        {
            new Enrolment
            {
                EnrolmentID = 1,
                CategoryID = 1,
                ParticipantID = 1,
                RaceNumber = 101,
                EnrolmentDate = 20260910,
                Status = "Confirmed",
                Pending = "No"
            },

            new Enrolment
            {
                EnrolmentID = 2,
                CategoryID = 2,
                ParticipantID = 1,
                RaceNumber = 102,
                EnrolmentDate = 20260910,
                Status = "Pending",
                Pending = "Yes"
            }
        };

        [HttpGet]
        public IActionResult GetEnrolments()
        {
            return Ok(enrolments);
        }

        [HttpGet("{id}")]
        public IActionResult GetEnrolment(int id)
        {
            var enrolment = enrolments.FirstOrDefault(e => e.EnrolmentID == id);

            if (enrolment == null)
            {
                return NotFound("Enrolment not found.");
            }

            return Ok(enrolment);
        }

        [HttpPost]
        public IActionResult AddEnrolment(Enrolment enrolment)
        {
            enrolments.Add(enrolment);

            return Ok(enrolment);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEnrolment(int id, Enrolment updatedEnrolment)
        {
            var enrolment = enrolments.FirstOrDefault(e => e.EnrolmentID == id);

            if (enrolment == null)
            {
                return NotFound("Enrolment not found.");
            }

            enrolment.CategoryID = updatedEnrolment.CategoryID;
            enrolment.ParticipantID = updatedEnrolment.ParticipantID;
            enrolment.RaceNumber = updatedEnrolment.RaceNumber;
            enrolment.EnrolmentDate = updatedEnrolment.EnrolmentDate;
            enrolment.Status = updatedEnrolment.Status;
            enrolment.Pending = updatedEnrolment.Pending;

            return Ok(enrolment);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEnrolment(int id)
        {
            var enrolment = enrolments.FirstOrDefault(e => e.EnrolmentID == id);

            if (enrolment == null)
            {
                return NotFound("Enrolment not found.");
            }

            enrolments.Remove(enrolment);

            return Ok("Enrolment deleted successfully.");
        }
    }
}
