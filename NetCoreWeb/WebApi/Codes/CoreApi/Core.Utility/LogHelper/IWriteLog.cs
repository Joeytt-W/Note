using NLog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Core.Utility.LogHelper
{
    public interface IWriteLog
    {
        void WriteDBLog(LogLevel logLevel, HttpStatusCode httpStatusCode, LogType logType, string InMessage, string OutMessage, string KeyId = "", Exception exception = null);

        void WriteFileLog(LogLevel logLevel, LogType logType, string message, Exception exception = null);

        void WriteDbInfo(HttpStatusCode httpStatusCode,string InMessage, string OutMessage, string KeyId = "", Exception exception = null, LogType logType = LogType.Api);

        void WriteDbTrace(HttpStatusCode httpStatusCode, string InMessage, string OutMessage, string KeyId = "", Exception exception = null, LogType logType = LogType.Api);

        void WriteDbDebug(HttpStatusCode httpStatusCode, string InMessage, string OutMessage, string KeyId = "", Exception exception = null, LogType logType = LogType.Api);

        void WriteDbWarn(HttpStatusCode httpStatusCode, string InMessage, string OutMessage, string KeyId = "", Exception exception = null, LogType logType = LogType.Api);

        void WriteDbError(HttpStatusCode httpStatusCode, string InMessage, string OutMessage, string KeyId = "", Exception exception = null, LogType logType = LogType.Api);

        void WriteDbFatal(HttpStatusCode httpStatusCode, string InMessage, string OutMessage, string KeyId = "", Exception exception = null, LogType logType = LogType.Api);

        void WriteDbOff(HttpStatusCode httpStatusCode, string InMessage, string OutMessage, string KeyId = "", Exception exception = null, LogType logType = LogType.Api);

        void WriteFileInfo(string message, Exception exception = null, LogType logType = LogType.Web);

        void WriteFileTrace(string message, Exception exception = null, LogType logType = LogType.Web);

        void WriteFileDebug(string message, Exception exception = null, LogType logType = LogType.Web);

        void WriteFileWarn(string message, Exception exception = null, LogType logType = LogType.Web);

        void WriteFileError(string message, Exception exception = null, LogType logType = LogType.Web);

        void WriteFileFatal(string message, Exception exception = null, LogType logType = LogType.Web);

        void WriteFileOff(string message, Exception exception = null, LogType logType = LogType.Web);
    }
}
