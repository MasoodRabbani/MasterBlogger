using System;
using System.Collections.Generic;
using _01_FreamWork.Domain;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Domain.ArticleCategoryAgg
{
    public class ArticleCategory:DomainBase<long>
    {
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
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
