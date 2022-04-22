using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Infrastructure.EFCore.Mapping
{
    public class ArticleCategoryMapping : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.ToTable("ArticleCategories");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Title);
            builder.Property(s => s.CreationDate);
            builder.Property(s => s.IsDeleted);
            builder.HasMany(s => s.Articles)
                .WithOne(s => s.ArticleCategory)
                .HasForeignKey(s => s.ArticleCategoryId);
        }
    }
}
