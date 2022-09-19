namespace SwimmingTool.Domain
{
    public abstract class Entity<T> where T : notnull
    {
        public T Id { get; internal set; }
    }
}
