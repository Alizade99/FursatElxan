namespace Market.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int Id { get; set; }

        public int? ProductId { get; set; }

        public int? UserId { get; set; }

        public DateTime? PurchaseDate { get; set; }

        public int? Amount { get; set; }

        public double? Price { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
