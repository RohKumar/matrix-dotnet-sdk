﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Matrix.Webapp.Client.Models
{
    public class User
    {
        [DisplayName("User Name")]
        [Required(ErrorMessage ="This field is required.")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]
        public string Password { get; set; }
    }
}
