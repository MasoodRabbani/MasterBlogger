using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Infrastructure.EFCore.Mapping
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Title);
            builder.Property(s => s.ShortDescription);
            builder.Property(s => s.IsDeleted);
            builder.Property(s => s.Image);
            builder.Property(s => s.CreationDate);
            builder.Property(s => s.Content);
            builder.HasOne(s => s.ArticleCategory)
                .WithMany(s => s.Articles)
                .HasForeignKey(s => s.ArticleCategoryId);
            builder.HasMany(s => s.Comments)
                .WithOne(s => s.Article)
                .HasForeignKey(s => s.ArticleId);
        }
    }
}
