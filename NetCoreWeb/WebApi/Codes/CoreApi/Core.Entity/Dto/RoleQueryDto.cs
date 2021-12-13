using Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Entity.Dto
{
    public class RoleQueryDto
    {
        public Guid ID { get; set; }
        public string RoldCode { get; set; }
        public string RoleName { get; set; }
        [Display(Name = "是否启用")]
        public Avaiable Avaiable { get; set; }
        public string Description { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "创建人"), StringLength(20, ErrorMessage = "{0}的长度不能超过{1}")]
        public string CreateUser { get; set; }
    }
}
