namespace Market.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public double Price { get; set; }

        public DateTime Time { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public double? Discount_price { get; set; }

        [StringLength(50)]
        public string İconimg { get; set; }

        public double Amount { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int? subCategoryId { get; set; }

        public int? MarketId { get; set; }

        public virtual AllMarket AllMarket { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}
