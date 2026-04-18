using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entity.Dto
{
    public class DepartmentUpdateDto
    {
        [Display(Name = "ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        [Key]
        public Guid ID { get; set; }

        [Display(Name = "部门"), StringLength(20, ErrorMessage = "{0}的长度不能超过{1}")]
        public string Name { get; set; }

        [Display(Name = "部门编号"), StringLength(10, ErrorMessage = "{0}的长度不能超过{1}")]
        public string DeptCode { get; set; }

        [Display(Name = "职能描述"), DataType(DataType.Text)]
        public string Description { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "创建人"), StringLength(20, ErrorMessage = "{0}的长度不能超过{1}")]
        public string CreateUser { get; set; }

        [Display(Name = "更新人"), StringLength(20, ErrorMessage = "{0}的长度不能超过{1}")]
        public string UpdateUser { get; set; }
    }
}
