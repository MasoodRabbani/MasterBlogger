using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application.Contact.Article
{
    public class CreateArticle
    {
        public string  Title { get; set; }
        public string ShortDescription { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public long ArticleCategory { get; set; }
    }
}
