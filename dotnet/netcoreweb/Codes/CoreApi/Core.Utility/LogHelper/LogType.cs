using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Core.Utility
{
    public enum LogType
    {
        [Description("网站")]
        Web,
        [Description("数据库")]
        DataBase,
        [Description("Api接口")]
        Api,
        [Description("中间件")]
        Middleware
    }
}
