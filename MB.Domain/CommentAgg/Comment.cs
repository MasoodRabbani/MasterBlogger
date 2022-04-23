using System;
using MB.Domain.ArticleAgg;

namespace MB.Domain.CommentAgg
{
    public class Comment
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Massage { get; private set; }
        public int Status { get; private set; }//new =0 , confirm=1 , cancel=2
        public DateTime CreationDate { get; private set; }
        public long ArticleId { get; private set; }
        public Article Article { get; private set; }

        public Comment(string name, string email, string massage, long articleId)
        {
            Name = name;
            Email = email;
            Massage = massage;
            ArticleId = articleId;
            CreationDate=DateTime.Now;
            Status = Statuses.New;
        }

        protected Comment()
        {
            
        }
    }
}
