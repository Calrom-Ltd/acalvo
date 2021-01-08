using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace User_API.UserClasses
{
    public class MessageClass
    {

        [Key]
        public int MessageId { get; set; }

        [MaxLength (50, ErrorMessage ="Only admit 50 characters")]
        public String Subject { get; set; }

        [MaxLength(300, ErrorMessage ="Body cannot be over 300 characters")]
        public String Body { get; set; }

        
        //ForeignKey
        public String PasswordId { get; set; }


        public UserClass userClass { get; set; }


    }
}
