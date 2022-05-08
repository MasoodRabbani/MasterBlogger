﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Application.Contact.Comment;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository
    {
        void Create(Comment entity);
        List<CommentViewModel> GetList();
        Comment Get(long Id);
        void Save();
    }
}
