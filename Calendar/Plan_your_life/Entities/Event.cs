﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Plan_your_life.Entities
{
    public class Event
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] 
        public int Id { get; set; }
        [MaxLength(30)]
        [Column(TypeName = "VARCHAR")]
        public String Name { get; set; }
        [MaxLength(255)]
        [Column(TypeName = "TEXT")]
        public String Description { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime StartAt { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime EntAt { get; set; }
        public List<UserEvent> UserEvents { get; set; }
    }
}