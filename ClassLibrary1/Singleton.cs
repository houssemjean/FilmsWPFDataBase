using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class Singleton
    {
        private static Singleton instance = null;
        private static object temoin = new object();

        public Singleton() { }

        public static Singleton Instance
        {
            get
            {
                lock (temoin)
                {
                    if (instance == null)
                        instance = new Singleton();
                    return instance;
                }
            }
        }
    }
        
}
