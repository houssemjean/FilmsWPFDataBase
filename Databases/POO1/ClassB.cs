using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1
{
    class ClassB
    {
         private ClassA objA;

        public ClassB() {
            objA = new ClassA();
            TestRefCirculaire.counter++;
        }
    }
}
