using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DoubleADevMVC.UI.MVC.Models
{
    public class ContactFormViewModel
    {

        //Properties
        [Required(ErrorMessage = "*Name is required.")]
        public string Name { get; set; }

        [Required (ErrorMessage = "*Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Subject { get; set; }

        [Required (ErrorMessage = "*Message is required.")]
        [UIHint("MultilineText")]
        public string Message { get; set; }

    }
}