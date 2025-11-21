using Domain.Frameworks.Abstracts;

namespace Domain.Frameworks.Bases;

public class BaseEntity : IEntity , IGuid
{
    public int Id { get; set; }
    public Guid UUId { get; set; }
}
