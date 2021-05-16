```xml
<?xml version="1.0" encoding="utf-8"?>
<nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd"
      xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <!--具体配置可参考官方示例：https://github.com/jkowalski/NLog/tree/master/examples/targets/Configuration%20File -->
  <targets async="true">
    <!--将日志输出到控制台-->
    <target name="console" type="Console" 
            layout="${longdate}|${callsite}|${uppercase:${level}}|${message}"/>
    <!--将日志输出到文件-->
    <target name="file" xsi:type="File"
            fileName="${basedir}/App_Data/Logs/${shortdate}/${level}.log"
            layout=" 发生时间：${longdate}${newline}
日志级别：${uppercase:${level}}${newline}
操作账号：${event-context:item=Account}${newline}
操作者IP：${event-context:item=IP}${newline}
IP归属地：${event-context:item=IPAddress}${newline}
浏 览 器：${event-context:item=Browser}${newline}
操作模块：${event-context:item=Operation}${newline}
提示信息：${message}${newline}"/>
    <!--将日志输出到邮箱-->
    <target name="mail" xsi:type="Mail"
            smtpServer="smtp.163.com"
            smtpPort="25"
            smtpAuthentication="Basic"
            smtpUserName="elight_mvc"
            smtpPassword="gaoyang1112"
            enableSsl="true"
            addNewLines="true"
            from="elight_mvc@163.com"
            to="973095739@qq.com"
            subject="[Elight.MVC]系统日志报告"
            body=" 发生时间：${longdate}${newline}
日志级别：${uppercase:${level}}${newline}
操作用户：${event-context:item=Account}${newline}
操作者IP：${event-context:item=IP}${newline}
IP归属地：${event-context:item=IPAddress}${newline}
浏 览 器：${event-context:item=Browser}${newline}
操作模块：${event-context:item=Operation}${newline}
提示信息：${message}${newline}" />
    <!--将日志输出到数据库-->
    <target name="database" type="Database" 
            connectionstring="Data Source=.\SQLEXPRESS;Initial Catalog=Elight_v1.0;User ID=sa;Password=sql2014">
      <commandText>
        insert into Sys_Log(CreateTime, LogLevel, Message, StackTrace, Id, Account, RealName, Operation, IP, IPAddress, Browser)
        values(@CreateTime, @LogLevel, @Message, @StackTrace, @Id, @Account, @RealName, @Operation, @IP, @IPAddress, @Browser);
      </commandText>
      <parameter name="@LogLevel" layout="${uppercase:${level}}" />
      <parameter name="@Message" layout="${message}" />
      <parameter name="@StackTrace" layout="${stacktrace}" />
      <parameter name="@CreateTime" layout="${date}" />
      <parameter name="@Id" layout="${event-context:item=Id}" />
      <parameter name="@Account" layout="${event-context:item=Account}" />
      <parameter name="@RealName" layout="${event-context:item=RealName}" />
      <parameter name="@Operation" layout="${event-context:item=Operation}" />
      <parameter name="@IP" layout="${event-context:item=IP}" />
      <parameter name="@IPAddress" layout="${event-context:item=IPAddress}" />
      <parameter name="@Browser" layout="${event-context:item=Browser}" />
    </target>
  </targets>
  <rules>
    <!--<logger name="*" levels="Error,Fatal" writeTo="mail" />-->
    <logger name="*" level="Error" writeTo="file" />
    <logger name="*" level="Info" writeTo="database" />
    <logger name="*" level="Debug" writeTo="console" />
  </rules>
  <!--
  name - 日志源/记录者的名字 (允许使用通配符*)
  minlevel - 该规则所匹配日志范围的最低级别
  maxlevel - 该规则所匹配日志范围的最高级别
  level - 该规则所匹配的单一日志级别
  levels - 该规则所匹配的一系列日志级别，由逗号分隔。
  writeTo - 规则匹配时日志应该被写入的一系列目标，由逗号分隔。
  final - 标记当前规则为最后一个规则。其后的规则即时匹配也不会被运行。
  -->
</nlog>
```

```c#
    /// <summary>
    /// NLog日志框架辅助类。
    /// </summary>
    public static class LogHelper
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 注册日志配置文件。
        /// </summary>
        public static void RegisterConfig()
        {
            string configPath = AppDomain.CurrentDomain.BaseDirectory + @"\Configs\NLog.config";
            LogManager.Configuration = new XmlLoggingConfiguration(configPath);
        }

        /// <summary>
        /// 记录日志。
        /// </summary>
        /// <param name="level">日志级别</param>
        /// <param name="operation">动作</param>
        /// <param name="message">消息</param>
        /// <param name="account">操作者</param>
        /// <param name="realName">真实姓名</param>
        public static void Write(LogLevel level, string operation, string message, string account, string realName)
        {

            logger.Log(LogEventInfoInstance(message, level, account, realName, operation));
        }

        /// <summary>
        /// 最常见的记录信息，一般用于普通输出。
        /// </summary>
        /// <param name="message"></param>
        public static void Trace(string message)
        {
            logger.Trace(message);
        }

        /// <summary>
        /// 同样是记录信息，不过出现的频率要比Trace少一些，一般用来调试程序。
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(string message)
        {
            logger.Debug(message);
        }

        /// <summary>
        /// 信息类型的消息。
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            logger.Info(message);
        }

        /// <summary>
        /// 警告信息，一般用于比较重要的场合。
        /// </summary>
        /// <param name="message"></param>
        public static void Warn(string message)
        {
            logger.Warn(message);
        }

        /// <summary>
        /// 错误信息。
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            logger.Error(message);
        }

        /// <summary>
        /// 致命异常信息。一般来讲，发生致命异常之后程序将无法继续执行。
        /// </summary>
        /// <param name="message"></param>
        public static void Fatal(string message)
        {
            logger.Fatal(message);
        }



        private static LogEventInfo LogEventInfoInstance(string message, LogLevel level,string account,string realName,string operation)
        {
            LogEventInfo logEvent = new LogEventInfo
            {
                Message = message, 
                Level = level
            };
            logEvent.Properties["Id"] = Guid.NewGuid().ToString();
            logEvent.Properties["Account"] = account;
            logEvent.Properties["RealName"] = realName;
            logEvent.Properties["Operation"] = operation;
            logEvent.Properties["IP"] = Net.Ip;
            logEvent.Properties["IPAddress"] = Net.GetAddress(Net.Ip);
            logEvent.Properties["Browser"] = Net.Browser;

            return logEvent;
        }
    }
```

