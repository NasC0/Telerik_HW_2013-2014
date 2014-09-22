using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ChatApp.Model
{
    public class Message
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string MsgText { get; set; }

        public DateTime MsgDate { get; set; }

        public User User { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", this.User.Username, this.MsgText);
        }
    }
}
