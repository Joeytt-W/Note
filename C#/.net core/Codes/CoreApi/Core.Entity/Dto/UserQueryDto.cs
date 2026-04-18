using Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entity.Dto
{
    public class UserQueryDto
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [ForeignKey(nameof(Department))]
        public Guid DepartmentID { get; set; }

        [Required]
        [Display(Name = "姓名")]
        [StringLength(20, ErrorMessage = "{0}长度不能超过{1}")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "编号")]
        [StringLength(10, ErrorMessage = "{0}长度不能超过{1}")]
        public string UserCode { get; set; }

        [Required]
        [Display(Name = "密码"), StringLength(18, ErrorMessage = "{0}长度不能超过{1}")]
        public string Password { get; set; }

        [Display(Name = "性别")]
        public Gender Sex { get; set; }

        [Display(Name = "电话号码")]
        [Phone(ErrorMessage = "电话号码格式不正确")]
        [StringLength(20, ErrorMessage = "{0}长度不能超过{1}")]
        public string Phone { get; set; }

        [Display(Name = "邮箱")]
        [EmailAddress(ErrorMessage = "邮箱格式不正确")]
        [StringLength(20, ErrorMessage = "{0}长度不能超过{1}")]
        public string Email { get; set; }

        [Display(Name = "是否启用")]
        public Avaiable Avaiable { get; set; } = Avaiable.Yes;

        [Display(Name = "出生日期")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "创建人"), StringLength(20, ErrorMessage = "{0}的长度不能超过{1}")]
        public string CreateUser { get; set; }

        [Display(Name = "上次更新时间")]
        public DateTime UpdateTime { get; set; }

        [Display(Name = "更新人"), StringLength(20, ErrorMessage = "{0}的长度不能超过{1}")]
        public string UpdateUser { get; set; }

        [Required]
        [Display(Name = "拼音")]
        [StringLength(20, ErrorMessage = "{0}长度不能超过{1}")]
        public string Spell { get; set; }

        public DepartmentQueryDto Department { get; set; }

        public IEnumerable<RoleQueryDto> Roles { get; set; }
    }
}
