namespace HomeworkApp.Dal.Settings;

public record DalOptions
{
    public required string ConnectionString { get; init; } = string.Empty;
}