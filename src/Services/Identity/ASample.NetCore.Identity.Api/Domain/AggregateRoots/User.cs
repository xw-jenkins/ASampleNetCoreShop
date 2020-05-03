using ASample.NetCore.Domain;
using ASample.NetCore.Extension;
using Microsoft.AspNetCore.Identity;
using System;

namespace ASample.NetCore.Identity.Api.Domain
{
    /// <summary>
    /// 系统用户
    /// </summary>
    public class User : IdentityUser<Guid>,IAggregateRoot
    {
        public Guid? MsId { get; set; }
        /// <summary>
        /// 上一次登录时间
        /// </summary>
        public DateTime? LastLoginTime { get; set; }

        /// <summary>
        /// 上一次登录Ip
        /// </summary>
        public string LastLoginIp { get; set; }

        /// <summary>
        /// 登录次数
        /// </summary>
        public int LoginTimes { get; set; }

        public UserType UserType { get; set; }
        public string UserAvatar { get; set; }
        public bool UserStatus { get; set; }

        public PlatformType UserSource {get;set;}

        public DateTime CreateTime { get; set; } 
        public DateTime? DeleteTime { get; set; }
        public DateTime? ModifyTime { get; set; }
        public bool IsDeleted { get; set; }

        public User()
        {

        }

        public User(string email, string phone, string userName, UserType? userType, PlatformType? platformType)
        {
            //if (!email.EmailRegex())
            //{
            //    throw new ASampleException($"Invalid email: '{email}'.");
            //}
            //if (!phone.PhoneRegex())
            //{
            //    throw new ASampleException($"Invalid phone: '{email}'.");
            //}

            if (userName.IsNullOrEmpty())
            {
                throw new ASampleException($"UserName can not empty: '{email}'.");
            }

            Email = email.IsNullOrEmpty()?"":email.ToLowerInvariant();
            PhoneNumber = phone;
            UserName = userName;
            UserType = userType == null ? UserType.MSUser : userType.Value;
            UserSource = platformType == null ? PlatformType.UnKnow : platformType.Value;
            CreateTime = DateTime.Now;
        }

        public void SetPassword(string password, IPasswordHasher<User> passwordHasher)
        {
            if (password.IsNullOrEmpty())
            {
                throw new ASampleException("Password can not be empty.");
            }
            PasswordHash = passwordHasher.HashPassword(this, password);
        }

        public bool ValidatePassword(string password, IPasswordHasher<User> passwordHasher)
            => passwordHasher.VerifyHashedPassword(this, PasswordHash, password) != PasswordVerificationResult.Failed;
    }
}
