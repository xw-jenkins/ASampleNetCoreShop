﻿using ASample.NetCore.Identity.Api.Domain;
using ASample.NetCore.RelationalDb;

namespace ASample.NetCore.Identity.Api.Repositories
{
    public interface IUserRepository:IRepository<User>
    {
    }
}
