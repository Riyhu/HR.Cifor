namespace HR.Cifor.WebApi.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public Guid? CreatedById { get; set; }
    public DateTime? DateCreated { get; set; }
    public Guid? UpdatedById { get; set; }
    public DateTime? DateUpdated { get; set; }
    public Guid? DeletedById { get; set; }
    public DateTime? DateDeleted { get; set; }
}
