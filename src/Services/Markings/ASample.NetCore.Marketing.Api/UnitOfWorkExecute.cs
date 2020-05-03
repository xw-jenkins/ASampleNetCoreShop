using ASample.NetCore.EntityFramwork;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASample.NetCore.Marketing.Api
{
    public class UnitOfWorkExecute : IActionFilter
    {
        private IUnitOfWork<MarketingApiContext> _unitOfWork;
        public UnitOfWorkExecute(IUnitOfWork<MarketingApiContext> unitOfWork)
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
