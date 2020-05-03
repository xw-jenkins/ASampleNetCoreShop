using ASample.NetCore.EntityFramwork;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASample.NetCore.Identity.Api
{
    public class UnitOfWorkExecute : IActionFilter
    {
        private IUnitOfWork<IdentityApiContext> _unitOfWork;
        public UnitOfWorkExecute(IUnitOfWork<IdentityApiContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _unitOfWork.SaveChanges();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
