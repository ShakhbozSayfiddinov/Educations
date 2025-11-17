using EducationCenter.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Domain.Entities
{
    public class TeacherScience : Auditable
    {

        public int TeacherId { get; set; }
        public int ScienceId { get; set; }
        public Teacher Teacher { get; set; }
        public Science Science { get; set; }
    }
}
