namespace WorkTesting.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentGroupsStaff")]
    public partial class StudentGroupsStaff
    {
        public int Id { get; set; }

        public int? StudentGroupId { get; set; }

        public int? EmployeeId { get; set; }

        [DisplayName("Организация")]
        public int? OrganisationId { get; set; }

        public virtual Organisations Organisations { get; set; }
        public virtual Staff Staff { get; set; }

        public virtual StudentGroups StudentGroups { get; set; }
    }
}
