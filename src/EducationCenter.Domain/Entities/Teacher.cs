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
        public List<Attachment> Attachment { get; set; }
        public DateTime HireDate { get; set; }
        public int ExoerienceYear { get; set; }
        public List<TeacherGroup> TeacherGroups { get; set; }
        public List<TeacherScience> TeacherSciences { get; set; }
        public List<TeacherStudent> TeacherStudents { get; set; }


    }
}
