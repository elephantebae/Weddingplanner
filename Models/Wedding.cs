using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace weddingplanner.Models
{
    public class Wedding
    {
        public Wedding(){}
        [Key]
        public int WeddingId {get;set;}
        [Required]
        public string WedderOne {get;set;}
        [Required]
        public string WedderTwo {get;set;}
        [Required]
        public DateTime Date {get;set;}
        [Required]
        public string WeddingAddress {get;set;}
        public List<Rsvp> Attendees {get;set;}
        public int? CreatorId{get;set;} 
    }
}
