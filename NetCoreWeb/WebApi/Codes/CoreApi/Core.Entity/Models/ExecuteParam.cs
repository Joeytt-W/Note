using Core.Entity.DBEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Core.Entity.Models
{
    /// <summary>
    /// 查询类方法最终的输出结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExecuteParam<T>
    {
        // <summary>
        /// 信息码
        /// </summary>
        public HttpStatusCode statusCode { get; set; }

        /// <summary>
        /// 返回消息
        /// </summary>
        public string Information { get; set; }

        /// <summary>
        /// 返回信息详情
        /// </summary>
        public Inparam<T> data { get; set; } = new Inparam<T>();
    }


    public class Inparam<T>
    {
        /// <summary>
        /// 当前页数
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// 每页显示条数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总条数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public List<T> dataList { get; set; } = null;
    }
}
