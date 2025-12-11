namespace ApplicationService.Dtos.ProductDtos;

public class SingleProductDto
{
    public int Id { get; set; }
    public Guid UUId { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
    public long Code { get; set; }
}
