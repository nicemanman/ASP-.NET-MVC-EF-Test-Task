namespace WorkTesting.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StudentGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentGroup()
        {
            StudentsInGroups = new HashSet<StudentInGroup>();
        }

        [DisplayName("���������� ���������")]
        public int Count 
        {
            get 
            {
                return StudentsInGroups.Where(x => x.StudentGroupId == Id).Count();
            }
        }

        public string TeacherName 
        {
            get 
            {
                return Teacher.Name;
            }
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("������� ������")]
        public string Name { get; set; }

        public int? TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentInGroup> StudentsInGroups { get; set; }
    }
}
