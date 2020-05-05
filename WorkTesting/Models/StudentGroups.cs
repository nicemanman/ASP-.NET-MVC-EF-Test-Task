namespace WorkTesting.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StudentGroups
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentGroups()
        {
            StudentGroupsStaff = new HashSet<StudentGroupsStaff>();
        }

        [DisplayName("���������� ���������")]
        public int Count 
        {
            get 
            {
                return StudentGroupsStaff.Where(x => x.StudentGroupId == Id).Count();
            }
        }


        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("������� ������")]
        public string Name { get; set; }

        public int? TeacherId { get; set; }

        public virtual Teachers Teachers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentGroupsStaff> StudentGroupsStaff { get; set; }
    }
}
