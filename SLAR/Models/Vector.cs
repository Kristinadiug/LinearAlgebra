using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLAR.Models
{
    class Vector: Matrix
    {
        public Vector(int n) : base(n, 1) { }

        public Vector() : base() { }
    }
}
