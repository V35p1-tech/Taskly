using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskly
{
    internal class test
    {
        private string _test = "test";
        public string Test 
        {
            get { return _test; }
            set { _test = Test; }
        }
        public void testMetody()
        {
            _test = "test <- Metoda";
        }
    }
}
