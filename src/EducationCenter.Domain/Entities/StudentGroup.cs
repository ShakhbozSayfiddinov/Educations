using EducationCenter.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Domain.Entities
{
    public class StudentGroup : Auditable
    {
        public int StudentId { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public Student Student { get; set; }

    }
}
