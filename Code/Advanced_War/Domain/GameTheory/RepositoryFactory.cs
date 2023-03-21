using Advanced_War.Domain.GameTheory.Interfaces;

namespace Advanced_War.Domain.GameTheory;

public class RepositoryFactory
{
    /// <summary>
    /// This will create a concrete implementation of a SQL repository or an JSON repository
    /// </summary>
    /// <param name="providedDataSource">This is either a SQL connectionstring or a filepath the the JSON file</param>
    /// <returns>IPlayerRepository</returns>
    public IPlayerRepository CreateRepository(string providedDataSource)
    {
        if (IsJsonFilePath(providedDataSource))
        {
            return new SqlPlayerRepository(providedDataSource);
        }
        else
        {
            return new SqlPlayerRepository(providedDataSource);
        }
    }

    private bool IsJsonFilePath(string path)
    {
        // Implement logic to determine if the given path is a JSON file path
        // For example, check if the path ends with ".json"
        return path.EndsWith(".json", StringComparison.OrdinalIgnoreCase);
    }
}