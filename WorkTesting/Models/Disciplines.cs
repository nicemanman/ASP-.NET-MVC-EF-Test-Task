namespace WorkTesting.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Disciplines
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Discipline { get; set; }
    }
}
