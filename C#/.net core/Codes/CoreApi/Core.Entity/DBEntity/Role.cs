using Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entity.DBEntity
{
    public class Role
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();

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

        [Display(Name = "上次更新时间")]
        public DateTime UpdateTime { get; set; }

        [Display(Name = "更新人"), StringLength(20, ErrorMessage = "{0}的长度不能超过{1}")]
        public string UpdateUser { get; set; }

        [Display(Name = "描述")]
        public string Description { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<Menu> Menus { get; set; }
    }
}
