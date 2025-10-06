using EducationCenter.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Domain.Entities
{
    public class Student: GlobalUser
    {
        public List<StudentGroup> StudentGroups { get; set; }
        public List<TeacherStudent> TeacherStudents { get; set; }
    }
}
