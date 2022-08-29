using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entity.DBEntity
{
    public class RoleMenu
    {
        [Key]
        public Guid RoleID { get; set; }

        [Key]
        public Guid MenuID { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "创建人"), StringLength(20, ErrorMessage = "{0}的长度不能超过{1}")]
        public string CreateUser { get; set; }

        public Role Role { get; set; }

        public Menu Menu { get; set; }
    }
}
