using MB.Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Infrastructure.EFCore.Repository
{
    public class CommentRepository:ICommentRepository
    {
        private readonly MasterBlogerContext context;

        public CommentRepository(MasterBlogerContext context)
        {
            this.context = context;
        }
    }
}
