using ApplicationService.Dtos.UserManagmentDtos.AccountDtos;
using ApplicationService.Services.Contracts.UserManagmentContracts;
using Domain.Aggregates.UserManagementAggregates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ResponseFramework;
using System.Net;

namespace ApplicationService.Services.UserManagmentServices;

public class AccountService : IAccountService
{

    #region Privet Fields
    private readonly SignInManager<User> _signInManager;
    #endregion

    #region Constructor
    public AccountService(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }
    #endregion
    public async Task<IResponse<SignInResultDto>> SignIn(SignInDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.UserName) || string.IsNullOrWhiteSpace(dto.Password))
            return new Response<SignInResultDto>("Invalid UserName Or Password.");

        await _signInManager.PasswordSignInAsync(dto.UserName, dto.Password, dto.RememberMe, false);
        var authenticatedUser =
            await _signInManager.UserManager.Users.SingleAsync<User>(c => c.UserName == dto.UserName);
        var result = new SignInResultDto()
        {
            UserName = authenticatedUser.UserName!,
            PhoneNumber = authenticatedUser.PhoneNumber!,
            Email = authenticatedUser.Email!
        };
        return new Response<SignInResultDto>(result, true, $"{dto.UserName} is signed in.", string.Empty, HttpStatusCode.OK);
    }

    public async Task<IResponse<object>> SignOut(HttpContext httpContext)
    {
        await _signInManager.SignOutAsync();
        var signOutResult = new SignOutResultDto() { UserName = httpContext.User.Identity!.Name!, };
        return new Response<object>(signOutResult, true, $"{signOutResult.UserName} is signed out.", string.Empty, HttpStatusCode.OK);
    }
}
