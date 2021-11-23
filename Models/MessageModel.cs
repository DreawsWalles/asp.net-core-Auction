using project.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.asp.net.core.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string Message { get; set; }

        public UserModel Sender { get; set; }
        [NotMapped]
        public UserModel Recipient { get; set; }
    }
}
