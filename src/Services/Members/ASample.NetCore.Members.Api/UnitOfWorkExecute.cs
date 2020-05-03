using ASample.NetCore.EntityFramwork;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASample.NetCore.Members.Api
{
    public class UnitOfWorkExecute : IActionFilter
    {
        private IUnitOfWork<MemberApiContext> _unitOfWork;
        public UnitOfWorkExecute(IUnitOfWork<MemberApiContext> unitOfWork)
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
