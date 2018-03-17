using System;
using System.Net;
using System.Text;
using System.Web.Mvc;

namespace Lib.Mvc.HelperExt
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// 顯示現在的Controller與Action
        /// </summary>
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
        public static bool IsCurrentAction(this HtmlHelper helper, string actionName, string controllerName)
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

        /// <summary>
        /// Base Dropdownlist
        /// </summary>
        public static MvcHtmlString CreateDropdownList(this HtmlHelper obj, string name, string[] options)
        {
            var dropdown = new TagBuilder("select");
            dropdown.Attributes.Add("name", name);

            StringBuilder option = new StringBuilder();
            if (option != null)
            {
                foreach (string v in options)
                {
                    option = option.Append("<option value='" + v + "'>" + v + "</option>");
                }
            }
            dropdown.InnerHtml = option.ToString();
            return MvcHtmlString.Create(dropdown.ToString(TagRenderMode.Normal));
        }

        //Check resource exists
        public static bool RemoteFileExists(this HtmlHelper helper, string remoteUrl)
        {
            try
            {
                //Reqeust
                HttpWebRequest request = HttpWebRequest.Create(remoteUrl) as HttpWebRequest;
                request.Method = "POST";

                //Response
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                //200
                return response.StatusCode.Equals(HttpStatusCode.OK);
            }
            catch
            {
                return false;
            }
        }
    }
}