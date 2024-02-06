using Microsoft.Extensions.Configuration;
using SeptaKit.Extensions;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace AbrPlus.Integration.OpenERP.Hosting.NetFx
{
    public class SerilogHelper
    {
        public const string DefaultLogTemplate = "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}";

        public static LoggerConfiguration DefaultLoggerConfiguration(string logPath = null, string outputTemplate = DefaultLogTemplate, LogEventLevel logLevel = LogEventLevel.Debug)
        {
            var toReturn = new LoggerConfiguration().Enrich.FromLogContext()
                                                    .MinimumLevel.Is(logLevel)
                                                    .WriteTo.Console(outputTemplate: outputTemplate, theme: AnsiConsoleTheme.Literate);

            if (logPath.HasValue())
            {
                toReturn.WriteTo.File(logPath, rollingInterval: RollingInterval.Day);
            }

            return toReturn;
        }

        public static LoggerConfiguration LogFromConfiguration(IConfiguration configuration)
        {
            var loggerConfiguration = new LoggerConfiguration();
            loggerConfiguration.ReadFrom.Configuration(configuration);
            return loggerConfiguration;
        }
    }
}