namespace WorkTesting.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StudentGroupsStaff")]
    public partial class StudentInGroup
    {
        public int Id { get; set; }

        public int? StudentGroupId { get; set; }

        public int? EmployeeId { get; set; }

        [DisplayName("Организация")]
        public int? OrganisationId { get; set; }

        public virtual Organisation Organisations { get; set; }
        public virtual Student Staff { get; set; }

        public virtual StudentGroup StudentGroups { get; set; }
    }
}
