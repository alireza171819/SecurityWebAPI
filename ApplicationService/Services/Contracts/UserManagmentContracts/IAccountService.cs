using ApplicationService.Dtos.UserManagmentDtos.AccountDtos;
using Microsoft.AspNetCore.Http;
using ResponseFramework;

namespace ApplicationService.Services.Contracts.UserManagmentContracts;

public interface IAccountService
{
    Task<IResponse<SignInResultDto>> SignIn(SignInDto dto);

    Task<IResponse<object>> SignOut(HttpContext httpContext);
}
