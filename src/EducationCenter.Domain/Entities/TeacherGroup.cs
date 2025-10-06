using EducationCenter.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Domain.Entities
{
    public class TeacherGroup :Auditable
    {
        public int TeacherId { get; set; }
        public int GroupId { get; set; }
        public Teacher Teacher { get; set; }
        public Group Group { get; set; }
    }
}
