using Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entity.Dto
{
    public class UserUpdateDto
    {
        /// <summary>
        /// ID
        /// </summary>
        [Display(Name = "ID")]
        [Required(ErrorMessage = "{0}不能为空")]
        public Guid ID { get; set; } = new Guid();

        /// <summary>
        /// 部门ID
        /// </summary>
        public Guid DepartmentID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        [StringLength(20, ErrorMessage = "{0}长度不能超过{1}")]
        public string UserName { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Display(Name = "编号")]
        [StringLength(10, ErrorMessage = "{0}长度不能超过{1}")]
        public string UserCode { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Display(Name = "密码"), StringLength(18, ErrorMessage = "{0}长度不能超过{1}")]
        public string Password { get; set; }

        /// <summary>
        /// 性别 1男 0女
        /// </summary>
        [Display(Name = "性别")]
        public Gender Sex { get; set; }

        /// <summary>
        /// 电话号码
        /// </summary>
        [Display(Name = "电话号码")]
        [Phone(ErrorMessage = "电话号码格式不正确")]
        [StringLength(20, ErrorMessage = "{0}长度不能超过{1}")]
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Display(Name = "邮箱")]
        [EmailAddress(ErrorMessage = "邮箱格式不正确")]
        [StringLength(20, ErrorMessage = "{0}长度不能超过{1}")]
        public string Email { get; set; }

        /// <summary>
        /// 是否可用 
        /// 1可用 
        /// 0不可用
        /// </summary>
        [Required]
        public Avaiable Avaiable { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        [Display(Name = "出生日期")]
        [DataType(DataType.DateTime, ErrorMessage = "{0}为时间类型")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "创建人"), StringLength(20, ErrorMessage = "{0}的长度不能超过{1}")]
        public string CreateUser { get; set; }

        [Display(Name = "更新人"), StringLength(20, ErrorMessage = "{0}的长度不能超过{1}")]
        public string UpdateUser { get; set; }

        public ICollection<Guid> RoldIDs { get; set; }
    }
}
