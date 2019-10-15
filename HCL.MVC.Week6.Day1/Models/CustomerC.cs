using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCL.MVC.Week6.Day1.Models
{
    public class CustomerC
    {
        public int Id { get; set; }

        [Display(Name ="Customer Name")]
        [Required(ErrorMessage ="*Name is Mandatory")]
        [StringLength(25,ErrorMessage ="Max. of Length 25")]
        [Column(TypeName ="varchar")]
        public string CustomerName { get; set; }

        //[Required(ErrorMessage ="*Date Of Birth Required")]
        [Display(Name ="Date Of Birth")]
        public DateTime? DOB { get; set; }

        [Required(ErrorMessage ="*This Field is Compulsory")]
        [StringLength(6)]
        [Column(TypeName ="varchar")]
        public string Gender { get; set; }

        [Display(Name ="City Name")]
        [StringLength(20)]
        [Column(TypeName ="varchar")]
        public string City { get; set; }
        //reference table

       
        public MembershipType MembershipType { get; set; }
        //referance Column
        [Required(ErrorMessage = "*Mandatory Field")]
        public int? MembershipTypeId { get; set; }

    }
}