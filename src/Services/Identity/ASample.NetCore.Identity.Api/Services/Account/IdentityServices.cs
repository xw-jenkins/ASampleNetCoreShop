using ASample.NetCore.Authentications;
using ASample.NetCore.Extension;
using ASample.NetCore.Identity.Api.Domain;
using ASample.NetCore.Identity.Api.Dtos;
using ASample.NetCore.Identity.Api.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ASample.NetCore.Identity.Api.Services
{
    public class IdentityServices: IIdentityServices
    {
        private readonly UserManager<User> _userManager; 
        private SignInManager<User> _signInManager;
        private readonly IPasswordHasher<User> _passwordHasher; 
        private readonly IJwtHandler _jwtHandler;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        public IdentityServices(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IJwtHandler jwtHandler,
            IRefreshTokenRepository refreshTokenRepository,
            IPasswordHasher<User> passwordHasher)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtHandler = jwtHandler;
            _refreshTokenRepository = refreshTokenRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task SignUpAsync(string email, string phone,string userName, string password, UserType? userType,PlatformType? platformType)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                throw new ASampleException($"UserName: '{userName}' is already in use.");
            }
            if (userType == null)
            {
                userType = UserType.Member;
            }
            if (platformType == null)
            {
                platformType = PlatformType.UnKnow;
            }

            user = new User(email,phone,userName,UserType.Member,PlatformType.UnKnow);
            user.SetPassword(password, _passwordHasher);
            await _userManager.CreateAsync(user);
            //await _busPublisher.PublishAsync(new SignedUp(id, email, role), CorrelationContext.Empty);
        }

        public async Task<JsonWebToken> SignInAsync(string userName,string password , UserType? userType)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null || !user.ValidatePassword(password, _passwordHasher))
            {
                throw new Exception("Invalid credentials.");
            }
            //user.LastLoginTime = 
            await _signInManager.SignInAsync(user, false);
            var refreshToken = new RefreshToken(user, _passwordHasher);
            var claims = await _userManager.GetClaimsAsync(user);
            var jwt = _jwtHandler.CreateToken(user.Id.ToString(), userType.ToString(), claims.ToDictionary(c => c.Type,c => c.Value));
            jwt.RefreshToken = refreshToken.Token;
            await _refreshTokenRepository.AddAsync(refreshToken);
            return jwt;
        }

        public async Task<User> LoginAsync(string userName, string password, UserType? userType)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null || !user.ValidatePassword(password, _passwordHasher))
            {
                throw new ASampleException("Invalid credentials.");
            }
            return user;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task ChangPassword(Guid userId,string currentPassword,string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if(user == null)
            {
                throw new ASampleException($"User with id: '{userId}' was not found.");
            }
            if (!user.ValidatePassword(currentPassword, _passwordHasher))
            {
                throw new ASampleException("Invalid current password.");
            }
            user.SetPassword(newPassword, _passwordHasher);
            await _userManager.UpdateAsync(user);
        }

        public async Task<UserDto> GetAsync(Guid userId)
        {
            var accountUser = await  _userManager.FindByIdAsync(userId.ToString());
            if (accountUser == null)
                return null;
            var result = accountUser.EntityMap<User, UserDto>();
            return result;
        }
    }
}
