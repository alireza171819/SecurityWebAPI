using ApplicationService.Dtos.UserManagmentDtos.UserDtos;
using ResponseFramework;

namespace ApplicationService.Services.Contracts.UserManagmentContracts;

public interface IUserService
{
    Task<IResponse<bool>> Post(PostUserDto postUserDto);
    Task<IResponse<bool>> Put(PutUserDto postUserDto);
    Task<IResponse<bool>> Delete(DeleteUserDto postUserDto);
    Task<IResponse<ListUserDtos>> GetAll();
    Task<IResponse<SingleUserDto>> GetById(GetByIdUserDto getByIdUserDto);
}
