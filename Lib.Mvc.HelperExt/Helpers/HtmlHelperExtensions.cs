using System;
using System.Web.Mvc;

namespace Lib.Mvc.HelperExt.Helpers
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// 顯示現在的Controller與Action
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static string ShowControllerAndActionName(this HtmlHelper helper)
        {
            var currentControllerName =
                (string)helper.ViewContext.RouteData.Values["controller"];

            var currentActionName =
                (string)helper.ViewContext.RouteData.Values["action"];

            return string.Format(
                "<h3>現在的Controller為【{0}】Action為【{1}】</h3>",
                currentControllerName,
                currentActionName);
        }

        /// <summary>
        /// 確認是否為指定的Controller與Action
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="actionName"></param>
        /// <param name="controllerName"></param>
        /// <returns></returns>
        public static bool IsCurrentAction(this HtmlHelper helper,
           string actionName,
           string controllerName)
        {
            var currentControllerName =
                (string)helper.ViewContext.RouteData.Values["controller"];

            var currentActionName =
                (string)helper.ViewContext.RouteData.Values["action"];

            if (currentControllerName.Equals(controllerName, StringComparison.CurrentCultureIgnoreCase)
                &&
                currentActionName.Equals(actionName, StringComparison.CurrentCultureIgnoreCase))
            {
                return true;
            }
            return false;
        }
    }
}