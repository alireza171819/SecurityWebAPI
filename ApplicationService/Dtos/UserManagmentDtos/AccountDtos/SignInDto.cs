using System.ComponentModel.DataAnnotations;

namespace ApplicationService.Dtos.UserManagmentDtos.AccountDtos;

public class SignInDto
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }

    public bool RememberMe { get; set; }
}
