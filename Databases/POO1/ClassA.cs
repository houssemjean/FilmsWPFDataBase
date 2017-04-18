using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1
{
    class ClassA
    {
        private ClassB objB;

        public ClassA() {
            objB = new ClassB();
            TestRefCirculaire.counter++;
        }
    }
}
