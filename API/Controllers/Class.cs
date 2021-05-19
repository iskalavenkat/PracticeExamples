using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class Class:Interface
    {
        public int add()
        {
            return 10;
        }

        public int sub()
        {
            throw new NotImplementedException();
        }
    }
}
