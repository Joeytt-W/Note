using Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entity.Dto
{
    public class DepartmentAddDto
    {
        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "部门"), StringLength(20, ErrorMessage = "{0}的长度不能超过{1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0}不能为空")]
        [Display(Name = "部门编号"), StringLength(10, ErrorMessage = "{0}的长度不能超过{1}")]
        public string DeptCode { get; set; }

        [Display(Name = "职能描述"), DataType(DataType.Text)]
        public string Description { get; set; }

        [Display(Name = "创建人"), StringLength(20, ErrorMessage = "{0}的长度不能超过{1}")]
        public string CreateUser { get; set; }
    }
}
