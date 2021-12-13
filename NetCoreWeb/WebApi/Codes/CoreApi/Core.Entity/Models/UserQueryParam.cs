using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity.Models
{
    public class UserQueryParam: BaseQueryParam
    {       
        public Guid UserId { get; set; }

        //public string UserName { get; set; }

        //public string UserCode { get; set; }

        public Guid DepartmentId { get; set; }

    }
}
