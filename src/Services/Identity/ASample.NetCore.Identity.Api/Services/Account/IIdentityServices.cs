using ASample.NetCore.Authentications;
using ASample.NetCore.Identity.Api.Domain;
using ASample.NetCore.Identity.Api.Dtos;
using System;
using System.Threading.Tasks;

namespace ASample.NetCore.Identity.Api.Services
{
    public interface IIdentityServices
    {
        Task SignUpAsync(string email, string phone, string userName, string password, UserType? userType = null, PlatformType? platformType = null);

        Task<JsonWebToken> SignInAsync(string userName, string password, UserType? userType);
        Task<User> LoginAsync(string userName, string password, UserType? userType);
        Task SignOutAsync();

        Task ChangPassword(Guid userId, string currentPassword, string newPassword);

        Task<UserDto> GetAsync(Guid userId);
    }
}
