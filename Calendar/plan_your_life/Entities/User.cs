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
        public String UserName { get; set; }

        [MaxLength(30)]
        [Column(TypeName = "VARCHAR")]
        public String Email { get; set; }

        [MaxLength(30)]
        [Column(TypeName = "VARCHAR")]
        public String Password { get; set; }


        [Column(TypeName = "DATE")]
        public DateTime CreatedAt { get; set; }


        public List<UserEvent> UserEvents { get; set; }
    }
}