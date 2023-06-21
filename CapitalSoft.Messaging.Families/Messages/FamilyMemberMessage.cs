using System;

namespace CapitalSoft.Messaging.Families.Messages
{
    public class FamilyMemberMessage
    {
        public Guid PersonId { set; get; }
        public string Firstname { set; get; }
        public string Lastname { set; get; }
        public string Middlename { set; get; }
        public string SocialCard { set; get; }
        public DateTime? Birthdate { set; get; }
        public Guid BidId { set; get; }
        public int BidNumber { set; get; }
    }
}