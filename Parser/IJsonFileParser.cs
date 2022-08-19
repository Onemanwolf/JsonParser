namespace JsonParser.Parser
{
    public interface IJsonFileParser<T>
    {
        Task<T> ParseFile(string path);
    }
}