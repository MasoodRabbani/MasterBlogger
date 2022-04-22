using MB.Application.Contract.ArticleCategory;
using Microsoft.Extensions.DependencyInjection;
using MB.Application;
using System;
using MB.Application.Contact.Article;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using MB.Infrastructure.EFCore;
using MB.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Core
{
    public class Bootstrapper
    {
        public static void Config(IServiceCollection services, string ConnectingString)
        {
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepositoory, ArticleCategoryRepository>();
            services.AddTransient<IArticleCategoryValidationServices, ArticleCategoryValidationServices>();

            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddDbContext<MasterBlogerContext>(option => option.UseSqlServer(ConnectingString));
        }
    }
}
