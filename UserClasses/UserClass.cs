using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace User_API.UserClasses
{
    public class UserClass
    {
        [Key]
        public String Password { get; set; }

        [Required]
        //Validation rule
        [MaxLength (50, ErrorMessage = "Name cannot be that long")]
        public String UserName { get; set; }

        [StringLength(200, ErrorMessage = "Message cannot be that long")]
        public String Message { get; set; }


    }
}
