using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLAR.Models
{
    public static class Matrices 
    {
        public static List<Matrix> matrices = new List<Matrix>();

        public static void Add(Matrix matrix)
        {
            matrices.Add(matrix);
        }

        public static Matrix Get(int _id)
        {
            foreach(Matrix matrix in matrices)
            {
                if(matrix.GetId() == _id)
                {
                    return matrix;
                }
            }
            return new Matrix();
        }
    }
}
