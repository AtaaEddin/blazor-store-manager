namespace OnlineStoresManager.Abstractions
{
    public abstract class CompositeId
    {
        protected const string Separator = "╡";
        public abstract bool IsEmpty { get; }
    }
}
