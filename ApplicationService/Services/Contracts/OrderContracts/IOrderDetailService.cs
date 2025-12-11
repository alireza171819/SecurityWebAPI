using ApplicationService.Dtos.OrderDetailDtos;
using ResponseFramework;

namespace ApplicationService.Services.Contracts.OrderContracts;

public interface IOrderDetailService
{
    Task<IResponse<bool>> Post(PostOrderDetailDto dto);

    Task<IResponse<bool>> Put(PutOrderDetailDto dto);

    Task<IResponse<bool>> Delete(DeleteOrderDetailDto dto);

    Task<IResponse<ListOrderDetailDto>> GetAll();

    Task<IResponse<GetByIdOrderDetailDto>> GetById(GetByIdOrderDetailDto dto);
}
