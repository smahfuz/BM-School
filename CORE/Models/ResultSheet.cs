using CORE.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
    public class ResultSheet : BaseEntity
    {
        public int Mark {  get; set; }
        public string Grade { get; set; }
        public int ClassId { get; set; }
        [ForeignKey(nameof(ClassId))]
        public ClassLevel? ClassLevel { get; set; }

        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course? Course { get; set; }

        public int StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public Student? Student { get; set; }

         

        


    }
}
