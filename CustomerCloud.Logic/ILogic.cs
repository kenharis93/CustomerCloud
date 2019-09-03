using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCloud.Logic
{
    interface ILogic<TDTO>
    {
        void Create(TDTO item);
        TDTO Read(Guid Id);
        void Update(TDTO item);
        void Delete(Guid Id);
    }
}
