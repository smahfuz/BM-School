using CORE.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public String Phone { get; set; }
        public int ClassId { get; set; }

        [ForeignKey(nameof(ClassId))]
        public ClassLevel ClassLevel { get; set; }


    }
}
