using System;
using _01_FreamWork.Domain;
using MB.Domain.ArticleAgg;

namespace MB.Domain.CommentAgg
{
    public class Comment:DomainBase<long>
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public int Status { get; private set; }//new =0 , confirm=1 , cancel=2
        public long ArticleId { get; private set; }
        public Article Article { get; private set; }

        public Comment(string name, string email, string massage, long articleId)
        {
            Name = name;
            Email = email;
            Message = massage;
            ArticleId = articleId;
            Status = Statuses.New;
        }

        protected Comment()
        {
            
        }

        public void Confirm() => Status = Statuses.Confirm;
        public void Canceled() => Status = Statuses.Canceled;
    }
}
