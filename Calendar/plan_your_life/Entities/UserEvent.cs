﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 public enum Status
{
    ToBe = 1,
    NotToBe = 0
}

namespace Calendar.plan_your_life.Entities
{
    public class UserEvent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        public Event Event { get; set; }
        public Status Status { get; set; }
    }
}