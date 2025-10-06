using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Domain.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string entityName, object key)
            : base($"{entityName} with key {key} not found", 404)
        {

        }
    }
}
