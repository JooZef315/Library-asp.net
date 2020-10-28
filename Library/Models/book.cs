namespace Library.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("book")]
    public partial class book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public book()
        {
            visitors = new HashSet<visitor>();
        }

        [Key]
        [StringLength(50)]
        [Display(Name = "ISBN")]
        [Required(ErrorMessage = "ISBN is Required!")]
        public string isbn { get; set; }

        [Required(ErrorMessage = "name is Required!")]
        [StringLength(50)]
        public string name { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "description")]
        public string desc { get; set; }

        [Required]
        [StringLength(50)]
        public string author { get; set; }

        [DataType(DataType.ImageUrl)]
        public string img_url { get; set; }

        [ForeignKey("employee")]
        [Display(Name = "employee Id")]
        public int empBId { get; set; }

        [Display(Name = "added by")]
        public virtual employee employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<visitor> visitors { get; set; }
    }
}
