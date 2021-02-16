using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace User_API.UserClasses
{
    public class Messages
    {

        [Key]
        public int MessageId { get; set; }

        [MaxLength(50, ErrorMessage = "Only admit 50 characters")]
        public string Subject { get; set; }

        [MaxLength(300, ErrorMessage = "Body cannot be over 300 characters")]
        public string Body { get; set; }

        [Required]
        public DateTime MessageDate { get; set; }


        [JsonIgnore]//ForeignKey
        public Users userId { get; set; }


    }
}
