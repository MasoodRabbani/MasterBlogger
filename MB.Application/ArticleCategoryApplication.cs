using System;
using System.Collections.Generic;
using System.Linq;
using _01_FreamWork.Infrastructure;
using MB.Application.Contact.ArticleCategory;
using MB.Application.Contract.ArticleCategory;
using MB.Application.Contract.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IArticleCategoryRepositoory ArticleCategoryRepositoory;
        private readonly IArticleCategoryValidationServices validationServices;

        public ArticleCategoryApplication(IUnitOfWork unitOfWork, IArticleCategoryRepositoory articleCategoryRepositoory, IArticleCategoryValidationServices validationServices)
        {
            this.unitOfWork = unitOfWork;
            ArticleCategoryRepositoory = articleCategoryRepositoory;
            this.validationServices = validationServices;
        }

        public void Create(CreateArticleCategory Command)
        {
            unitOfWork.BeginTran();
            ArticleCategoryRepositoory.Create(new ArticleCategory(Command.Title, validationServices));
            unitOfWork.CommitTran();
        }

        public void Rename(RenameArticleCategory Command)
        {
            unitOfWork.BeginTran();
            var model = ArticleCategoryRepositoory.Get(Command.Id);
            model.Rename(Command.Title);
            unitOfWork.CommitTran();
            //ArticleCategoryRepositoory.Save();
        }

        public List<ArticleCategoryViewModel> List()
        {
            //get all article categoris (map)
            //return result
            var result = ArticleCategoryRepositoory.GetAll();
            return result.Select(i => new ArticleCategoryViewModel()
            {

                Id = i.Id,
                Title = i.Title,
                CreationDate = i.CreationDate.ToString(),
                IsDeleted = i.IsDeleted
            }).OrderByDescending(s => s.Id).ToList();
        }
        public RenameArticleCategory Get(int Id)
        {
            var model=ArticleCategoryRepositoory.Get(Id);
            return new RenameArticleCategory()
            {
                Id = (int)model.Id,
                Title = model.Title
            };
        }

        public void Remove(int Id)
        {
            unitOfWork.BeginTran();
            var model = ArticleCategoryRepositoory.Get(Id);
            model.Remove();
            unitOfWork.CommitTran();
            //ArticleCategoryRepositoory.Save();
        }

        public void Active(int Id)
        {
            unitOfWork.BeginTran();
            var model = ArticleCategoryRepositoory.Get(Id);
            model.Active();
            unitOfWork.CommitTran();
            //ArticleCategoryRepositoory.Save();
        }
    }
}
