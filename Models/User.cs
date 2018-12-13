using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace weddingplanner.Models
{
    public class User
    {
    public User(){}
    [Key]
    public int UserId {get;set;}

    [Required]
    public string FirstName{get;set;}
    [Required]
    public string LastName {get;set;}
    [EmailAddress]
    [Required]
    public string Email {get;set;}
    [DataType(DataType.Password)]
    [Required]
    [MinLength(0, ErrorMessage="Password must be 8 characters or Longer!")]
    public string Password {get;set;}
    
    public DateTime CreatedAt {get;set;}

    public DateTime UpdatedAt {get;set;}

    [NotMapped]
    [Compare("Password")]
    [DataType(DataType.Password)]
    public string confirm {get;set;}

    public List<Rsvp> WeddingPlanned {get;set;}
    }

}