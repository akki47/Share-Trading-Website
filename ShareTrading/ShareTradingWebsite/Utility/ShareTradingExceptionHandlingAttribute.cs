using System.Web.Mvc;
using ExceptionHandlingFramework;

namespace ShareTradingWebsite
{
    /// <summary>
    /// Attribute to handle errors on all the controllers
    /// </summary>
    public class ShareTradingExceptionHandlingAttribute : HandleErrorAttribute
    {
        /// <summary>
        /// Creates a new instance of ShareTradingExceptionHandlingAttribute
        /// </summary>
        public ShareTradingExceptionHandlingAttribute()
            : base()
        {

        }

        /// <summary>
        /// Called when an exception is raised
        /// </summary>
        /// <param name="filterContext">Filter context</param>
        public override void OnException(ExceptionContext filterContext)
        {
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

            filterContext.Result = new ViewResult
            {
                ViewName = View,
                MasterName = Master,
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                TempData = filterContext.Controller.TempData
            };

            // log the error using log4net.
            LoggingManager.Logger.Write(filterContext.Exception.Message, filterContext.Exception.ToString());

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;
        }
    }
}