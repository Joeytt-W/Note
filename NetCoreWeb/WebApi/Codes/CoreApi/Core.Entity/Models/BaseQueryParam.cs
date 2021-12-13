using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity.Models
{
    public class BaseQueryParam
    {
        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        private const int MaxPageSize = 20;//默认一页的最大数量

        public string SearchStr { get; set; }

        public int PageNumber { get; set; } = 1;

        public string OrderBy { get; set; } = "CreateTime";
    }
}
