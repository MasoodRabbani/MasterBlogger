using System;
using System.Collections.Generic;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }
        public List<Article> Articles { get; set; }

        protected ArticleCategory()
        {

        }
        public ArticleCategory(string title,IArticleCategoryValidationServices articleCategoryValidationServices)
        {
            GuardAgainstEmptyTitle(title);
            articleCategoryValidationServices.CheckThatThisRecourdAlreadyExsitis(title);
            Title = title;
            IsDeleted = false;
            CreationDate=DateTime.Now;
            Articles = new List<Article>();
        }

        public void GuardAgainstEmptyTitle(string Title)
        {
            if (string.IsNullOrWhiteSpace(Title))
            {
                throw new ArgumentNullException();
            }
        }
        public void Rename(string title)
        {
            GuardAgainstEmptyTitle(title);
            Title = title;
        }

        public void Remove() => IsDeleted = true;
        public void Active() => IsDeleted = false;
    }
}
