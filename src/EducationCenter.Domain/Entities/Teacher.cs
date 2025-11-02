using EducationCenter.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Domain.Entities
{
    public class Teacher : GlobalUser
    {
        public string Description { get; set; }
        public string Dagree { get; set; } // Enum qilish mumkin yoki Degree table
        public int ImageId { get; set; }
        public ICollection<Attachment> Attachment { get; } = new HashSet<Attachment>();
        public DateTime HireDate { get; set; }
        public int ExoerienceYear { get; set; }
        public ICollection<TeacherGroup> TeacherGroups { get; } = new HashSet<TeacherGroup>();
        public ICollection<TeacherScience> TeacherSciences { get; } = new HashSet<TeacherScience>();
        public ICollection<TeacherStudent> TeacherStudents { get; } = new HashSet<TeacherStudent>();
    }
}

