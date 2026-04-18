using NLog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Core.Utility.LogHelper
{
    public class WriteLog : IWriteLog
    {
        public void WriteDBLog(LogLevel logLevel, HttpStatusCode httpStatusCode, LogType logType, string InMessage, string OutMessage, string KeyId = "", Exception exception = null)
        {
            WriteDb(logLevel, KeyId, httpStatusCode, logType, InMessage, OutMessage, exception);
        }

        public void WriteFileLog(LogLevel logLevel, LogType logType, string message, Exception exception = null)
        {
            WriteFile(logLevel, logType, message, exception);
        }

        public void WriteDbDebug(HttpStatusCode httpStatusCode, string InMessage, string OutMessage, string KeyId = "", Exception exception = null, LogType logType = LogType.Api)
        {
            WriteDb(LogLevel.Debug, KeyId, httpStatusCode, logType, InMessage, OutMessage,exception);
        }

        public void WriteDbError(HttpStatusCode httpStatusCode, string InMessage, string OutMessage, string KeyId = "", Exception exception = null, LogType logType = LogType.Api)
        {
            WriteDb(LogLevel.Error, KeyId, httpStatusCode, logType, InMessage, OutMessage, exception);
        }

        public void WriteDbFatal(HttpStatusCode httpStatusCode,string InMessage, string OutMessage, string KeyId = "", Exception exception = null, LogType logType = LogType.Api)
        {
            WriteDb(LogLevel.Fatal, KeyId, httpStatusCode, logType, InMessage, OutMessage, exception);
        }

        public void WriteDbInfo(HttpStatusCode httpStatusCode, string InMessage, string OutMessage, string KeyId = "", Exception exception = null, LogType logType = LogType.Api)
        {
            WriteDb(LogLevel.Info, KeyId, httpStatusCode, logType, InMessage, OutMessage, exception);
        }    

        public void WriteDbOff(HttpStatusCode httpStatusCode,string InMessage, string OutMessage, string KeyId = "", Exception exception = null, LogType logType = LogType.Api)
        {
            WriteDb(LogLevel.Off, KeyId, httpStatusCode, logType, InMessage, OutMessage, exception);
        }

        public void WriteDbTrace(HttpStatusCode httpStatusCode, string InMessage, string OutMessage, string KeyId = "", Exception exception = null, LogType logType = LogType.Api)
        {
            WriteDb(LogLevel.Trace, KeyId, httpStatusCode, logType, InMessage, OutMessage, exception);
        }

        public void WriteDbWarn(HttpStatusCode httpStatusCode, string InMessage, string OutMessage, string KeyId = "", Exception exception = null, LogType logType = LogType.Api)
        {
            WriteDb(LogLevel.Warn, KeyId, httpStatusCode, logType, InMessage, OutMessage, exception);
        }

        public void WriteFileDebug(string message, Exception exception = null, LogType logType = LogType.Web)
        {
            WriteFile(LogLevel.Debug, logType, message, exception);
        }

        public void WriteFileError(string message, Exception exception = null, LogType logType = LogType.Web)
        {
            WriteFile(LogLevel.Error, logType, message, exception);
        }

        public void WriteFileFatal(string message, Exception exception = null, LogType logType = LogType.Web)
        {
            WriteFile(LogLevel.Fatal, logType, message, exception);
        }

        public void WriteFileInfo(string message, Exception exception = null, LogType logType = LogType.Web)
        {
            WriteFile(LogLevel.Info, logType, message, exception);
        }

        public void WriteFileOff(string message, Exception exception = null, LogType logType = LogType.Web)
        {
            WriteFile(LogLevel.Off, logType, message, exception);
        }

        public void WriteFileTrace(string message, Exception exception = null, LogType logType = LogType.Web)
        {
            WriteFile(LogLevel.Trace, logType, message, exception);
        }

        public void WriteFileWarn(string message, Exception exception = null, LogType logType = LogType.Web)
        {
            WriteFile(LogLevel.Warn, logType, message, exception);
        }


        private void WriteDb(LogLevel logLevel, string KeyId, HttpStatusCode httpStatusCode, LogType logType, string InMessage, string OutMessage, Exception exception = null)
        {
            ILogger dbLogger = LoggerInstance.CreateDbLogInstance();
            LogEventInfo theEvent = new LogEventInfo(logLevel, dbLogger.Name, InMessage);
            theEvent.Properties["LogType"] = logType.ToString();
            theEvent.Properties["KeyID"] = KeyId;
            theEvent.Properties["InMessage"] = InMessage;
            theEvent.Properties["OutMessage"] = OutMessage;
            theEvent.Properties["Status"] = ((int)httpStatusCode).ToString();
            theEvent.Exception = exception;
            dbLogger.Log(theEvent);
        }

        private void WriteFile(LogLevel logLevel, LogType logType, string message, Exception exception = null)
        {
            ILogger fileLogger = LoggerInstance.CreateFileLogInstance();
            LogEventInfo theEvent = new LogEventInfo(logLevel, fileLogger.Name, message);
            theEvent.Properties["LogType"] = logType.ToString();
            theEvent.Exception = exception;
            fileLogger.Log(theEvent);
        }
    }
}
