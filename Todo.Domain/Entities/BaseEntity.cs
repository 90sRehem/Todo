namespace Todo.Domain.Entities
{
    public abstract class BaseEntity : IEquatable<BaseEntity>
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public bool Equals(BaseEntity? other)
        {
            return Id == other?.Id;
        }
    }
}