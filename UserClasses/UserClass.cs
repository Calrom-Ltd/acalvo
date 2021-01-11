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
        [MaxLength(50, ErrorMessage = "Name can be only 50 characters Long!")]
        public String UserName { get; set; }



        //Create relationShip (oneToMany)
        public ICollection<MessageClass> messageClasses { get; set; }



    }
}
