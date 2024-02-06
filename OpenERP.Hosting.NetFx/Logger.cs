using Serilog;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace AbrPlus.Integration.OpenERP.Hosting.NetFx
{
    public class Logger
    {
        /// <summary>
        /// Gets <paramref name="data"/> and And if it is not empty. Sends it to the SerializeObject function.
        /// </summary>
        /// <remarks>
        /// If <paramref name="data"/> is null, The message of <c>SerializeObject</c> will replaces with "Passed data is null".
        /// </remarks>
        /// <param name="data"></param>
        /// ///<see cref="CustomLog(string, EventLogType)"/>
        /// <seealso cref="EventLogType"/>
        public static void DataLog(object data)
        {
            try
            {
                if (data == null)
                {
                    CustomLog("Passed data is null", EventLogType.Error);
                }
                else
                {
                    CustomLog(SerializeObject(data), EventLogType.Error);
                }
            }
            catch (Exception ex) { }
        }
        /// <summary>
        /// Serializes <paramref name="obj"/> to string.
        /// </summary>
        /// <remarks>
        /// If <paramref name="obj"/> is null, Returns null.
        /// </remarks>
        /// <param name="obj"></param>
        /// <returns>Xml as string</returns>
        private static string SerializeObject(object obj)
        {
            if (obj == null)
                return null;
            XmlSerializer xsSubmit = new XmlSerializer(obj.GetType());
            var subReq = obj;
            var xml = string.Empty;

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, subReq);
                    xml = sww.ToString();
                    return xml;
                }
            }
        }

        /// <summary>
        /// Create custom exception error message
        /// </summary>
        /// <param name="ex">exeption</param>
        /// <param name="message">Uses message for generate error message. Defualt value of <paramref name="message"/> is "". </param>
        public static void ExceptionLog(Exception ex, string message = "")
        {
            Log.Error(ex, $"Message: {message} | Error: {ex.ToString()}");
        }

        /// <summary>
        /// Build Log message according to EventLogType.
        /// </summary>
        /// <param name="devMessage">Return of SerializeObject method</param>
        /// <param name="logType">EventLogType.Error</param>
        /// <see cref="SerializeObject(object)"/>
        /// <seealso cref="EventLogType"/>
        public static void CustomLog(string devMessage, EventLogType logType)
        {
            try
            {
                StackTrace stackTrace = new StackTrace();
                MethodBase methodBase = stackTrace.GetFrame(1).GetMethod();
                var message = $"{methodBase} message: {devMessage}";
                //     var log = new LoggerConfiguration()
                // .WriteTo.LiterateConsole()
                // .WriteTo.RollingFile(@"C:\ProgramData\Arsina\PgIntegration\Log\l.txt")
                // .CreateLogger();
                //      log.Information(message);


                switch (logType)
                {
                    case EventLogType.Error:
                        Log.Error(message);
                        break;
                    case EventLogType.Warning:
                        Log.Warning(message);
                        break;
                    case EventLogType.Information:
                        Log.Information(message);
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.Error("error in logger.customLog");
            }
        }
    }

    /// <summary>
    /// The main <c>EventLogType</c> enum.
    /// contains Error, Warning and Information.
    /// </summary>
    public enum EventLogType
    {
        Error = 1,
        Warning = 2,
        Information = 4,
    }
}
