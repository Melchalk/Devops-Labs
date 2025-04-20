using HomeworkApp.Dal.Models;
using Refit;

namespace HomeworkApp.Dal;

public interface ISecondMicroservice
{
    public const string BaseUri = "http://localhost:8100";

    [Post("/add/person")]
    public Task AddPerson([Body] DbPerson person);
}
