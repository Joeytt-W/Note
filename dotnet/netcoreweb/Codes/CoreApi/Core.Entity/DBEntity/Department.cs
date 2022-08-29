using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Core.Entity.Enum;

namespace Core.Entity.DBEntity
{
    public class Department
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();

        [Required]
        [Display(Name="部门"),StringLength(20,ErrorMessage ="{0}的长度不能超过{1}")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "部门编号"), StringLength(10, ErrorMessage = "{0}的长度不能超过{1}")]
        public string DeptCode { get; set; }

        [Display(Name = "职能描述"),DataType(DataType.Text)]
        public string Description { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "创建人"), StringLength(20, ErrorMessage = "{0}的长度不能超过{1}")]
        public string CreateUser { get; set; }

        [Display(Name = "上次更新时间")]
        public DateTime UpdateTime { get; set; }

        [Display(Name = "更新人"), StringLength(20, ErrorMessage = "{0}的长度不能超过{1}")]
        public string UpdateUser { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
