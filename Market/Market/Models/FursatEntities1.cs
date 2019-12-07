namespace Market.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FursatEntities1 : DbContext
    {
        public FursatEntities1()
            : base("name=FursatEntities1")
        {
        }

        public virtual DbSet<AboutU> AboutUs { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<AllMarket> AllMarkets { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllMarket>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.AllMarket)
                .HasForeignKey(e => e.MarketId);

            modelBuilder.Entity<SubCategory>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.SubCategory)
                .HasForeignKey(e => e.subCategoryId);
        }
    }
}
