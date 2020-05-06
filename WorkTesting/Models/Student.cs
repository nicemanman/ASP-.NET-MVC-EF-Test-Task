namespace WorkTesting.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Staff")]
    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            StudentGroupsStaff = new HashSet<StudentInGroup>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Имя студента")]
        public string Name { get; set; }

        public int? OrganisationId { get; set; }

        public virtual Organisation Organisations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentInGroup> StudentGroupsStaff { get; set; }
    }
}
