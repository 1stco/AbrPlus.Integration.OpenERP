using System.ComponentModel;

namespace AbrPlus.Integration.OpenERP.Enums
{
    /// <summary>
    /// <para>The main <c>ReportMessageType</c> enum.</para>
    /// <para>Determines the types of messages to display to the user</para>
    /// </summary>
    public enum ReportMessageType : short
    {
        /// <summary>
        /// Indicates information about what the user wants to do. for example:
        /// <c>Report.SaveMessage("مشتری در پیامگستر حذف شده است.", ReportMessageType.Information);</c>
        /// </summary>
        [Description("اطلاع")]
        Information = 1,

        /// <summary>
        /// Displays when something the user has done is wrong or the system has a problem. for example:
        /// <c>Report.SaveMessage(string.Format("محصول '{0}' در سیستم پیامگستر فاقد کد کالا می باشد.", r.ProductName), ReportMessageType.Error);</c>
        /// </summary>
        [Description("خطا")]
        Error = 2,

        /// <summary>
        /// Changes the message type to alert. for example:
        /// <c>Report.SaveMessage(string.Format("Service Message[شناسه  کالا {0} یافت نشد.]", key), ReportMessageType.Warnning);</c>
        /// </summary>
        [Description("هشدار")]
        Warnning = 3
    }
}
