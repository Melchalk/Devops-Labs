using Dapper;
using HomeworkApp.Dal.Models;
using HomeworkApp.Dal.Repositories.Interfaces;
using HomeworkApp.Dal.Settings;
using Microsoft.Extensions.Options;

namespace HomeworkApp.Dal.Repositories;

public class UserRepository : PgRepository, IUserRepository
{
    public UserRepository(
        IOptions<DalOptions> dalSettings) : base(dalSettings.Value)
    {
    }

    public async Task<long> Add(DbPerson person, CancellationToken token)
    {
        const string sqlQuery = """
            insert into users (name, age, created_at)
                values(@Name, @Age, @CreatedAt)
            returning id;
            """;

        await using var connection = await GetConnection();
        var id = (await connection.QueryAsync<long>(
            new CommandDefinition(
                sqlQuery,
                new
                {
                    Name = person.Name,
                    Age = person.Age,
                    CreatedAt = person.CreatedAt,
                },
                cancellationToken: token))).Single();

        return id;
    }
}
