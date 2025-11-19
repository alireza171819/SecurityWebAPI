
namespace Domain.Frameworks.Abstracts;

public interface ICodedEntity<TCode>
{
    TCode Code { get; set; }
}
