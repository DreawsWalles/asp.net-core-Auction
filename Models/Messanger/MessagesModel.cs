using project.Models;
using System;

namespace project.asp.net.core.Models.Messanger
{
    public class MessagesModel
    {
        public int Id { get; set; }
        public int? SenderId { get; set; }
        public int? RecipientId { get; set; }
        public DateTime Date { get; set; }
        public string FilePath { get; set; }
        public int? MessageId { get; set; }

        public virtual MessageModel Message { get; set; }
        public virtual UserModel Sender { get; set; }
        public virtual UserModel Recipient { get; set; }
    }
}
