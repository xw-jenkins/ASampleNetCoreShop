using ASample.NetCore.EntityFramwork;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASample.NetCore.Order.Api
{
    public class UnitOfWorkExecute : IActionFilter
    {
        private IUnitOfWork<OrderApiContext> _unitOfWork;
        public UnitOfWorkExecute(IUnitOfWork<OrderApiContext> unitOfWork)
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
