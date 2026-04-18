using Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entity.Dto
{
    public class RoleUpdateDto
    {
        [Key]
        [Display(Name = "ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid ID { get; set; }

        [Display(Name = "角色编码")]
        [StringLength(10, ErrorMessage = "{0}长度不能超过{1}")]
        public string RoldCode { get; set; }

        [Display(Name = "角色名称")]
        [StringLength(20, ErrorMessage = "{0}长度不能超过{1}")]
        public string RoleName { get; set; }

        [Display(Name = "是否启用")]
        public Avaiable Avaiable { get; set; } = Avaiable.Yes;

        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "创建人"), StringLength(20, ErrorMessage = "{0}的长度不能超过{1}")]
        public string CreateUser { get; set; }

        [Display(Name = "更新人"), StringLength(20, ErrorMessage = "{0}的长度不能超过{1}")]
        public string UpdateUser { get; set; }
        [Display(Name = "描述")]
        public string Description { get; set; }
    }
}
