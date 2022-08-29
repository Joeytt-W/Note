using Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entity.Dto
{
    public class MenuQueryDto
    {
        [Key]
        public Guid ID { get; set; } = Guid.NewGuid();

        [Required]
        [Display(Name = "菜单名称")]
        [StringLength(20, ErrorMessage = "{0}长度不能超过{1}")]
        public string MenuName { get; set; }

        [Required]
        [Display(Name = "指向地址")]
        [StringLength(50, ErrorMessage = "{0}长度不能超过{1}")]
        public string MenuUrl { get; set; }

        [Required]
        [Display(Name = "图标地址")]
        [StringLength(50, ErrorMessage = "{0}长度不能超过{1}")]
        public string MenuImageUrl { get; set; }

        [Display(Name = "是否启用")]
        public Avaiable Avaiable { get; set; } = Avaiable.Yes;

        [Display(Name = "父节点ID")]
        public Guid? ParentMenuId { get; set; }

        [Display(Name = "节点类别")]
        public MenuType MenuType { get; set; }

        [Display(Name = "序号")]
        public int MenuSort { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "创建人"), StringLength(20, ErrorMessage = "{0}的长度不能超过{1}")]
        public string CreateUser { get; set; }

        [Display(Name = "描述")]
        public string Description { get; set; }

        [Display(Name = "拼音")]
        public string Spell { get; set; }
    }
}
