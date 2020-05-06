namespace WorkTesting.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Organisation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Organisation()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        [DisplayName("Организация")]
        public string Name { get; set; }

        [StringLength(12)]
        public string TIN { get; set; }

        public int? TeacherID { get; set; }

        public virtual Teacher Teachers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<StudentInGroup> StudentsInGroups { get; set; }
    }
}
