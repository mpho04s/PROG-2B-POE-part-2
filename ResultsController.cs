using Microsoft.AspNetCore.Mvc;
using RaceDayAPI.Models;

namespace RaceDayAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResultsController : ControllerBase
    {
        private static List<Result> results = new List<Result>
        {
            new Result
            {
                ResultID = 1,
                EnrolmentID = 1,
                OfficialTime = "03:45:20",
                OverallPosition = 25,
                CategoryPosition = 10,
                PacePerKm = "05:20"
            },

            new Result
            {
                ResultID = 2,
                EnrolmentID = 2,
                OfficialTime = "01:52:10",
                OverallPosition = 50,
                CategoryPosition = 15,
                PacePerKm = "05:19"
            }
        };

        [HttpGet]
        public IActionResult GetResults()
        {
            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetResult(int id)
        {
            var result = results.FirstOrDefault(r => r.ResultID == id);

            if (result == null)
            {
                return NotFound("Result not found.");
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddResult(Result result)
        {
            results.Add(result);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateResult(int id, Result updatedResult)
        {
            var result = results.FirstOrDefault(r => r.ResultID == id);

            if (result == null)
            {
                return NotFound("Result not found.");
            }

            result.EnrolmentID = updatedResult.EnrolmentID;
            result.OfficialTime = updatedResult.OfficialTime;
            result.OverallPosition = updatedResult.OverallPosition;
            result.CategoryPosition = updatedResult.CategoryPosition;
            result.PacePerKm = updatedResult.PacePerKm;

            return Ok(result);
        }

        // DELETE: api/Results/1
        [HttpDelete("{id}")]
        public IActionResult DeleteResult(int id)
        {
            var result = results.FirstOrDefault(r => r.ResultID == id);

            if (result == null)
            {
                return NotFound("Result not found.");
            }

            results.Remove(result);

            return Ok("Result deleted successfully.");
        }
    }
}
