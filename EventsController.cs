using Microsoft.AspNetCore.Mvc;
using RaceDayAPI.Models;

namespace RaceDayAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private static List<Event> events = new List<Event>
        {
            new Event
            {
                EventID = 1,
                OrganiserID = 2,
                EventName = "Soweto Marathon",
                Description = "Annual marathon event in Soweto.",
                EventDate = 20261101,
                StartLocation = "FNB Stadium",
                City = "Johannesburg",
                Province = "Gauteng"
            },

            new Event
            {
                EventID = 2,
                OrganiserID = 2,
                EventName = "Cape Town Cycle Tour",
                Description = "Annual cycling event in Cape Town.",
                EventDate = 20260308,
                StartLocation = "Cape Town",
                City = "Cape Town",
                Province = "Western Cape"
            }
        };

        // GET: api/Events
        [HttpGet]
        public IActionResult GetEvents()
        {
            return Ok(events);
        }

        // GET: api/Events/1
        [HttpGet("{id}")]
        public IActionResult GetEvent(int id)
        {
            var eventItem = events.FirstOrDefault(e => e.EventID == id);

            if (eventItem == null)
            {
                return NotFound("Event not found.");
            }

            return Ok(eventItem);
        }

        // POST: api/Events
        [HttpPost]
        public IActionResult AddEvent(Event eventItem)
        {
            events.Add(eventItem);

            return Ok(eventItem);
        }

        // PUT: api/Events/1
        [HttpPut("{id}")]
        public IActionResult UpdateEvent(int id, Event updatedEvent)
        {
            var eventItem = events.FirstOrDefault(e => e.EventID == id);

            if (eventItem == null)
            {
                return NotFound("Event not found.");
            }

            eventItem.OrganiserID = updatedEvent.OrganiserID;
            eventItem.EventName = updatedEvent.EventName;
            eventItem.Description = updatedEvent.Description;
            eventItem.EventDate = updatedEvent.EventDate;
            eventItem.StartLocation = updatedEvent.StartLocation;
            eventItem.City = updatedEvent.City;
            eventItem.Province = updatedEvent.Province;

            return Ok(eventItem);
        }

        // DELETE: api/Events/1
        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            var eventItem = events.FirstOrDefault(e => e.EventID == id);

            if (eventItem == null)
            {
                return NotFound("Event not found.");
            }

            events.Remove(eventItem);

            return Ok("Event deleted successfully.");
        }
    }
}