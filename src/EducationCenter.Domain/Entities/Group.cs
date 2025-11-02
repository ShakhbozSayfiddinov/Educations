using EducationCenter.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Domain.Entities
{
    public class Group : Auditable
    {
        public string Name { get; set; }
        public int CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Course Course { get; set; }
        public ICollection<StudentGroup> StudentGroups { get; } = new HashSet<StudentGroup>();
        public ICollection<TeacherGroup> TeacherGroups { get; } = new HashSet<TeacherGroup>();
    }
}
