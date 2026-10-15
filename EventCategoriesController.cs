using Microsoft.AspNetCore.Mvc;
using RaceDayAPI.Models;

namespace RaceDayAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventCategoriesController : ControllerBase
    {
        private static List<EventCategory> categories = new List<EventCategory>
        {
            new EventCategory
            {
                CategoryID = 1,
                EventID = 1,
                CategoryName = "42.2 km Marathon",
                DistanceKm = 42,
                EntryFee = 300
            },

            new EventCategory
            {
                CategoryID = 2,
                EventID = 1,
                CategoryName = "21.1 km Half Marathon",
                DistanceKm = 21,
                EntryFee = 200
            },

            new EventCategory
            {
                CategoryID = 3,
                EventID = 1,
                CategoryName = "10 km Run",
                DistanceKm = 10,
                EntryFee = 100
            }
        };

        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = categories.FirstOrDefault(c => c.CategoryID == id);

            if (category == null)
            {
                return NotFound("Category not found.");
            }

            return Ok(category);
        }

        [HttpPost]
        public IActionResult AddCategory(EventCategory category)
        {
            categories.Add(category);

            return Ok(category);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, EventCategory updatedCategory)
        {
            var category = categories.FirstOrDefault(c => c.CategoryID == id);

            if (category == null)
            {
                return NotFound("Category not found.");
            }

            category.EventID = updatedCategory.EventID;
            category.CategoryName = updatedCategory.CategoryName;
            category.DistanceKm = updatedCategory.DistanceKm;
            category.EntryFee = updatedCategory.EntryFee;

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = categories.FirstOrDefault(c => c.CategoryID == id);

            if (category == null)
            {
                return NotFound("Category not found.");
            }

            categories.Remove(category);

            return Ok("Category deleted successfully.");
        }
    }
}
