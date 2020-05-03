using ASample.NetCore.EntityFramwork;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASample.NetCore.Subjects.Api
{
    public class UnitOfWorkExecute : IActionFilter
    {
        private IUnitOfWork<SubjectApiContext> _unitOfWork;
        public UnitOfWorkExecute(IUnitOfWork<SubjectApiContext> unitOfWork)
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
