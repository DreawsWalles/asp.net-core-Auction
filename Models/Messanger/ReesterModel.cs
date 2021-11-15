using project.Models;

namespace project.asp.net.core.Models.Messanger
{
    public class ReesterModel
    {
        public int Id { get; set; }
        public int? Userid { get; set; }
        public int? LastMessageId { get; set; }

        public virtual UserModel User { get; set; }
        public virtual MessagesModel LastMessage { get; set; }
    }
}
