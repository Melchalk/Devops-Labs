using HomeworkApp.Dal.Models;

namespace HomeworkApp.Dal.Repositories.Interfaces;

public interface IUserRepository
{
    Task<long> Add(DbPerson person, CancellationToken token);
}
