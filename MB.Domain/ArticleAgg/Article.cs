using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.CommentAgg;

namespace MB.Domain.ArticleAgg
{
    public class Article
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Image { get; private set; }
        public string Content { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }
        public long ArticleCategoryId { get; private set; }
        public ArticleCategory ArticleCategory { get;private set; }
        public List<Comment> Comments { get;private set; }

        protected Article()
        {
            
        }

        private static void Validation(string title, long articlecategoryid)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException();
            if (articlecategoryid == 0)
                throw new ArgumentNullException();
        }
        public Article( string title, string shortDescription, string image, string content,long articleCategoryId)
        {
            Validation(title,articleCategoryId);
            Title = title;
            ShortDescription = shortDescription;
            Image = image;
            Content = content;
            ArticleCategoryId = articleCategoryId;
            IsDeleted = false;
            CreationDate = DateTime.Now;
            Comments = new List<Comment>();
        }

        public void Edit(string title, string shortDescription, string image, string content, long articleCategoryId)
        {
            Title = title;
            ShortDescription = shortDescription;
            Image = image;
            Content = content;
            ArticleCategoryId = articleCategoryId;
        }

        public void Remove() => this.IsDeleted = true;
        public void Active() => this.IsDeleted = false;
    }
}
