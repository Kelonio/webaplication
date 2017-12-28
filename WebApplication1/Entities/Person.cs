using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//https://github.com/hazzik/DelegateDecompiler
using DelegateDecompiler;

namespace WebApplication1.Entities
{
    public abstract class Person
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        [Display(Name = "Full Name")]
        [Computed]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }
    }


    public class PersonDto
    {
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
    }
}



