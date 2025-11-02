using EducationCenter.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Domain.Entities
{
    public class Role : Auditable
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public ICollection<User> User { get; } = new HashSet<User>();
    }
}
