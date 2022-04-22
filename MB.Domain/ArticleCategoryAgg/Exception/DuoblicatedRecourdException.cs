using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleCategoryAgg.Exception
{
    public class DuoblicatedRecourdException:System.Exception
    {
        public DuoblicatedRecourdException()
        {
            
        }
        public DuoblicatedRecourdException(string masage):base(masage)
        {
            
        }
    }
}
