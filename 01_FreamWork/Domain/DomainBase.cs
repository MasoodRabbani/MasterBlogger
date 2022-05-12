using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_FreamWork.Domain
{
    public class DomainBase<T>
    {
        public T Id { get;private set; }
        public DateTime CreateDateTime { get;private set; }

        public DomainBase()
        {
            CreateDateTime =DateTime.Now;
        }
    }
}
