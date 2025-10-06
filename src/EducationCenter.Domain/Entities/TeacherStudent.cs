using EducationCenter.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Domain.Entities
{
    public class TeacherStudent : Auditable
    {
        public int TeacherId { get; set; }
        public int StudentId { get; set; }
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }

    }
}
