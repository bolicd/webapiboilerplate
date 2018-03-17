using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi2OwinBoilerplate
{
    public class MockRepo
    {
        public List<int> GetElements()
        {
            return new List<int>()
            {
                1,2,3
            };
        }
    }
}
