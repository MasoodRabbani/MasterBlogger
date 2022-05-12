using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_FreamWork.Infrastructure;
using MB.Application.Contact.Article;
using MB.Domain.ArticleAgg;

namespace MB.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private IArticleRepository artcileRepository;
        private readonly IUnitOfWork unitOfWork;

        public ArticleApplication(IArticleRepository artcileRepository, IUnitOfWork unitOfWork)
        {
            this.artcileRepository = artcileRepository;
            this.unitOfWork = unitOfWork;
        }


        public void Active(long Id)
        {
            unitOfWork.BeginTran();
            var model = artcileRepository.Get(Id);
            model.Active();
            unitOfWork.CommitTran();
            //artcileRepository.Save();
        }

        public void Create(CreateArticle Command)
        {
            unitOfWork.BeginTran();
            artcileRepository.Create(new Article(Command.Title,Command.ShortDescription,Command.Image,Command.Content,Command.ArticleCategory));
            unitOfWork.CommitTran();
        }

        public void Edit(EditArticle Command)
        {
            unitOfWork.BeginTran();
            var model=artcileRepository.Get(Command.Id);
            model.Edit(Command.Title,Command.ShortDescription,Command.Image,Command.Content,Command.ArticleCategory);
            unitOfWork.CommitTran();
            
            //artcileRepository.Save();
        }

        public EditArticle Get(long Id)
        {
            var model = artcileRepository.Get(Id);
            return new EditArticle
            {
                Id = model.Id,
                ArticleCategory = model.ArticleCategoryId,
                Content = model.Content,
                Image = model.Image,
                ShortDescription = model.ShortDescription,
                Title = model.Title
            };
        }

        public List<ArticleViewModel> GetList()
        {
            return artcileRepository.GetList();
        }

        public void Remove(long Id)
        {
            unitOfWork.BeginTran();
            var model = artcileRepository.Get(Id);
            model.Remove();
            unitOfWork.CommitTran();
            //artcileRepository.Save();
        }
    }
}
