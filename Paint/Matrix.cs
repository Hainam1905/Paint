using System;
using System.Collections.Generic;
using System.Text;

namespace Paint
{
    class Matrix
    {
        private int row, col;
        private float[,] matrix;

        public Matrix()
        {
            Row = 1;
            Col = 1;

            matrix = new float[Row, Col];
            for (int i = 0; i < Row; i++)
                for (int j = 0; j < Col; j++)
                    matrix[i, j] = 0;
        }
        public Matrix(int row, int col)
        {
            Row = row;
            Col = col;

            matrix = new float[Row, Col];
            for (int i = 0; i < Row; i++)
                for (int j = 0; j < Col; j++)
                    matrix[i, j] = 0;
        }
        public Matrix(float[,] matrix)
        {
            Row = matrix.GetLength(0);
            Col = matrix.GetLength(1);

            //this.matrix = new float[Row, Col];
            this.matrix = matrix;
        }

        public int Row
        {
            set 
            {
                if (value >= 0) row = value;
                else throw new ArgumentOutOfRangeException();
            }
            get { return row; }
        }
        public int Col
        {
            set
            {
                if (value >= 0) col = value;
                else throw new ArgumentOutOfRangeException();
            }
            get { return col; }
        }
        public float[,] Matrixa
        {
            set {
                row = value.GetLength(0);
                col = value.GetLength(1);
                matrix = value;
                }
            get { return matrix; }
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.col != b.row) throw new ArithmeticException();
            else
            {
                Matrix maTranTich = new Matrix(a.row, b.col);

                for(int i = 0; i < maTranTich.row; i++)
                {
                    for(int j = 0; j < maTranTich.col; j++)
                    {
                        float sum = 0;
                        for (int k = 0; k < a.col; k++)
                            sum = sum + a.matrix[i, k] * b.matrix[k, j];
                        maTranTich.matrix[i, j] = sum;
                    }
                }

                return maTranTich;
            }
        }
    }
}
