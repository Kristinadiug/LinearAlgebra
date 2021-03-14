using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SLAR.Models
{
    public class SLAR
    {
        public Matrix A { set; get; }

        public Vector x { set; get; }

        public Vector b { set; get; }

        public SLAR()
        {
            A = new Matrix();
            x = new Vector();
            b = new Vector();
        }

        public SLAR(int n, int m)
        {
            A = new Matrix(n, m);
            x = new Vector(m);
            b = new Vector(n);
        }
    }
}
