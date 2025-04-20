using HomeworkApp.Dal.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkApp.Dal.Controllers;

[ApiController]
[Route("common")]
public class MainController(
    [FromServices] ISecondMicroservice secondMicroservice) : Controller
{
    [HttpPost("check")]
    public async Task<IActionResult> CheckData(
        [FromBody] Person person,
        CancellationToken cancellationToken)
    {
        if (PersonValidator.Validate(person))
        {
            await secondMicroservice.AddPerson(new DbPerson
            {
                Name = person.Name,
                Age = person.Age,
                CreatedAt = DateTimeOffset.UtcNow
            });

            return Ok();
        }
        else
            return BadRequest();
    }
}
