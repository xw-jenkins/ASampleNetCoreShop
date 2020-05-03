using ASample.NetCore.Product.Api;
using ASample.NetCore.EntityFramwork;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASample.NetCore.Product.Api
{
    public class UnitOfWorkExecute : IActionFilter
    {
        private IUnitOfWork<ProductApiContext> _unitOfWork;
        public UnitOfWorkExecute(IUnitOfWork<ProductApiContext> unitOfWork)
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
