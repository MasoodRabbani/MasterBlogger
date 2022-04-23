using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Infrastructure.EFCore.Mapping
{
    public class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name);
            builder.Property(s => s.Email);
            builder.Property(s => s.Massage);
            builder.Property(s => s.Status);
            builder.Property(s => s.CreationDate);
            builder.Property(s => s.ArticleId);
            builder.HasOne(s => s.Article)
                .WithMany(s => s.Comments)
                .HasForeignKey(s => s.ArticleId);
        }
    }
}
