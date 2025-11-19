using Domain.Frameworks.Abstracts;

namespace Domain.Frameworks.Bases;

public class BaseEntity : IEntity
{
    public int Id { get; set; }
}
