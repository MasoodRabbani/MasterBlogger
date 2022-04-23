using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Application.Contact.Article;
using MB.Domain.ArticleAgg;

namespace MB.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private IArticleRepository artcileRepository;

        public ArticleApplication(IArticleRepository artcileRepository)
        {
            this.artcileRepository = artcileRepository;
        }

        public void Active(long Id)
        {
            var model = artcileRepository.Get(Id);
            model.Active();
            artcileRepository.Save();
        }

        public void Create(CreateArticle Command)
        {
            artcileRepository.Add(new Article(Command.Title,Command.ShortDescription,Command.Image,Command.Content,Command.ArticleCategory));
        }

        public void Edit(EditArticle Command)
        {
            var model=artcileRepository.Get(Command.Id);
            model.Edit(Command.Title,Command.ShortDescription,Command.Image,Command.Content,Command.ArticleCategory);
            artcileRepository.Save();
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
            return artcileRepository.GetAll();
        }

        public void Remove(long Id)
        {
            var model = artcileRepository.Get(Id);
            model.Remove();
            artcileRepository.Save();
        }
    }
}
