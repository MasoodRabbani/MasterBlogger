using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.ArticleCategoryAgg.Exception;

namespace MB.Domain.ArticleCategoryAgg.Services
{
    public class ArticleCategoryValidationServices : IArticleCategoryValidationServices
    {
        private readonly IArticleCategoryRepositoory articleCategoryRepositoory;

        public ArticleCategoryValidationServices(IArticleCategoryRepositoory articleCategoryRepositoory)
        {
            this.articleCategoryRepositoory = articleCategoryRepositoory;
        }
        public void CheckThatThisRecourdAlreadyExsitis(string Title)
        {
            if (articleCategoryRepositoory.Exsitis(Title))
                throw new DuoblicatedRecourdException("this record already exsits is database...");
            
        }
    }
}
