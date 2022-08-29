using Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Core.Entity.Models
{
    public class NonExecuteOutParam
    {
        /// <summary>
        /// 信息码
        /// </summary>
        public HttpStatusCode statusCode { get; set; }
        /// <summary>
        /// 返回信息详情
        /// </summary>
        public string Information { get; set; }
    }
}
