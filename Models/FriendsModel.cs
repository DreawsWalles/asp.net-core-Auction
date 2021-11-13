using System.ComponentModel.DataAnnotations;

namespace project.Models
{
    public class FriendsModel
    {
        public int Id { get; set; }
        public int? FriendOneId { get; set; }
        public int? FriendTwoId { get; set; }
        public int status { get; set; }

        public virtual UserModel FriendOne { get; set; }
        public virtual UserModel FriendTwo { get; set; }
    }
}
