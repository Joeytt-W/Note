using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entity.Dto
{
    public class DepartmentQueryDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string DeptCode { get; set; }
        public string Description { get; set; }
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "创建人"), StringLength(20, ErrorMessage = "{0}的长度不能超过{1}")]
        public string CreateUser { get; set; }

        [Display(Name = "上次更新时间")]
        public DateTime UpdateTime { get; set; }

        [Display(Name = "更新人"), StringLength(20, ErrorMessage = "{0}的长度不能超过{1}")]
        public string UpdateUser { get; set; }
    }
}
