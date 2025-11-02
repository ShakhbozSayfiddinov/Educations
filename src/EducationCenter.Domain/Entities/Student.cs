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
        public ICollection<StudentGroup> StudentGroups { get;  } = new HashSet<StudentGroup>();
        public ICollection<TeacherStudent> TeacherStudents { get; } = new HashSet<TeacherStudent>();
    }
}
