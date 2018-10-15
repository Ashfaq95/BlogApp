using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminEntity
{
    public class Admin
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Name cannot be empty")]
        [MaxLength(10, ErrorMessage = "Maximum 10 characters allowed")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Name cannot be empty")]
        [MinLength(8, ErrorMessage = "Maximum 10 characters allowed")]
        public string Password { get; set; }
    }
}
