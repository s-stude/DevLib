using System;
using System.Web.Mvc;

namespace DevLib.Infrastructure.Web
{
    public static class ViewContextExtensions
    {
        public static bool HasSuccessAlert(this ViewContext viewContext)
        {
            var hasSuccessAlertView = viewContext.TempData.ContainsKey(WebUIAlerts.OnSuccessViewNameTempDataKey);
            return hasSuccessAlertView;
        }

        public static bool HasErrorAlert(this ViewContext viewContext)
        {
            var hasErrorAlertView = viewContext.TempData.ContainsKey(WebUIAlerts.OnFailureViewNameTempDataKey);
            return hasErrorAlertView;
        }

        public static string GetSuccessAlertViewName(this ViewContext viewContext)
        {
            if (!viewContext.TempData.ContainsKey(WebUIAlerts.OnSuccessViewNameTempDataKey))
                throw new InvalidOperationException("TempData does not containt OnSuccessViewNameTempDataKey");

            return viewContext.TempData[WebUIAlerts.OnSuccessViewNameTempDataKey].ToString();
        }

        public static string GetErrorAlertViewName(this ViewContext viewContext)
        {
            if (!viewContext.TempData.ContainsKey(WebUIAlerts.OnFailureViewNameTempDataKey))
                throw new InvalidOperationException("TempData does not containt OnFailureViewNameTempDataKey");
    
            return viewContext.TempData[WebUIAlerts.OnFailureViewNameTempDataKey].ToString();
        }
    }
}