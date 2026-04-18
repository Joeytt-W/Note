using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entity.DBEntity
{
    /// <summary>
    /// 用户权限
    /// </summary>
    public class RoleUser
    {
        public Guid UserID { get; set; }

        public Guid RoleID { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "创建人"), StringLength(20, ErrorMessage = "{0}的长度不能超过{1}")]
        public string CreateUser { get; set; }

        public User User { get; set; }

        public Role Role { get; set; }
    }
}
