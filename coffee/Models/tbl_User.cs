//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace coffee.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tbl_User
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("User Name"), Required(ErrorMessage = "Please Enter Your Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Your Email address"), DataType(DataType.EmailAddress, ErrorMessage = "Please Enter a Valid Email")]
        public string Email { get; set; }

        [DataType(DataType.Password), MinLength(8, ErrorMessage = "Password Must Be More Than 8 Characters"), Required(ErrorMessage = "Please Enter Your Password")]
        public string Password { get; set; }

        [DataType(DataType.Password), NotMapped, Compare("Password", ErrorMessage = "Passwords Doesn't Match")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Range(0, 150)]
        public int Age { get; set; }
    }
}
