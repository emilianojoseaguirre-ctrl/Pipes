namespace Ucu.Poo.PipesAndFilters.Filters
{
    public interface IConditionalFilter : IFilter
    {
        bool Result { get; }
    }
}