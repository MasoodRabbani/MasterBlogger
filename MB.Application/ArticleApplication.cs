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

        public void Create(CreateArticle Command)
        {
            artcileRepository.Add(new Article(Command.Title,Command.ShortDescription,Command.Image,Command.Content,Command.ArticleCategory));
        }

        public List<ArticleViewModel> GetList()
        {
            return artcileRepository.GetAll();
        }
    }
}
