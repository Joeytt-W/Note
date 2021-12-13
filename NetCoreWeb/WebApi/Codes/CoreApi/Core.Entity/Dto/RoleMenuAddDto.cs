using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity.Dto
{
    public class RoleMenuAddDto
    {
        public Guid RoleId { get; set; }

        public ICollection<Guid> MenuIds { get; set; }

        public string CreateUser { get; set; }
    }
}
