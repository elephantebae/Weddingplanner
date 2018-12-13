using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace weddingplanner.Models
{

    public class LoginAndReg
    {
        public Login logmodel {get;set;}
        public User regmodel {get;set;}
    }
}