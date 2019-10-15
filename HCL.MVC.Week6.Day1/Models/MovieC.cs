using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCL.MVC.Week6.Day1.Models
{
    public class MovieC
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="*This Field is Mandatory")]
        [StringLength(25,ErrorMessage ="Should not exceed the Length of 25")]
        [Display (Name="Movie Title")]
        [Column(TypeName ="Varchar")]
        public string Name { get; set; }
        //public string Genre { get; set; }

        [Required(ErrorMessage ="*Mandatory Field")]
        [Display(Name="Date of Release")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "*Mandatory Field")]
        public DateTime AddDate { get; set; }

        [Required(ErrorMessage = "*Mandatory Field")]
        [Display(Name="Stock Available")]
        public int AvailableStock { get; set; }
        //reference table

       
        public GenreType GenreType { get; set; }
        //reference column
        
        [Required(ErrorMessage ="*Mandatory Field")]
        public int? GenreTypeId { get; set; }

    }
}