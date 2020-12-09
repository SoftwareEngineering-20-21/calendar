using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Calendar.plan_your_life.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        [Column(TypeName = "VARCHAR")]
        [RegularExpression(@"(^[a-zA-Z0-9]+([._]?[a-zA-Z0-9]+)*$)", ErrorMessage = "username is not correct!")]
        public String UserName { get; set; }

        [MaxLength(30)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public String Email { get; set; }

        [MaxLength(30)]
        [Column(TypeName = "VARCHAR")]
        [RegularExpression(@"^(?=.*[a-z]+)(?=.*[A-Z]+)(?=.*\\d+)(?=.*[~`!@#$%^&*()+=_\\-{}|:;”’?/<>,.\\]\\[]+).{8,}$", ErrorMessage =
            "Password has contain at least one character of Uppercase letter (A-Z), Lowercase letter (a-z), Digit (0-9), Special character (~`!@#$%^&*()+=_-{}[]|:;\\”\\’?/<>,.)")]
        public String Password { get; set; }


        [Column(TypeName = "DATE")]
        public DateTime CreatedAt { get; set; }


        public List<UserEvent> UserEvents { get; set; }
    }
}
