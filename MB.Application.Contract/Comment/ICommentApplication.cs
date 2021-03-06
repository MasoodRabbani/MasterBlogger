using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application.Contact.Comment
{
    public interface ICommentApplication
    {
        void Add(AddComment Command);
        List<CommentViewModel> GetList();
        void Confirm(long Id);
        void Canceled(long Id);
    }
}
