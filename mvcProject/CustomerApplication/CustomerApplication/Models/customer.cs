using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerApplication.Models
{
    public class customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Amount is Required")]
        public int Amount { get; set; }

        [Required(ErrorMessage ="City is Required")]
        public string City { get; set; }
    }
}