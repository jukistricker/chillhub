namespace chillhub.Entities
{
    public interface IAuditEntity
    {
        DateTimeOffset CreatedAt { get; set; }
        DateTimeOffset UpdatedAt { get; set; }
    }
    
    public abstract class BaseEntity<T> : IAuditEntity
    {
        public T Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; } 
        public T? CreatedBy { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public T? UpdatedBy { get; set; }
    }
    
    public abstract class BaseEntity : IAuditEntity
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
