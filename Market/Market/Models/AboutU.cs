namespace Market.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AboutU
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(250)]
        public string AboutImage { get; set; }

        [Required]
        [StringLength(250)]
        public string İconimg { get; set; }
    }
}
