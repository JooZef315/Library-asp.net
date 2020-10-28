namespace Library.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class library : DbContext
    {
        public library()
            : base("name=library")
        {
        }

        public virtual DbSet<book> books { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<visitor> visitors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<book>()
                .Property(e => e.desc)
                .IsUnicode(false);

            modelBuilder.Entity<book>()
                .HasMany(e => e.visitors)
                .WithMany(e => e.books)
                .Map(m => m.ToTable("owns").MapLeftKey("BId").MapRightKey("UserId"));

            modelBuilder.Entity<employee>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.password)
                .IsUnicode(false);


            modelBuilder.Entity<employee>()
                .HasMany(e => e.books)
                .WithRequired(e => e.employee)
                .HasForeignKey(e => e.empBId)
                .WillCascadeOnDelete(false);
        }
    }
}
