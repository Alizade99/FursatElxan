namespace Market.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        [Key]
        public int İd { get; set; }

        [Column("slide")]
        [Required]
        [StringLength(500)]
        public string slide1 { get; set; }
    }
}
