using MB.Domain.ArticleCategoryAgg.Exception;

namespace MB.Domain.ArticleAgg.Services
{
    public class ArticleValidatorServices : IArticleValidatorServices
    {
        private readonly IArticleRepository articleRepository;
        public void CheckThatThisRecordAlreadyExists(string title)
        {
            if (articleRepository.Exists(s=>s.Title==title))
                throw new DuoblicatedRecourdException("Is record Article Title Dublication...");
            
        }
    }
}