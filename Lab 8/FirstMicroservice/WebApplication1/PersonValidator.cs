using HomeworkApp.Dal.Models;

namespace HomeworkApp.Dal;

public static class PersonValidator
{
    public static bool Validate(Person person)
    {
        return person.Age > 0 && person.Name.Length > 0;
    }
}
