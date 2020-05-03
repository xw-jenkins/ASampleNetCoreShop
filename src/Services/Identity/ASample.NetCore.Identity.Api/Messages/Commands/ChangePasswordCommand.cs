using ASample.NetCore.Domain.Message;
using System;

namespace ASample.NetCore.Identity.Api.Messages
{
    public class ChangePasswordCommand:ICommand
    {
        public ChangePasswordCommand(Guid userId, string currentPwd, string newPwd)
        {
            UserId = userId;
            CurrentPwd = currentPwd;
            NewPwd = newPwd;
        }

        public Guid UserId { get; set; }
        public string CurrentPwd { get; set; }
        public string NewPwd { get; set; }
    }
}
