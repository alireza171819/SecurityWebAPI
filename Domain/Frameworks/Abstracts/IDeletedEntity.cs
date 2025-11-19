
namespace Domain.Frameworks.Abstracts;

public interface IDeletedEntity
{
    bool IsDeleted { get; set; }
    DateTime GregorianDateDeleted { get; set; }
}
