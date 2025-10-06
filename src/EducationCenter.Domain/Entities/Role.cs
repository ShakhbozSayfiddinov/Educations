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
        public IList<User> User { get; set; }
    }
}
