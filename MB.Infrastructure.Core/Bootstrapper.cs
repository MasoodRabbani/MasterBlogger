using MB.Application.Contract.ArticleCategory;
using Microsoft.Extensions.DependencyInjection;
using MB.Application;
using System;
using MB.Domain.ArticleCategoryAgg;
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
            services.AddDbContext<MasterBlogerContext>(option => option.UseSqlServer(ConnectingString));
        }
    }
}
