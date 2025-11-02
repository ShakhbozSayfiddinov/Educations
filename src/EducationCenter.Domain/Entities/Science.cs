using EducationCenter.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Domain.Entities
{
    public class Science : Auditable
    {
        public string Name { get; set; }
        public string ScienceLanguage { get; set; }
        public ICollection<TeacherScience> TeacherSciences { get; } = new HashSet<TeacherScience>();

    }
}
