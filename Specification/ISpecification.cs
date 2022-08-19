namespace JsonParser.Specification
{

    // We can create a specification class for each type of object we want to validate
    public interface ISpecification<T>
    {
         Task<bool> IsSatisfiedBy(T obj);
    }
}