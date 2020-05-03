
namespace ASample.NetCore.Identity.Api.Messages
{
    public class SignUpCommand//:ICommand
    {
        //public SignUpCommand(string userName, string password, string phoneNumber, string email)
        //{
        //    UserName = userName;
        //    Password = password;
        //    PhoneNumber = phoneNumber;
        //    Email = email;
        //}

        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string UserAvatar { get; set; }
        public bool UserStatus { get; set; }

    }
}
