using System.Text.Json.Serialization;

namespace HomeworkApp.Dal.Models;

public class DbPerson
{
    public required string Name { get; set; }
    public int Age { get; set; }

    [JsonPropertyName("created_at")]
    public DateTimeOffset CreatedAt { get; set; }
}