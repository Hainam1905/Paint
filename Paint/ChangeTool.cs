using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    class ChangeTool
    {
        //private Bitmap bm;//, bmTemp, bmDefault;
        private Label Label;

        //Constructor
        public ChangeTool(Label label)
        {
            this.Label = label;

            //Bitmap chính
            //bm = bitmap;

            //Bitmap Để tô màu
            //bmTemp = new Bitmap(bitmap);

            //Bitmap mặc định, không phải để vẽ
            //bmDefault = new Bitmap(bitmap);
        }

        private Matrix MatrixTransalting(int x, int y)
        {
            float[,] z =
            {
                {1, 0, 0 },
                {0, 1, 0 },
                {x, y, 1 }
            };
            //Matrix translateToAroudP = new Matrix(z);
            return new Matrix(z);
        }

        //ma trận tịnh tiến đến O
        private Matrix MatrixTranslatingToO(Point point)
        {
            float[,] x =
            {
                {1, 0, 0 },
                {0, 1, 0 },
                {-point.X, -point.Y, 1 }
            };
            //Matrix translateToO = new Matrix(x);
            return new Matrix(x);
        }

        private double ConvertToRadius(double angle)
        {
            return angle * MathF.PI / 180;
        }
        private float ConvertToAngle(float radius)
        {
            return radius * 180.0f / MathF.PI;
        }

        private Matrix MatrixRotateAroundO(float angle)
        {
            float[,] y =
            {
                {MathF.Cos(angle * MathF.PI / 180), MathF.Sin(angle * MathF.PI / 180), 0 },
                {-MathF.Sin(angle * MathF.PI / 180), MathF.Cos(angle * MathF.PI / 180), 0 },
                {0, 0, 1 }
            };
            
            return new Matrix(y);
        }private Matrix MatrixRotateAroundO(float cos, float sin)
        {
            float[,] y =
            {
                {cos, sin, 0 },
                {-sin, cos, 0 },
                {0, 0, 1 }
            };
            
            return new Matrix(y);
        }

        //Ma trận xoay quay một điểm với một góc angle
        private Matrix MatrixRotateAroundPoint(Point aroundP, float angle)
        {
            Matrix translateToO = MatrixTranslatingToO(aroundP);

            //Ma trận quay quanh O góc angle
            Matrix rotateAroundO = MatrixRotateAroundO(angle);

            //Ma trận tịnh tiến về chỗ cũ
            Matrix translateToAroudP = MatrixTransalting(aroundP.X, aroundP.Y);

            Matrix temp = translateToO * rotateAroundO;
            return temp * translateToAroudP;
        }private Matrix MatrixRotateAroundPoint(Point aroundP, float cos, float sin)
        {
            Matrix translateToO = MatrixTranslatingToO(aroundP);

            //Ma trận quay quanh O góc angle
            Matrix rotateAroundO = MatrixRotateAroundO(cos, sin);

            //Ma trận tịnh tiến về chỗ cũ
            Matrix translateToAroudP = MatrixTransalting(aroundP.X, aroundP.Y);

            Matrix temp = translateToO * rotateAroundO;
            return temp * translateToAroudP;
        }

        //Đưa điểm 2D về ma trận điểm
        private Matrix TransaleToMatrixPoint(Point point)
        {
            float[,] x =
            {
                {point.X, point.Y, 1 }
            };
            return new Matrix(x);
        }

        //Đưa ma trận điểm về điểm 2D
        private Point TransaleToPoint(Matrix matrix)
        {
            return new Point((int)matrix.Matrixa[0, 0], (int)matrix.Matrixa[0, 1]);
        }

        private double TinhGoc(Point firstP, Point lastP)
        {
            double hsg;

            if (lastP.X == firstP.X) return 90;
            else if (lastP.Y == firstP.Y) return 0;
            else
            {
                hsg = (lastP.Y - firstP.Y) * 1.0d / (lastP.X - firstP.X);
                return Math.Tanh(ConvertToRadius(hsg));
                //return ConvertToAngle(MathF.Tanh(hsg));
            }
        }

        private Matrix MatrixSymmetryPointByOx()
        {
            float[,] z =
            {
                {1, 0, 0 },
                {0, -1, 0 },
                {0, 0, 1 }
            };
            return new Matrix(z);
        }

        private double Sin(Point point)
        {
            //if (point.X == 0) return 1;
            //else if (point.Y == 0) return 0;
            if (point.X * point.Y > 0) return Math.Abs(point.Y) / Math.Sqrt(Math.Pow(point.X, 2) + Math.Pow(point.Y, 2));
            else return -Math.Abs(point.Y) / Math.Sqrt(Math.Pow(point.X, 2) + Math.Pow(point.Y, 2));
        }
        private double Sin(Point A, Point B)
        {
            //if (point.X == 0) return 1;
            //else if (point.Y == 0) return 0;
            if (A.X * A.Y > 0 && B.X * B.Y > 0) 
                return Math.Abs(A.Y - B.Y) / Math.Sqrt(Math.Pow(B.Y - A.Y, 2) + Math.Pow(B.X - A.X, 2));
            else return -Math.Abs(A.Y - B.Y) / Math.Sqrt(Math.Pow(B.Y - A.Y, 2) + Math.Pow(B.X - A.X, 2));
        }

        private double Cos(Point point)
        {
            if (point.X > 0) return Math.Abs(point.X) / Math.Sqrt(Math.Pow(point.X, 2) + Math.Pow(point.Y, 2));
            else return -Math.Abs(point.X) / Math.Sqrt(Math.Pow(point.X, 2) + Math.Pow(point.Y, 2));
        }
        private double Cos(Point A, Point B)
        {
            if (A.X > 0 && B.X > 0) 
                return Math.Abs(B.X - A.X) / Math.Sqrt(Math.Pow(B.Y - A.Y, 2) + Math.Pow(B.X - A.X, 2));
            else return -Math.Abs(B.X - A.X) / Math.Sqrt(Math.Pow(B.Y - A.Y, 2) + Math.Pow(B.X - A.X, 2));
        }
    

        private Matrix MatrixSymmetricalPointByLine(Point firstP, Point lastP)
        {
            double deltaY = lastP.Y - firstP.Y;
            double deltaX = lastP.X - firstP.X;
            double angle = Math.Atan2(deltaX, deltaX) * 180 * 1.0 / Math.PI;


            //Tìm ma trận Tịnh tiến firstP về O
            Matrix translateToO = MatrixTransalting(-firstP.X, -firstP.Y);

            //Tìm ma trận xoay đường thẳng song song với Ox (Quay B một góc hợp bởi đường thẳng và Ox)
            //Tìm sin cos của đường thẳng với Ox
            double sin = Sin(firstP, lastP);
            double cos = Cos(firstP, lastP);
            Label.Text = firstP + " " + lastP + " " + sin + " " + cos + " " + angle;

            Matrix rotate = MatrixRotateAroundO((float)cos, -(float)sin);

            //Tìm ma trận đối xứng qua Ox
            Matrix SymmetryOx = MatrixSymmetryPointByOx();

            //Tìm ma trận tịnh tính ngược lại firstP
            Matrix translateToFirstP = MatrixTransalting(firstP.X, firstP.Y);

            //Tìm ma trận quay ngược lại hướng cũ
            Matrix rotateToOld = MatrixRotateAroundPoint(firstP, (float)cos, (float)sin);

            return translateToO * rotate * SymmetryOx * translateToFirstP * rotateToOld;
        }

        //Quay quanh một điểm
        //public void RotateAroundPoint(Point aroundP, List<Point> listP, float angle, Color color)
        //{
        //    //Tim Ma tran bien doi
        //    Matrix rotateAroundPoint = MatrixRotateAroundPoint(aroundP, angle);

        //    //Dùng ma trận biến đổi để quay các điểm trong listP quanh aroundP với góc angle
        //    foreach(Point point in listP)
        //    {
        //        //Đưa điểm về matrix
        //        Matrix matrixPoint = this.TransaleToMatrixPoint(point);

        //        //Nhân ma trận điểm với ma trận biến đổi
        //        matrixPoint = matrixPoint * rotateAroundPoint;

        //        //Đưa ma trận điểm về điểm
        //        Point kq = TransaleToPoint(matrixPoint);
        //        bm.SetPixel(kq.X, kq.Y, color);
        //    }
        //}
        public Point RotateAroundPoint(Point aroundP, Point rotateP, float angle, Color color)
        {
            //Tim Ma tran bien doi
            Matrix rotateAroundPoint = MatrixRotateAroundPoint(aroundP, angle);

            //Dùng ma trận biến đổi để quay các điểm trong listP quanh aroundP với góc angle
                //Đưa điểm về matrix
                Matrix matrixPoint = this.TransaleToMatrixPoint(rotateP);

                //Nhân ma trận điểm với ma trận biến đổi
                matrixPoint = matrixPoint * rotateAroundPoint;

                //Đưa ma trận điểm về điểm
                Point kq = TransaleToPoint(matrixPoint);
            return kq;
        }

        //Đối xứng qua đương thẳng
        public Point SymmetricalPointByLine(Point firstP, Point lastP, Point SymmertricalP, Color color)
        {
            //Tìm ma trận biến đổi
            Matrix matrixSymmertricalPointByLine = MatrixSymmetricalPointByLine(firstP, lastP);
            
            Matrix matrixSymmertricalP = TransaleToMatrixPoint(SymmertricalP);

            matrixSymmertricalP = matrixSymmertricalP * matrixSymmertricalPointByLine;
            //Label.Text = TransaleToPoint(matrixSymmertricalP) + " ";
            return TransaleToPoint(matrixSymmertricalP);
        }
        // BỔ SUNG
        //Tịnh tiến 
        public Point TinhTien(Point firstP, int x, int y, Color color)
        {
            //Tìm ma trận biến đổi
            Matrix maTranTinhTien = MatrixTransalting(x, y);

            Matrix maTranDiem = TransaleToMatrixPoint(firstP);

            maTranDiem = maTranDiem * maTranTinhTien;

            return TransaleToPoint(maTranDiem);
        }
        //Tỉ lệ
        private Matrix MaTranTiLe(float Sx, float Sy)
        {
            float[,] k =
            {
                {Sx, 0, 0 },
                {0, Sy, 0 },
                {0, 0, 1 }
            };
            return new Matrix(k);
        }
        public Point TiLe(Point firstP, float Sx, float Sy, Color color)
        {
            //Tìm ma trận biến đổi
            Matrix maTranTiLe = MaTranTiLe(Sx, Sy);

            Matrix maTranDiem = TransaleToMatrixPoint(firstP);

            maTranDiem = maTranDiem * maTranTiLe;

            return TransaleToPoint(maTranDiem);
        }
    }
}
