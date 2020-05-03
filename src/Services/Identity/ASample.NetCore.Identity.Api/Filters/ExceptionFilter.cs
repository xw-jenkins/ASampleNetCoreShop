using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASample.NetCore.Identity.Api.Filters
{
    public class ExceptionFilter :  IExceptionFilter
    {
        #region 请求的action发生异常时会执行此方法
        /// <summary>
        /// 请求的action发生异常时会执行此方法
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnException(ExceptionContext context)
        {
            //在这里你可以记录发生异常时你要干什么，比例写日志
            var message = context.Exception.Message;


            //返回的结果给客户端
            //context.Result = new ContentResult()
            //{
            //    Content = message,
            //    ContentEncoding = System.Text.Encoding.UTF8
            //};


            //context.ExceptionHandled = true;  //告诉系统，这个异常已经处理了，不用再处理

            //filterContext.ExceptionHandled = false;  //告诉系统，这个异常没有处理，需要再处理 
        }
        #endregion


    }
}
