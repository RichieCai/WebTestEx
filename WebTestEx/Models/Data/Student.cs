using System;
using System.Collections.Generic;

namespace WebTestEx.Models.Data
{
    public partial class Student
    {
        public Student()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; } = null!;
        public DateTime? DateOfBirth { get; set; }
        public int Phone { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Grade { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
