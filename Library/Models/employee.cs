namespace Library.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("employee")]
    public partial class employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public employee()
        {
            books = new HashSet<book>();
        }

        [Key]        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int empId { get; set; }
               
        [StringLength(50)]
        [Required(ErrorMessage = "the name is Required!")]
        public string name { get; set; }

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
        [Compare("Password", ErrorMessage = "password doesn't match")]
        [Display(Name = "Confirm Password")]
        [NotMapped]
        public string cpassword { get; set; }

        [Range(500, 6000, ErrorMessage = "must be between 500 and 6000")]
        public int salary { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<book> books { get; set; }
    }
}
