using System;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using NLog;
using NLog.Config;

namespace Core.Utility.LogHelper
{
    public static class NLogUtil
    {
        public static Logger dbLogger = LogManager.GetLogger("logdb");
        public static Logger fileLogger = LogManager.GetLogger("logfile");
        /// <summary>
        /// 保存到数据库
        /// </summary>
        /// <param name="logLevel">日志级别</param>
        /// <param name="KeyId">相关主键</param>
        /// <param name="httpStatusCode">状态</param>
        /// <param name="logType">类型</param>
        /// <param name="InMessage">入参</param>
        /// <param name="OutMessage">出参</param>
        /// <param name="exception">异常</param>
        public static void WriteDBLog(LogLevel logLevel,Guid KeyId, HttpStatusCode httpStatusCode, LogType logType, string InMessage,string OutMessage, Exception exception = null)
        {
            LogEventInfo theEvent = new LogEventInfo(logLevel, dbLogger.Name, InMessage);
            theEvent.Properties["LogType"] = logType.ToString();
            theEvent.Properties["KeyID"] = KeyId;
            theEvent.Properties["InMessage"] = InMessage;
            theEvent.Properties["OutMessage"] = OutMessage;
            theEvent.Properties["Status"] = ((int)httpStatusCode).ToString();
            theEvent.Exception = exception;
            dbLogger.Log(theEvent);
        }

        /// <summary>
        /// 写日志到文件
        /// </summary>
        /// <param name="logLevel">日志等级</param>
        /// <param name="logType">日志类型</param>
        /// <param name="message">信息</param>
        /// <param name="exception">异常</param>
        public static void WriteFileLog(LogLevel logLevel, LogType logType, string message, Exception exception = null)
        {
            LogEventInfo theEvent = new LogEventInfo(logLevel, fileLogger.Name, message);
            theEvent.Properties["LogType"] = logType.ToString();
            theEvent.Exception = exception;
            fileLogger.Log(theEvent);
        }

        /// <summary>
        /// 确保NLog配置文件sql连接字符串正确
        /// </summary>
        /// <param name="nlogPath"></param>
        /// <param name="sqlConnectionStr"></param>
        public static void EnsureNlogConfig(string nlogPath, string sqlConnectionStr)
        {
            XDocument xd = XDocument.Load(nlogPath);
            if (xd.Root.Elements().FirstOrDefault(a => a.Name.LocalName == "targets")
                is XElement targetsNode && targetsNode != null &&
                targetsNode.Elements().FirstOrDefault(a => a.Name.LocalName == "target" && a.Attribute("name").Value == "log_database")
                is XElement targetNode && targetNode != null)
            {
                if (!targetNode.Attribute("connectionString").Value.Equals(sqlConnectionStr))//不一致则修改
                {
                    //这里暂时没有考虑dbProvider的变动
                    targetNode.Attribute("connectionString").Value = sqlConnectionStr;
                    xd.Save(nlogPath);
                    //编辑后重新载入配置文件（不依靠NLog自己的autoReload，有延迟）
                    LogManager.Configuration = new XmlLoggingConfiguration(nlogPath);
                }
            }
        }
    }

}
