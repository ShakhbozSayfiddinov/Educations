using EducationCenter.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Domain.Entities
{
    public class Course : Auditable
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
