namespace Library.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("visitor")]
    public partial class visitor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public visitor()
        {
            books = new HashSet<book>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Uid { get; set; }
               
        [StringLength(50)]
        [Required(ErrorMessage = "the name is Required!")]
        public string Fname { get; set; }

        [StringLength(50)]        
        public string Lname { get; set; }

        [Range(18, 60, ErrorMessage = "must be between 18 and 60")]
        public int? age { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "email")]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [StringLength(10)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Required]
        [StringLength(10)]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "password doesn't match")]
        [Display(Name = "Confirm Password")]        
        public string cpassword { get; set; }

        [StringLength(1)]
        public string gander { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<book> books { get; set; }
    }
}
