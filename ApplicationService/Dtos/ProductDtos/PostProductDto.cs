namespace ApplicationService.Dtos.ProductDtos;

public class PostProductDto
{
    public Guid UUId { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
    public long Code { get; set; }
}
