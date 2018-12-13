using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace weddingplanner.Models
{
    public class Rsvp
    {
        public Rsvp(){}
        [Key]
        public int RsvpId{get;set;}

        public int UserId{get;set;}

        public User user {get;set;}

        public int WeddingId {get;set;}

        public Wedding wedding {get;set;}
    }
}