using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Application.Contact.ArticleCategory;
using MB.Application.Contract.ArticleCategory;

namespace MB.Application.Contract.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        List<ArticleCategoryViewModel> List();
        void Create(CreateArticleCategory Command);
        void Rename(RenameArticleCategory Command);
        RenameArticleCategory Get(int Id);
        void Remove(int Id);
        void Active(int Id);
    }
}
