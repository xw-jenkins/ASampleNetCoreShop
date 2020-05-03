using ASample.NetCore.Domain.Message;

namespace ASample.NetCore.Identity.Api.Messages
{
    public class SignInCommand
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
