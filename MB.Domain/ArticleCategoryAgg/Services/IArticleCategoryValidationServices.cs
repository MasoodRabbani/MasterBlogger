﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleCategoryAgg.Services
{
    public interface IArticleCategoryValidationServices
    {
        void CheckThatThisRecourdAlreadyExsitis(string Title);
    }
}
