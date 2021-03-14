using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLAR.Models
{
    [Serializable]
    public class Matrix
    {
        public int n { get; set; }
        public int m { get; set; }
        public int id { get; set; }
        public string name { get; set; }

        private int[][] matrix;

        public Matrix()
        {
            this.n = 1;
            this.m = 1;
        }

        public Matrix(int _n, int _m)
        {
            this.n = _n;
            this.m = _m;
            Initialize();
        }

        public Matrix(int _n, int _m, int value) : this(_n, _m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i][j] = value;
                }
            }
        }

        private void Initialize()
        {
            id = Convert.ToInt32(Guid.NewGuid());
            matrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[m];
            }
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.n != b.n || a.m != b.m)
            {
                throw new ArgumentException("Matrixes have to be the same size");
            }

            Matrix result = new Matrix(a.n, a.m);

            for (int i = 0; i < a.n; i++)
            {
                for (int j = 0; j < a.m; j++)
                {
                    result.matrix[i][j] = a.matrix[i][j] + b.matrix[i][j];
                }
            }

            return result;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.n != b.n || a.m != b.m)
            {
                throw new ArgumentException("Matrixes have to be the same size");
            }

            Matrix result = new Matrix(a.n, a.m);

            for (int i = 0; i < a.n; i++)
            {
                for (int j = 0; j < a.m; j++)
                {
                    result.matrix[i][j] = a.matrix[i][j] - b.matrix[i][j];
                }
            }

            return result;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.m != b.n)
            {
                throw new ArgumentException("Can not multiply matrixes of this size");
            }

            Matrix result = new Matrix(a.n, b.m, 0);
            for (int i = 0; i < a.n; i++)
            {
                for (int j = 0; j < b.m; j++)
                {
                    for (int k = 0; k < b.n; k++)
                    {
                        result.matrix[i][j] += a.matrix[i][k] * b.matrix[k][j];
                    }
                }
            }

            return result;
        }


        public void ReadFromFile(string path)
        {
            string[] text = File.ReadAllText(path).Split();
            n = Convert.ToInt32(text[0]);
            m = Convert.ToInt32(text[1]);

            Initialize();

            int index = 2;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i][j] = Convert.ToInt32(text[index]);
                    index++;
                }
            }
        }

        public void FillWithRandomValues(int min = 0, int max = 10000000)
        {
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i][j] = random.Next(min, max);
                }
            }
        }

        public int GetId()
        {
            return id;
        }
    }
}

