namespace JsonParser.Specification
{
    public interface ISpecification<T>
    {
         Task<bool> IsSatisfiedBy(T obj);
    }
}