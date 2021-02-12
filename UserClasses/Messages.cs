using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace User_API.UserClasses
{
    public class Messages
    {

        [Key]
        public int MessageId { get; set; }

        [MaxLength(50, ErrorMessage = "Only admit 50 characters")]
        public String Subject { get; set; }

        [MaxLength(300, ErrorMessage = "Body cannot be over 300 characters")]
        public String Body { get; set; }

        [Required]
        public DateTime MessageDate { get; set; }


        [JsonIgnore]//ForeignKey
        public Users userId { get; set; }


    }
}
